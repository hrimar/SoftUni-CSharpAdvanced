using BashSoft.SimpleJudge;
using System;

namespace BashSoft
{
    class Launcher
    {
        static void Main()
        {
            // Part I:
            IOManager.TraverseDirectory(@"C:\Projects\C# Advanced\StoryMode");

            // Part II:
           // StudentsRepository.InitializeData();
           // StudentsRepository.GetAllStudentsFromCourse("Unity");

             //StudentsRepository.GetStudentScoreFromCourse("Unity", "Ivan");


            // SimpleJudge:
            //Tester.CompareContent(@"..\BashSoft-Resources\test2.txt", @"..\BashSoft-Resources\test3.txt");

            // Problem 9. Create Directory
            //IOManager.CreateDirectoryInCurrentFolder("pesho");
        }
    }
}
