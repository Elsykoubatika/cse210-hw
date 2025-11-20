using System;
using System.Transactions;

public class Video
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public string GetTitle()
    {
        return _title;
    }

    public string GetAuthor()
    {
        return _author;
    }

    public int GetLength()
    {
        return _length;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetNumberofComment()
    {
        return _comments.Count;
    }

    public List<Comment> GetComment()
    {
        return _comments;
    }

    public string GetVideo()
    {
        return $"'{_title}', by {_author} ({_length}second)";
    }
    
    public void DisplayVideo()
    {
        Console.WriteLine(GetVideo());
        Console.WriteLine($"Number of comments: {GetNumberofComment()}");
        
        foreach(Comment comment in GetComment())
        {
            Console.WriteLine($"{comment.GetComment()}");
        }
        Console.WriteLine();
    }
}