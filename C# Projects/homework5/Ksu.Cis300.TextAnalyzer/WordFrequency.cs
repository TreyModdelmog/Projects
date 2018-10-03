/* WordFrequency.cs
 * Author: Trey Moddelmog
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TextAnalyzer
{
    struct WordFrequency
    {
        /// <summary>
        /// stores a word
        /// </summary>
        private string _word;

        /// <summary>
        /// storws the frequency of the word in each file
        /// </summary>
        private float[] _frequenies;

        /// <summary>
        /// constructor for WordFrequency
        /// </summary>
        /// <param name="wordCount">to get word and number of files</param>
        /// <param name="words">total number of words</param>
        public WordFrequency(WordCount wordCount, int[] words)
        {
            _word = wordCount.Word;
            _frequenies = new float[words.Length];

            if (words.Length != wordCount.NumberOfFiles)
            {
                throw new ArgumentException();
            }
            for (int i = 0; i < words.Length; i++)
            {
                _frequenies[i] = (float)wordCount[i] / words[i];
            }
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
        /// indexer for _frequencies
        /// </summary>
        /// <param name="i">index</param>
        /// <returns>float at that index</returns>
        public float this[int i]
        {
            get
            {
                if (0 <= i && i < _frequenies.Length)
                {
                    return _frequenies[i];
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
    }
}
