/* TextAnalyzer.cs
 * Author: Trey Moddelmog
 */

using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ksu.Cis300.Sort;
using System.IO;

namespace Ksu.Cis300.TextAnalyzer
{
    static class TextAnalyzer
    {
        /// <summary>
        /// reads the given file, updating the given dictionary to include the words in the given file, 
        /// and returns the total number of words
        /// </summary>
        /// <param name="fn">file name</param>
        /// <param name="fileNumber">number of files</param>
        /// <param name="dictionary">dictionary to add to</param>
        /// <returns>number of words</returns>
        public static int ProcessFile(string fn, int fileNumber, Dictionary<string, WordCount> dictionary)
        {
            int numberOfWords = 0;
            using (StreamReader input = new StreamReader(fn))
            {
                while (!input.EndOfStream)
                {
                    string[] words = Regex.Split(input.ReadLine().ToLower(), "[^abcdefghijklmnopqrstuvwxyz]+");

                    for (int i = 0; i < words.Length; i++)
                    {
                        if (words[i] != "")
                        {
                            numberOfWords++;
                            WordCount newCount;
                            if (!dictionary.TryGetValue(words[i], out newCount))
                            {
                                newCount = new WordCount(words[i], 2);
                                dictionary.Add(words[i], newCount);
                            }
                            newCount.Increment(fileNumber);
                        }
                    } // end for
                } // end while
            } // end using
            return numberOfWords;
        }

        /// <summary>
        /// returns a MinPriorityQueue whose elements contain the frequencies in each file of the most common words, 
        /// and whose priorities are the combined frequencies of each of these words
        /// </summary>
        /// <param name="dictionary">dictionary to take words from</param>
        /// <param name="words">total number of words</param>
        /// <param name="number">number of words needed to get</param>
        /// <returns>min priority queue holding the frequencies</returns>
        public static MinPriorityQueue<float, WordFrequency> GetMostCommonWords(Dictionary<string, WordCount> dictionary, int[] words, int number)
        {
            MinPriorityQueue<float, WordFrequency> queue = new MinPriorityQueue<float, WordFrequency>();
            foreach (WordCount value in dictionary.Values)
            {
                WordFrequency wordFrequency = new WordFrequency(value, words);
                queue.Add(wordFrequency[0] + wordFrequency[1], wordFrequency);
                if (queue.Count > number)
                {
                    queue.RemoveMinimumPriority();
                }
            }
            return queue;
        }

        /// <summary>
        /// returns a float giving the difference measure using the elements of the min-priority queue
        /// </summary>
        /// <param name="queue">queue to use</param>
        /// <returns>the difference measure</returns>
        public static float GetDifference(MinPriorityQueue<float, WordFrequency> queue)
        {
            // d = 100 * sqrt( (x1 - y1)^2 + ... + (xn - yn)^2 )
            float d = 0;
            while (queue.Count > 0)
            {
                WordFrequency f = queue.RemoveMinimumPriority();
                d += ((f[0] - f[1]) * (f[0] - f[1]));
            }
            return 100 * (float) Math.Sqrt(d);
        }

    }
}
