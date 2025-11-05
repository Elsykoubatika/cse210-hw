using System;
using System.Collections.Generic;
using System.IO;

using System.Text.Json;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }

    public void SaveToFile(string fileName)
    {
        try
        {
            string file = fileName;
            using (StreamWriter outputFile = new StreamWriter(file))
            {
                foreach (Entry entry in _entries)
                {
                    outputFile.WriteLine($"{entry._date}, {entry._promptText}, {entry._entryText}");
                    outputFile.WriteLine();
                }
                Console.WriteLine($"Journal saved to file: {file}");
                Console.WriteLine();
            }
        }

        catch (Exception e)
        {
            Console.WriteLine($"Error save text file: {e.Message}");
        }

    }

    public void LoadFromFile(string fileName)
    {
        string file = fileName;
        if (!File.Exists(file))
        {
            Console.WriteLine($"File '{file}' not found");
            return;
        }

        string[] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            string[] parts = line.Split(",");

            if (parts.Length == 3)
            {
                var entry = new Entry
                {
                    _date = parts[0].Trim(),
                    _promptText = parts[1].Trim(),
                    _entryText = parts[2].Trim()
                };
                _entries.Add(entry);
                Console.WriteLine($"Date: {entry._date} - Prompt: {entry._promptText} \n{entry._entryText}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Skipping invalid entry: {line}");
            }
        }
    }

    public void SaveToJson(string fileName)
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true
            };

            string json = JsonSerializer.Serialize(_entries, options);

            File.WriteAllText(fileName, json);
            Console.WriteLine($"Journal saved to JSON file: {fileName}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error saving JSON file: {e.Message}");
        }
    }

    public void LoadFromJson(string fileName)
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine($"File '{fileName}' not found");
            return;
        }

        try
        {
            string json = File.ReadAllText(fileName);

            var options = new JsonSerializerOptions
            {
                IncludeFields = true
            };

            var loaded = JsonSerializer.Deserialize<List<Entry>>(json, options);

            if (loaded != null)
            {
                _entries.AddRange(loaded);
            }

            foreach (var entry in loaded)
            {
                Console.WriteLine($"Date: {entry._date} - Prompt: {entry._promptText} \n{entry._entryText}");
                Console.WriteLine();
            }
            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading JSON file: {ex.Message}");
        }
    }

}