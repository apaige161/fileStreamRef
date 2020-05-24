using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//added system.IO
using System.IO;

namespace SoccerStats
{
    class Program
    {
        static void Main(string[] args)
        {
            //directory class give us some static methods (can traverse folders or files) from the System.IO
            //first need to get the path of dir
            string currentDirectory = Directory.GetCurrentDirectory();
            //then ask for the info
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);

            //find a file before attempting to read it
            var fileName = Path.Combine(directory.FullName, "SoccerGameResults.csv");
            //use the method below to read and print out results
            var fileContents = ReadFile(fileName);
            //split contents line by line, the \r and \n represt a new line
            string[] fileLines = fileContents.Split(new char[] { '\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            foreach(var line in fileLines)
            {
                Console.WriteLine(line);
            }

            /*
            //writes each file in the directory
            var files = directory.GetFiles();
            foreach(var file in files)
            {
                Console.WriteLine(file.Name);
            }
            Console.WriteLine("Write all text files");
            var textFiles = directory.GetFiles("*.txt");
            //writes each file in the directory
            foreach (var file in textFiles)
            {
                Console.WriteLine(file.Name);
            }
            */
        }

        //read a file from start to finish
        public static string ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
