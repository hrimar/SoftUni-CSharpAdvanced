using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace P07.DirectoryTraversal
{
    class DirectoryTraversal
    {
        static void Main()
        {
            // Да се вземат от дадена директория всички файлове (само):
            string path = Console.ReadLine();

            var filesDict = new Dictionary<string, List<FileInfo>>();

            var files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file); // така взимам всичката инфо-я за файла!

                string extension = fileInfo.Extension;

                long size = fileInfo.Length;

                if(!filesDict.ContainsKey(extension))
                {
                    filesDict[extension] = new List<FileInfo>();
                }

                filesDict[extension].Add(fileInfo);
            }

            filesDict = filesDict
                .OrderByDescending(f => f.Value.Count)
                .ThenBy(f => f.Key)
                .ToDictionary(f => f.Key, fv => fv.Value);

            // string desctop = @"%USERPROFILE\Desctop\";
            string desctop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string fullFileName = desctop + "/report.txt";

            using (var writer = new StreamWriter(fullFileName))
            {
                foreach (var pair in filesDict)
                {
                    string extension = pair.Key;
                    var fileInfos = pair.Value.OrderByDescending(fi=>fi.Length);

                    writer.WriteLine(extension);

                    foreach (var fileInfo in fileInfos)
                    {
                        double fileSize = (double) fileInfo.Length / 1024;

                        writer.WriteLine($"--{fileInfo.Name} - {fileSize:f3}kb");
                    }
                }
            }
        }
    }
}
