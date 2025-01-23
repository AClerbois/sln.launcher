using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Spectre.Console;

namespace aclerbois.sln.launcher;

internal class Program
{
    private static void Main(string[] args)
    {
        var solutionFiles = Directory.EnumerateFiles(Environment.CurrentDirectory, "*.sln", SearchOption.AllDirectories).ToArray();

        if (!solutionFiles.Any())
        {
            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine("[orange1] :rocket: Sln.Launcher - [/][red]:red_exclamation_mark: No solution file found in this directory.[/]");
            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine("[green] :beer_mug: Have a nice day.[/]");
            AnsiConsole.WriteLine();

            return;
        }

        if (solutionFiles.Count() == 1)
        {
            ExecuteSolution(solutionFiles.First());
            return;
        }

        DrawScreen();

        var solutions = solutionFiles.Select(sf => new FileInfo(sf).Name).ToList();
        solutions.Add("");
        solutions.Add("[red]> Exit[/]");

        string projectSelection = null;
        do
        {
            projectSelection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select a solution file?")
                    .PageSize(25)
                    .MoreChoicesText("[grey](Move up and down to reveal more solutions)[/]") 
                    .AddChoices(solutions)
                );
        }
        while (string.IsNullOrEmpty(projectSelection));

        if (string.Compare(projectSelection, "[red]> Exit[/]", true) != 0)
        {
            ExecuteSolution(solutionFiles.First(sf => new FileInfo(sf).Name == projectSelection));
        }
        AnsiConsole.MarkupLine("[green]:beer_mug: Have a nice day.[/]");
    }

    private static void ExecuteSolution(string fileName)
    {
        AnsiConsole.MarkupLine($"[green]:rocket: Launching {fileName}[/]");
        var si = new ProcessStartInfo
        {
            CreateNoWindow = true,
            FileName = fileName,
            UseShellExecute = true
        };
        Process.Start(si);
    }

    private static void DrawScreen()
    {
        var headerTable = new Table().LeftAligned();
        headerTable.AddColumn("[orange1] :rocket: Sln.Launcher - Hello[/]");
        headerTable.AddColumn("");
        headerTable.AddRow("Current context ", $"[grey]{Environment.CurrentDirectory}[/]");
        headerTable.Collapse();
        headerTable.Border = TableBorder.Simple;
        AnsiConsole.Write(headerTable);

        var stepsTable = new Table().LeftAligned();
        stepsTable.AddColumn("[orange1]Select a project[/]");
        Console.WriteLine();
    }
}
