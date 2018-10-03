/* UserInterface.cs
 * Author: Trey Moddelmog
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ksu.Cis300.Sort;

namespace Ksu.Cis300.TextAnalyzer
{
    public partial class UserInterface : Form
    {
        /// <summary>
        /// constructor for UserInterface
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// gets the first filename and displays it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSelectText1_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                uxText1.Text = uxOpenDialog.FileName;
                if (uxText2.Text != "")
                {
                    uxAnalyze.Enabled = true;
                }
            }
        }

        /// <summary>
        /// gets the second filename and displays it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSelectText2_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                uxText2.Text = uxOpenDialog.FileName;
                if (uxText1.Text != "")
                {
                    uxAnalyze.Enabled = true;
                }
            }
        }

        /// <summary>
        /// processes both files, gets the words having the highest combined frequencies, 
        /// then computes and displays the difference measure
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxAnalyze_Click(object sender, EventArgs e)
        {
            try
            {
                int[] words = new int[2];
                Dictionary<string, WordCount> dictionary = new Dictionary<string, WordCount>();
                words[0] = TextAnalyzer.ProcessFile(uxText1.Text, 0, dictionary);
                words[1] = TextAnalyzer.ProcessFile(uxText2.Text, 1, dictionary);
                MinPriorityQueue<float, WordFrequency> queue = TextAnalyzer.GetMostCommonWords(dictionary, words, (int)uxNumberOfWords.Value);
                MessageBox.Show("Difference Measure: " + TextAnalyzer.GetDifference(queue).ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
