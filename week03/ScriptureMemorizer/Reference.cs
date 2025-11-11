using System;

public class Reference
{
    public string _Book;
    public int _Chapter;
    public int _StartVerse;
    public int _EndVerse;

    public Reference()
    {
        _Book = "Jean";
        _Chapter = 0;
        _StartVerse = 0;
        _EndVerse = 0;
    }

    public Reference(string book, int chapter, int verse)
    {
        _Book = book;
        _Chapter = chapter;
        _StartVerse = verse;
        _EndVerse = verse; 
    }

    public Reference(string book, int chapter, int verse, int endverse)
    {
        _Book = book;
        _Chapter = chapter;
        _StartVerse = verse;
        _EndVerse = endverse;
    }

    public static Reference Parse(string reference)
    {
        return new Reference();
    }

    public string GetDisplayText()
    {
        if (_StartVerse == _EndVerse)
        {
            return $"{_Book} {_Chapter}:{_StartVerse}";
        }
        else
        {
            return $"{_Book} {_Chapter}:{_StartVerse}-{_EndVerse}";
        }
    }
}
