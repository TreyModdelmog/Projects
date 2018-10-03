/* BTreeNode.cs
 * Author: Trey Moddelmog
 */

using KansasStateUniversity.TreeViewer2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.BTrees
{
    class BTreeNode<TKey, TValue> : ITree where TKey : IComparable<TKey>
    {
        /// <summary>
        ///  keeps track of how many keys are currently in this node
        /// </summary>
        private int _keyCount;

        /// <summary>
        /// stores the minimum number of keys this node can have
        /// </summary>
        private int _minKeyCount;

        /// <summary>
        /// an array that holds the keys of this node in ascending order
        /// </summary>
        private TKey[] _keys;

        /// <summary>
        /// keeps track of the number of children in this node
        /// </summary>
        private int _childCount;

        /// <summary>
        /// an array that stores the pointers to the children of this node
        /// </summary>
        private BTreeNode<TKey, TValue>[] _children;

        /// <summary>
        /// stores the values of the corresponding keys from the _keys array
        /// </summary>
        private TValue[] _values;

        /// <summary>
        /// indicates if this node is a leaf or not
        /// </summary>
        private bool _isLeaf;

        /// <summary>
        /// getter and setter for _keyCount
        /// </summary>
        public int KeyCount
        {
            get
            {
                return _keyCount;
            }
        }

        /// <summary>
        /// getter and setter for _keys
        /// </summary>
        public TKey[] Keys
        {
            get
            {
                return _keys;
            }
            set
            {
                _keys = value;
            }
        }

        /// <summary>
        /// getter and setter for _values
        /// </summary>
        public TValue[] Values
        {
            get
            {
                return _values;
            }
            set
            {
                _values = value;
            }
        }

        /// <summary>
        /// getter for _children
        /// </summary>
        public ITree[] Children
        {
            get
            {
                return _children;
            }
        }

        /// <summary>
        /// getter and setter for _isLeaf
        /// </summary>
        public bool IsLeaf
        {
            get
            {
                return _isLeaf;
            }
        }

        /// <summary>
        /// constructor for the BtreeNode class
        /// </summary>
        /// <param name="minKeyCount">minimum number of keys that each node can have</param>
        /// <param name="maxKeyCount">maximum number of keys that each node can have</param>
        /// <param name="maxChildCount">maximum number of children that each node can have</param>
        /// <param name="leaf">whether or not this node should be a leaf node</param>
        public BTreeNode(int minKeyCount, int maxKeyCount, int maxChildCount, bool leaf)
        {
            _minKeyCount = minKeyCount;
            _keys = new TKey[maxKeyCount];
            _values = new TValue[maxKeyCount];
            _children = new BTreeNode<TKey, TValue>[maxChildCount];
            _isLeaf = leaf;
        }

        /// <summary>
        /// adds a key value pair to _key and _value arrays
        /// </summary>
        /// <param name="key">key to add</param>
        /// <param name="value">value to add</param>
        public void AddItem(TKey key, TValue value)
        {
            for (int i = _keyCount - 1; i >= 0; i--)
            {
            int comparison = key.CompareTo(_keys[i]);
                if (comparison >= 0)
                {
                    _keys[i + 1] = key;
                    _values[i + 1] = value;
                    _keyCount++;
                return;
                }
                else
                {
                    _keys[i + 1] = _keys[i];
                    _values[i + 1] = _values[i];
                }
            } // end for
            _keys[0] = key;
             _values[0] = value;
            _keyCount++;
        }

        /// <summary>
        /// stores the child node in the _children array at index i and increments the number of children
        /// </summary>
        /// <param name="i">index to put child</param>
        /// <param name="child">child to store</param>
        public void AddChild(int i, BTreeNode<TKey, TValue> child)
        {
            _children[i] = child;
            _childCount++;
        }

        /// <summary>
        /// Once a node in the B-tree is full, this method can be called to split part of it into a new node
        /// </summary>
        /// <param name="index">helps indicates which child to split</param>
        public void SplitChild(int index)
        {
            BTreeNode<TKey, TValue> splitNode = _children[index];
            BTreeNode<TKey, TValue> newNode = new BTreeNode<TKey, TValue>(_minKeyCount, _keys.Length, _children.Length, splitNode.IsLeaf);

            for (int i = 0, j = _minKeyCount + 1; i < _minKeyCount; i++, j++)
            {
                newNode.AddItem(splitNode._keys[j], splitNode._values[j]);
                splitNode._keys[j] = default(TKey);
                splitNode._values[j] = default(TValue);
            }
            splitNode._keyCount = _minKeyCount;

            if (!newNode.IsLeaf)
            {
                for (int i = _children.Length / 2, j = 0; i < _children.Length; i++, j++)
                {
                    if (splitNode._children[i] != null)
                    {
                        newNode.AddChild(j, splitNode._children[i]);
                        splitNode.Children[i] = null;
                        splitNode._childCount--;
                    }
                }
            }

            for (int i = _keyCount; i >= index + 1; i--)
            {
                _children[i + 1] = _children[i];
            }

            AddChild(index + 1, newNode);
            AddItem(splitNode._keys[_minKeyCount], splitNode._values[_minKeyCount]);
            splitNode._keys[_minKeyCount] = default(TKey);
            splitNode._values[_minKeyCount] = default(TValue);
        }

        /// <summary>
        /// inserts into a tree whose root node is not full already
        /// </summary>
        /// <param name="key">key to insert</param>
        /// <param name="value">value to insert</param>
        public void InsertNonFull(TKey key, TValue value)
        {
            if (_isLeaf)
            {
                AddItem(key, value);
            }
            else
            {
                int index = 0;
                for (int i = _keyCount - 1; i >= 0; i--)
                {
                    if (_keys[i].CompareTo(key) <= 0)
                    {
                        index = i + 1;
                        break;
                    }
                } // end for
                if (_children[index]._keyCount == _children[index]._keys.Length)
                {
                    SplitChild(index);
                    if (_keys[index].CompareTo(key) < 0)
                    {
                        index++;
                    }
                }
                _children[index].InsertNonFull(key, value);
            }
        }

        /// <summary>
        /// implements a modified recursive binary search
        /// </summary>
        /// <param name="key">key to search for</param>
        /// <returns>the value found</returns>
        public TValue Find(TKey key)
        {
            int index = Array.IndexOf(_keys, key);
            if (index != -1)
            {
                return _values[index];
            }
            else if (index == -1 && _isLeaf)
            {
                return default(TValue);
            }
            else
            {
                int k = 0;
                for (k = 0; k < KeyCount; k++)
                {
                    if ((_keys[k].CompareTo(key) >= 0))
                    {
                        break;
                    }
                }
                return _children[k].Find(key);
            }
        }

        /// <summary>
        /// converts keys to string
        /// </summary>
        /// <returns>the keys in a string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _keys.Length; i++)
            {
                if (_keys[i] == null)
                    continue;
                if (_keys[i].CompareTo(default(TKey)) != 0)
                {
                    if (i == 0)
                        sb.Append(_keys[i].ToString());
                    else
                        sb.Append("|" + _keys[i].ToString());
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// returns this
        /// </summary>
        public object Root
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        /// returns if the number of keys in this node is 0
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return _keyCount == 0;
            }
        }
    }
}
