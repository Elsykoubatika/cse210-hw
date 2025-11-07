using System;

public class Scripture
{   
    private Reference _reference;
    private List<Word> _words;
    private static readonly Random _rand = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] wordsArray = text.Split(' ');

        foreach (string word in wordsArray)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    
    {
        

        List<int> availablewords = new List<int>();

        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                availablewords.Add(i);
            }
        }

        if (availablewords.Count == 0)
        {
            return;
        }

        if (numberToHide > availablewords.Count)
        {
            numberToHide = availablewords.Count;
        }

        for (int i = 0; i < numberToHide; i++)
        {
            int randomPosInList = _rand.Next(availablewords.Count);
            int wordIndex = availablewords[randomPosInList];

            _words[wordIndex].Hide();
            availablewords.RemoveAt(randomPosInList);
        }
    }
    public string GetDisplayText()
    {
        string referenceText = _reference.GetDisplayText();
        string scriptureText = "";

        foreach (Word word in _words)
        {
            scriptureText += word.GetDisplayText() + " ";
        }

        return $"{referenceText}: {scriptureText}";
    }
    
    public bool IsCompletelyHidden()
    {

        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }

}