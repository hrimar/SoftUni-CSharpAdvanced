using System;
using System.IO;

namespace P01.OddLines
{
    class OddLines
    {
        static void Main()
        {
            using (var readStream = new StreamReader("../03. Streams-Exercise/text.txt"))
            {
                int lineNumber = 0;
                string line;

                while ((line = readStream.ReadLine()) != null)
                {
                    if (lineNumber % 2 == 1)
                    {
                        Console.WriteLine(line);
                    }
                    lineNumber++;
                }
            }
        }
    }
}
