using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace P03.WordCount
{
    class WordCount
    {
        static void Main()
        {
            var result = new Dictionary<string, int>();

            // 1. Take the words:
            using (var readStreamWords = new StreamReader("../03. Streams-Exercise/words.txt"))
            {
                var words = new List<string>();

                string wordLline;

                while ((wordLline = readStreamWords.ReadLine()) != null)
                {
                    words.Add(wordLline.ToLower());
                }

                foreach (var word in words)
                {
                    if (!result.ContainsKey(word))
                    {
                        result[word] = 0;
                    }
                }
            }
            
            // 2. Take the text:
            using (var readStreamText = new StreamReader("../03. Streams-Exercise/text.txt"))
            {                
                string text;
                while ((text = readStreamText.ReadLine()) != null)
                {
                    var separators = "-? !.,;:".ToCharArray();
                    string[] textArray = text
                        .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                        .Select(t => t.ToLower())
                        .ToArray();

                    foreach (var t in textArray)
                    {
                        if (result.ContainsKey(t))
                        {
                            result[t] += 1;
                        }
                    }                    
                }
            }

            // 3. Writing the result file:
            using (var writeStream = new StreamWriter("output.txt"))
            {
                foreach (var r in result.OrderByDescending(v => v.Value))
                {
                    writeStream.WriteLine($"{r.Key} - {r.Value}");
                }
            }
        }
    }
}
