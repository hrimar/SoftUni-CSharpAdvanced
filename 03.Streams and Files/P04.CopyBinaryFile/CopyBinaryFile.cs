using System;
using System.IO;

namespace P04.CopyBinaryFile
{
    class CopyBinaryFile
    {
        static void Main()
        {         
            using (var sourceFile = new FileStream("../03. Streams-Exercise/copyMe.png", FileMode.Open)) 
            {
                using (var destinationFile = new FileStream("copyFile.png", FileMode.Create))
                {
                    byte[] buffer = new byte[4096];
                    while (true)
                    {
                        var readBytesCount = sourceFile.Read(buffer, 0, buffer.Length);

                        if(readBytesCount == 0)
                        {
                            break;
                        }
                        destinationFile.Write(buffer, 0, readBytesCount);
                    }
                }
            }
        }
    }
}
