using System;
using System.Collections.Generic;
using System.IO;

namespace P05.SlicingFile
{
    class SlicingFile
    {
        private const int bufferSize = 4096;

        static void Main()
        {
            string sourceFile = "../03. Streams-Exercise/sliceMe.mp4";
            string destination = "";
            int parts = 5;

            Slice(sourceFile, destination, parts);

            var files = new List<string>
            {
                "Part-0.mp4",
                "Part-1.mp4",
                "Part-2.mp4",
                "Part-3.mp4",
                "Part-4.mp4",
            };

            Assemble(files, destination);

        }

        static void Slice(string sourceFile, string destinationDirectory, int parts)
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
                    string currentPart = destinationDirectory + $"Part-{i}.{extension}";

                    // за всяка част си правим отделен FileStream, защото ще пишем в отделен файл:
                    using (var writer = new FileStream(currentPart, FileMode.CreateNew)) // така ще гръмне ако вече има такъв файл
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

        static void Assemble(List<string> files, string destinationDirectory)
        {
            string extension = files[0].Substring(files[0].LastIndexOf('.') + 1);

            if (destinationDirectory == string.Empty)
            {
                destinationDirectory = "./";
            }

            if (!destinationDirectory.EndsWith("/"))
            {
                destinationDirectory += "/";
            }

            string assembledFile = $"{destinationDirectory}Assembled.{extension}";

            using (FileStream write = new FileStream(assembledFile, FileMode.Create))
            {
                byte[] buffer = new byte[bufferSize];

                foreach (var file in files)
                {
                    using (FileStream reader = new FileStream(file, FileMode.Open))
                    {
                        while (reader.Read(buffer, 0, bufferSize ) == bufferSize)
                        {
                            write.Write(buffer, 0, bufferSize);
                        }
                    }
                }


            }
        }
    }
}
