/* WordCount.cs
 * Author: Trey Moddelmog
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TextAnalyzer
{
    class WordCount
    {
        /// <summary>
        /// stores a word
        /// </summary>
        private string _word;

        /// <summary>
        /// stores the number of occurrences of the word in each file
        /// </summary>
        private int[] _counts;

        /// <summary>
        /// constructor for word count
        /// </summary>
        /// <param name="word">a word</param>
        /// <param name="numFiles">number of files to be processed</param>
        public WordCount(string word, int numFiles)
        {
            _word = word;
            _counts = new int[numFiles];
        }

        /// <summary>
        /// property to get _word
        /// </summary>
        public string Word
        {
            get
            {
                return _word;
            }
        }

        /// <summary>
        /// property to get the number of files
        /// </summary>
        public int NumberOfFiles
        {
            get
            {
                return _counts.Length;
            }
        }

        /// <summary>
        /// indexer for _counts
        /// </summary>
        /// <param name="i">a file number</param>
        /// <returns>number of occurrences of the word in that file</returns>
        public int this [int i]
        {
            get
            {
                if (0 <= i && i < _counts.Length)
                {
                    return _counts[i];
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        /// <summary>
        /// increments the number of occurrences of the word in that file
        /// </summary>
        /// <param name="fileNumber">file to increment in</param>
        public void Increment(int i)
        {
            if (0 <= i && i < _counts.Length)
            {
                _counts[i]++;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
