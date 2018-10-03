/* Solver.cs
 * Author: Trey Moddelmog
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.SatisfiabilitySolver
{
    public static class Solver
    {
        /// <summary>
        /// check to make sure the formula is valid
        /// </summary>
        /// <param name="formula">array holding formulas</param>
        /// <param name="vars">number of variables used in formulas</param>
        /// <returns>a bool saying if formula is valid</returns>
        private static bool IsValidFormula(string[] formula, int vars)
        {
            for (int i = 0; i < formula.Length; i++)
            {
                foreach (char c in formula[i])
                {
                    if (c < 'A' || (c > 'A' + vars && c < 'a') || c >= 'a' + vars)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// fills a stack with false values 
        /// </summary>
        /// <param name="stack">stack to be filled</param>
        /// <param name="vars">number used to prove how many false values are needed</param>
        private static void FillStack(Stack<bool> stack, int vars)
        {
            while (stack.Count < vars)
            {
                stack.Push(false);
            }
        }

        /// <summary>
        /// checks to makes sure it is a valid solution
        /// </summary>
        /// <param name="boolArr">holds truth assignments</param>
        /// <param name="formula">holds list of clauses</param>
        /// <returns>a bool saying if solution is valid</returns>
        private static bool IsSolution(bool[] boolArr, string[] formula)
        {
            bool valid = false;

            for (int i = 0; i < formula.Length && valid; i++)
            {
                valid = false;
                foreach (char c in formula[i])
                {
                    if (('Z' >= c && c >= 'A') && !boolArr[c - formula[i][0]])
                    {
                        valid = true;
                        break;
                    }
                    else if (boolArr[c - formula[i][0]])
                    {
                        valid = true;
                        break;
                    }
                } // end foreach

                if (valid == false)
                {
                    return false;
                }

            } // end for

            return true;
        }

        /// <summary>
        /// Solves the given clauses
        /// </summary>
        /// <param name="formula">string array containing each clause</param>
        /// <param name="vars">the number of variables in the clauses</param>
        /// <returns>a bool array holding the truth assignments</returns>
        public static bool[] Solve(string[] formula, int vars)
        {
            if (vars > 26 || vars < 0)
            {
                throw new IOException("The number of variables must be a positive integer no greater than 26.");
            }

            if (!IsValidFormula(formula, vars))
            {
                throw new IOException("The formula is invalid");
            }

            Stack<bool> stack = new Stack<bool>();

            FillStack(stack, vars);

            if (IsSolution(stack.ToArray(), formula))
            {
                return stack.ToArray();
            }

            while (stack.Count != 0)
            {
                if (stack.Count == vars)
                {
                    bool[] array = stack.ToArray();

                    if (IsSolution(array, formula))
                    {
                        return stack.ToArray();
                    }
                }

                if (!stack.Pop())
                {
                    stack.Push(true);
                    FillStack(stack, vars);
                }

            } // end while

            return null;
        }
    }
}