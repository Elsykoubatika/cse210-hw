using System;
using System.IO;

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
                Console.WriteLine($"Date: {entry._date} - Prompt: {entry._promptText} \n{entry._entryText}");
            }
        }
    }

}