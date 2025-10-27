using System;
using System.Collections.Generic;
using System.Linq;

namespace BddBotTest
{
    // Represents a simplified code change (like a PR diff)
    public class CodeChange
    {
        public string FileName { get; set; }
        public List<string> AddedLines { get; set; } = new();
        public List<string> RemovedLines { get; set; } = new();
    }

    // Represents a structured item that a bot can use to generate BDDs
    public class BotInput
    {
        public string FileName { get; set; }
        public string ChangeType { get; set; } // Added, Removed, Modified
        public string MethodName { get; set; }
    }

    public static class BotInputGenerator
    {
        public static List<BotInput> ExtractBotInputs(List<CodeChange> changes)
        {
            var inputs = new List<BotInput>();

            foreach (var change in changes)
            {
                foreach (var line in change.AddedLines)
                {
                    if (line.Trim().StartsWith("public"))
                    {
                        var methodName = line.Split('(')[0].Split(' ').Last();
                        inputs.Add(new BotInput
                        {
                            FileName = change.FileName,
                            ChangeType = "Added",
                            MethodName = methodName
                        });
                    }
                }

                foreach (var line in change.RemovedLines)
                {
                    if (line.Trim().StartsWith("public"))
                    {
                        var methodName = line.Split('(')[0].Split(' ').Last();
                        inputs.Add(new BotInput
                        {
                            FileName = change.FileName,
                            ChangeType = "Removed",
                            MethodName = methodName
                        });
                    }
                }
            }

            return inputs;
        }
    }

    class Program
    {
        static void Main()
        {
            // Example: simulate PR changes
            var changes = new List<CodeChange>
            {
                new CodeChange
                {
                    FileName = "Calculator.cs",
                    AddedLines = new List<string>
                    {
                        "public int Add(int a, int b) { return a + b; }",
                        "public int Subtract(int a, int b) { return a - b; }"
                    },
                    RemovedLines = new List<string>()
                },
                new CodeChange
                {
                    FileName = "Logger.cs",
                    AddedLines = new List<string>(),
                    RemovedLines = new List<string>
                    {
                        "public void Log(string message) { Console.WriteLine(message); }"
                    }
                }
