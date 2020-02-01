using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace aclerbois.sln.launcher
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var solutionFiles = Directory.EnumerateFiles(Environment.CurrentDirectory, "*.sln", SearchOption.AllDirectories).ToArray();
            
            if (!solutionFiles.Any())
            {
                Console.WriteLine("No solution file found in this directory.");
                return;
            }

            if (solutionFiles.Count() == 1)
            {
                ExecuteSolution(solutionFiles.First());
                return;
            }

            int i = 1;
            Console.WriteLine("Hi, you have multiple solution files in this directory, please select one.");
            foreach (var fileName in solutionFiles)
            {
                var fileInformation = new System.IO.FileInfo(fileName);
                Console.WriteLine($"({i}) {fileInformation.Name}");
                i++;
            }
            Console.Write("Your choice: ");
            var isSuccessfullyParsed = GetFileChoice(out int chosenSolutionIndex, solutionFiles.Count());
            while (!isSuccessfullyParsed)
            {
                Console.Write("Invalid choice, please try again: ");
                isSuccessfullyParsed = GetFileChoice(out chosenSolutionIndex, solutionFiles.Count());
            }
            ExecuteSolution(solutionFiles.ToArray()[chosenSolutionIndex - 1]);
        }

        private static bool GetFileChoice(out int chosenSolutionIndex, int maximum)
        {
            return int.TryParse(Console.ReadLine(), out chosenSolutionIndex) && chosenSolutionIndex > 0 && chosenSolutionIndex <= maximum;
        }

        private static void ExecuteSolution(string fileName)
        {
            Console.WriteLine($"Launching {fileName}");
            var si = new ProcessStartInfo
            {
                CreateNoWindow = true,
                FileName = fileName,
                UseShellExecute = true
            };
            Process.Start(si);
        }
    }
}
