using System;

public class Comment
{
    private string _text;
    private string _name;

    public Comment(string text, string name)
    {
        _text = text;
        _name = name;
    }

    public string GetText()
    {
        return _text;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetComment()
    {
        return $"{_name}: {_text}";
    }

}