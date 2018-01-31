using System;
using System.IO;

namespace P02.LineNumbers
{
    class LineNumbers
    {
        static void Main()
        {
            using (var readStream = new StreamReader("../03. Streams-Exercise/text.txt"))
            {
                using (var writeStream = new StreamWriter("output.txt"))
                {
                    int lineNumber = 1;
                    string line;

                    while ((line = readStream.ReadLine()) != null)
                    {
                        writeStream.WriteLine($"Line {lineNumber}: {line}");
                        
                        lineNumber++;
                    }
                }
            }

        }
    }
}
