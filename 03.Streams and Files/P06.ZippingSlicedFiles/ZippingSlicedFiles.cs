using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace P06.ZippingSlicedFiles
{
    class ZippingSlicedFiles
    {

        private const int bufferSize = 4096;

        static void Main()
        {
            string sourceFile = "../03. Streams-Exercise/sliceMe.mp4";
            string destination = "";
            int parts = 5;
        
            Zip(sourceFile, destination, parts);

            var files = new List<string>
            {
                "Part-0.mp4.gz",
                "Part-1.mp4.gz",
                "Part-2.mp4.gz",
                "Part-3.mp4.gz",
                "Part-4.mp4.gz",
            };
            
            Unzipped(files, destination);
        }
             

        static void Zip(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {
                string extension = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1); // !!

                // за да не се загубят байтове при деленето се каства на double:
                long pieceSize = (long)Math.Ceiling((double)reader.Length / parts);


                for (int i = 0; i < parts; i++)
                {
                    long currentPieceSize = 0;

                    //destinationDirectory = destinationDirectory == string.Empty ? "./" : destinationDirectory;
                    //or:
                    if (destinationDirectory == string.Empty)
                    {
                        destinationDirectory = "./";
                    }
                    string currentPart = destinationDirectory + $"Part-{i}.{extension}.gz";

                    // за компресиране се декларират нещата по по-различен начин:
                    using (GZipStream writer = new GZipStream(new FileStream(currentPart, FileMode.Create), CompressionLevel.Optimal))
                    {
                        byte[] buffer = new byte[bufferSize];
                        while (reader.Read(buffer, 0, buffer.Length) == bufferSize)
                        {
                            writer.Write(buffer, 0, bufferSize);
                            currentPieceSize += bufferSize;

                            if (currentPieceSize >= pieceSize)
                            {
                                break;
                            }
                        }

                    }
                }

            }
        }

        static void Unzipped(List<string> files, string destinationDirectory)
        {
            string extension = files[0].Substring(files[0].LastIndexOf('.') -3, 3);
            
            if (destinationDirectory == string.Empty)
            {
                destinationDirectory = "./";
            }

            if (!destinationDirectory.EndsWith("/"))
            {
                destinationDirectory += "/";
            }

            string assembledFile = $"{destinationDirectory}Assembled.{extension}";
        
            using (GZipStream write = new GZipStream(new FileStream(assembledFile, FileMode.Create), CompressionLevel.Optimal))
            {
                byte[] buffer = new byte[bufferSize];

                foreach (var file in files)
                {
                    using (FileStream reader = new FileStream(file, FileMode.Open))
                    {
                        while (reader.Read(buffer, 0, bufferSize) == bufferSize)
                        {
                            write.Write(buffer, 0, bufferSize);
                        }
                    }
                }
            }
        }

    }
}
