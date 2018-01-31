using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace P08.FullDirectoryTraversal
{
    class FullDirectoryTraversal
    {
        // Да се вземат абсл. всички файлове от избрана директория и нейните потдиректории вкл:
        static void Main()
        {
            string directoryPath = Console.ReadLine();

            List<string> directories = GetAllDirectories(directoryPath);

            if(!directories.Any())
            {
                Console.WriteLine("No directroies found!");
                Environment.Exit(0);
            }

            var files = new Dictionary<string, List<FileInfo>>();

            foreach (var dir in directories)
            {
                GetDirectoryFilesByExtension(dir, files);
            }

            if (!files.Any())
            {
                Console.WriteLine("No files found!");
                Environment.Exit(0);
            }

            files = files
                .OrderByDescending(f => f.Value.Count)
                .ThenBy(f => f.Key)
                .ToDictionary(f => f.Key, fv => fv.Value);

            SaveReportToFile(files);
        }

        private static void SaveReportToFile(Dictionary<string, List<FileInfo>> files)
        {
            string desctop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string fullFileName = desctop + "/report.txt";

            using (var writer = new StreamWriter(fullFileName))
            {
                foreach (var pair in files)
                {
                    string extension = pair.Key;
                    var fileInfos = pair.Value.OrderByDescending(fi => fi.Length);

                    writer.WriteLine(extension);

                    foreach (var fileInfo in fileInfos)
                    {
                        double fileSize = (double)fileInfo.Length / 1024;

                        writer.WriteLine($"--{fileInfo.Name} - {fileSize:f3}kb");
                    }
                }
            }
        }

        private static void GetDirectoryFilesByExtension(string directoryPath, Dictionary<string, List<FileInfo>> files)
        {
            string[] fullPath = Directory.GetFiles(directoryPath);

            foreach (var file in fullPath)
            {
                string extension = file.Substring(file.LastIndexOf('.'));

                if (!files.ContainsKey(extension))
                {
                    files[extension] = new List<FileInfo>();
                }

                var fileInfo = new FileInfo(file);
                files[extension].Add(fileInfo);
            }

        }

        private static List<string> GetAllDirectories(string directoryPath)
        {
            var allDirectories = new List<string>();

            var directories = Directory.GetDirectories(directoryPath);

            foreach (var dir in directories)
            {
                allDirectories.AddRange(GetAllDirectories(dir));
            }

            allDirectories.Add(directoryPath);

            return allDirectories;
        }
    }
}
