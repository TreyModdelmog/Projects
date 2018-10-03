/* BTree.cs
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
    class BTree<TKey, TValue> : ITree where TKey : IComparable<TKey>
    {
        /// <summary>
        /// the minimum degree of the tree
        /// </summary>
        private int _size;

        /// <summary>
        /// the maximum number of children for the nodes in the tree
        /// </summary>
        private int _maxChildren;

        /// <summary>
        /// the minimum number of keys for each node in the tree, excluding the root
        /// </summary>
        private int _minKey;

        /// <summary>
        /// the maximum number of keys for each node in the tree
        /// </summary>
        private int _maxKey;

        /// <summary>
        /// the root node of the tree
        /// </summary>
        private BTreeNode<TKey, TValue> _root;

        /// <summary>
        /// returns if root is null
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return _root == null;
            }
        }

        /// <summary>
        /// returns the children of the root node
        /// </summary>
        public ITree[] Children
        {
            get
            {
                return (ITree[]) _root.Children;
            }
        }

        /// <summary>
        /// gets the root of the node
        /// </summary>
        public object Root
        {
            get
            {
                return _root;
            }
        }

        /// <summary>
        /// constructor that initializes all of the corresponding fields
        /// </summary>
        /// <param name="size"></param>
        public BTree(int size)
        {
            _size = size;
            _maxChildren = _size * 2;
            _minKey =  _size - 1;
            _maxKey = (_size * 2) - 1;
            _root = new BTreeNode<TKey, TValue>(_minKey, _maxKey, _maxChildren, true);
        }

        /// <summary>
        /// inserts a node into the B-tree starting at the root node
        /// </summary>
        /// <param name="key">key to insert</param>
        /// <param name="value">value to insert</param>
        public void Insert(TKey key, TValue value)
        {
            if (_root.IsEmpty)
            {
                _root.AddItem(key, value);
            }
            else if (_root.KeyCount != _maxKey)
            {
                _root.InsertNonFull(key, value);
            }
            else
            {
                BTreeNode<TKey, TValue> newRoot = new BTreeNode<TKey, TValue>(_minKey, _maxKey, _maxChildren, false);
                newRoot.AddChild(0, _root);
                newRoot.SplitChild(0);
                newRoot.InsertNonFull(key, value);
                _root = newRoot;
            }
        }

        /// <summary>
        /// calls Find on the root node
        /// </summary>
        /// <param name="key">key to find</param>
        /// <returns>results of root Find method</returns>
        public TValue Find(TKey key)
        {
            return _root.Find(key);
        }

    }
}
