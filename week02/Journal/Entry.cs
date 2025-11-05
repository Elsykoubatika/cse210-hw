using System;
using System.Text.Json;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    internal static Entry Parse(string entryText)
    {
        string[] parts = entryText.Split(',');
        

        if (parts.Length == 3)
        {
            return new Entry
            {
                _date = parts[0],
                _promptText = parts[1],
                _entryText = parts[2],
            };
        }

        throw new NotImplementedException("Entry text is not in the correct format. ");
    }

    public void Display()
    {
        Console.WriteLine($"{_date} {_promptText}\n{_entryText}\n");
    }
}