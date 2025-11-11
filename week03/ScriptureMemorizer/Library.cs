using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;

public class Library
{
    public List<Reference> _references;
    private List<Scripture> _scriptures;
    private readonly Random _random = new Random();
    public Library()
    {
        _references = new List<Reference>();
        _scriptures = new List<Scripture>();
        string filePath = "D:/Cproject/Cours BYU/cse210-hw/week03/ScriptureMemorizer/scripture.txt";
        LoadScripturesFromFile(filePath);
    }

    public void LoadScripturesFromFile(string filePath)
    {
        string file = filePath;
        if (!File.Exists(file))
        {
            Console.WriteLine($"File not found: {file}");
            return;
        }

        string[] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            string[] parts = line.Split('|');

            if (parts.Length == 4)
            {
                var reference = new Reference
                {
                    _Book = parts[0],
                    _Chapter = int.Parse(parts[1]),
                    _StartVerse = int.Parse(parts[2]),
                };
                _references.Add(reference);

                var scripture = new Scripture(reference, parts[3].Trim());
                _scriptures.Add(scripture);
            }
            else
            {
                Console.WriteLine($"Invalid line format (skipped): {line}");
            }
        }
    }

    public Scripture GetRandomScripture()
    {
        if (_scriptures.Count == 0)
        {
            return null;
        }

        int index = _random.Next(_scriptures.Count);
        return _scriptures[index];
    }

    public List<Scripture> GetAllScriptures()
    {
        return _scriptures;
    }

    public string GetDisplayText()
    {
        var displayText = "";
        foreach (var scripture in _scriptures)
        {
            displayText += scripture.GetDisplayText() + "\n";
        }
        return displayText;
    }
}