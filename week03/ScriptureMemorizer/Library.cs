using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

public class Library
{
    private List<Reference> _references;
    private List<Scripture> _scriptures;

    public Library()
    {
        _references = new List<Reference>();
        _scriptures = new List<Scripture>();
        string filePath = "scriptures.txt";
        LoadScripturesFromFile(filePath);
    }

    private void LoadScripturesFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"File not found: {filePath}");
            return;
        }

        var lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            var parts = line.Split('|');
            if (parts.Length == 5)
            {
                var reference = new Reference(parts[0], int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]));
                var text = parts[4];
                _references.Add(reference);

                var scripture = new Scripture(reference, text);
                _scriptures.Add(scripture);
            }
        }
    }

}