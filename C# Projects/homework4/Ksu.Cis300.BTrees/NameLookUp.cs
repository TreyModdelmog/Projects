/* NameLookUp.cs
 * Author: Trey Moddelmog
 */

using KansasStateUniversity.TreeViewer2;
using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ksu.Cis300.BTrees
{
    public partial class NameLookUp : Form
    {
        /// <summary>
        /// stores the tree that is created by reading in a name information file
        /// </summary>
        private BTree<string, NameInformation> _names;

        /// <summary>
        /// constructor that only initializes the UI components
        /// </summary>
        public NameLookUp()
        {
            InitializeComponent();
        }

        /// <summary>
        /// makes a tree from give degree of depth and bumber of items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxMakeTree_Click(object sender, EventArgs e)
        {
            BTree<int, int> bTree = new BTree<int, int>((int)uxMinDegree.Value);
            for (int i = 1; i <= uxCount.Value; i++)
            {
                bTree.Insert(i, i);
            }
            new TreeForm(bTree, 100).Show();
        }

        /// <summary>
        /// The click event handler for the open data file button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpen_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _names = ReadFile(uxOpenDialog.FileName);
                    new TreeForm(_names, 100).Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// reads in a file creating a BTree
        /// </summary>
        /// <param name="fn">filename to read in</param>
        /// <returns>BTrees with string as key and NameInformation as value</returns>
        private BTree<string, NameInformation> ReadFile(string fn)
        {
            BTree<string, NameInformation> tree = new BTree<string, NameInformation>((int)uxMinDegree.Value);

            using (StreamReader input = new StreamReader(fn))
            {
                while (!input.EndOfStream)
                {
                    string name = input.ReadLine().Trim();
                    float freq = Convert.ToSingle(input.ReadLine());
                    int rank = Convert.ToInt32(input.ReadLine());
                    NameInformation info = new NameInformation(name, freq, rank);

                    tree.Insert(name, info);
                }
                return tree;
            }
        }

        /// <summary>
        /// looks up name from text box in names BTree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxLookUp_Click(object sender, EventArgs e)
        {
            try
            {
                string name = uxName.Text.Trim().ToUpper();
                NameInformation info = _names.Find(name);
                if (info.Name != null)
                {
                    uxFrequency.Text = info.Frequency.ToString();
                    uxRank.Text = info.Rank.ToString();
                    return;
                }
                else
                {
                    uxFrequency.Text = "";
                    uxRank.Text = "";
                    MessageBox.Show("name was not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Obejct reference not set to an instance of an object.");
            }
           
        }
    }
}