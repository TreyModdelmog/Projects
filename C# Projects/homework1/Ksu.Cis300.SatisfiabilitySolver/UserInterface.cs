/* UserInterface.cs
 * Author: Trey Moddelmog
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ksu.Cis300.SatisfiabilitySolver
{
    public partial class UserInterface : Form
    {
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Displays the solution found from solver class
        /// </summary>
        /// <param name="boolArr">the truth assignments given from solver class</param>
        public void DisplaySolution(bool[] boolArr)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < boolArr.Length; i++)
            {
                if (boolArr[i])
                {
                    sb.Append((char)(i + 'a'));
                }
                else
                {
                    sb.Append((char)(i + 'A'));
                }
            } // end for

            uxSolution.Text = sb.ToString();
        }

        /// <summary>
        /// Event handler that opens a file dialog and puts the lines from the choosen file into an array.  Then calls the solve method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxRead_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fileName = uxOpenDialog.FileName;
                    string[] formula = File.ReadAllLines(fileName);
                    int vars = Convert.ToInt32(formula[0]);

                    Array.Copy(formula, 1, formula, 0, formula.Length - 1);

                    bool[] assingments = Solver.Solve(formula, vars);

                    if (assingments != null)
                    {
                        DisplaySolution(assingments);
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }


        }
    }
}
