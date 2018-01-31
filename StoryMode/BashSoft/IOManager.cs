using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BashSoft
{
    public static class IOManager
    {

        public static void TraverseDirectory(string path)
        {
            OutputWriter.WriteEmptyLine();
            int initialIdentation = path.Split('\\').Length;
            Queue<string> subFolders = new Queue<string>();
            subFolders.Enqueue(path);

            while (subFolders.Count != 0)
            {
                string currentPath = subFolders.Dequeue();
                int identation = currentPath.Split('\\').Length - initialIdentation;

                //OutputWriter.WriteMessageOnNewLine($"{new string('-', identation)}{currentPath}");
                OutputWriter.WriteMessageOnNewLine(string.Format("{0}{1}", 
                                                    new string('-', identation), currentPath));


                foreach (string file in Directory.GetFiles(currentPath))
                {
                    int indexOfLastSlash = file.LastIndexOf('\\');
                    string fileName = file.Substring(indexOfLastSlash);
                    OutputWriter.WriteMessageOnNewLine($"{new string('-', indexOfLastSlash)}{fileName}");
                }

                foreach (string directoryPath in Directory.GetDirectories(currentPath))
                {
                    subFolders.Enqueue(directoryPath);
                }

            }
        }
    }
}
