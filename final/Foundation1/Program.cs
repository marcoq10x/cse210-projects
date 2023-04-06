using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        List<Video> videos = new List<Video>
        {
            new Video
            {
                _title = "Video 1",
                _author = "Juan Rodriguez",
                _length = 120,
                _comments = new List<Comment>
                {
                    new Comment { _name = "Akira Saito", _text = "Great video!" },
                    new Comment { _name = "Oleg Kuznetsov", _text = "Very informative." },
                    new Comment { _name = "Alice Smith", _text = "Interesting content." },
                    new Comment { _name = "Sophie Dubois", _text = "Awesome video!" },
                }
            },
            new Video
            {
                _title = "Video 2",
                _author = "Chen Li",
                _length = 180,
                _comments = new List<Comment>
                {
                    new Comment { _name = "Carlos Silva", _text = "Loved it!" },
                    new Comment { _name = "Eva Müller", _text = "Amazing content." },
                    new Comment { _name = "Kim Jisoo", _text = "Keep up the good work!" },
                    new Comment { _name = "Mia Johnson", _text = "Subscribed!" },
                }
            },
            new Video
            {
                _title = "Video 3",
                _author = "Ankur Patel",
                _length = 240,
                _comments = new List<Comment>
                {
                    new Comment { _name = "Nina Ivanova", _text = "This is so cool!" },
                    new Comment { _name = "Leonardo Rossi", _text = "Very well explained." },
                    new Comment { _name = "Rebecca Garcia", _text = "I learned a lot!" },
                    new Comment { _name = "Tom Jackson", _text = "Impressive!" },
                }
            },
            new Video
            {
                _title = "Video 4",
                _author = "Olivia Brown",
                _length = 300,
                _comments = new List<Comment>
                {
                    new Comment { _name = "Youssef El Amrani", _text = "This video is fantastic!" },
                    new Comment { _name = "Zoe O'Sullivan", _text = "You've earned a new subscriber." },
                    new Comment { _name = "Anastasia Petrova", _text = "This is a must-watch!" },
                    new Comment { _name = "Samuel Adams", _text = "Brilliant!" },
                }
            },
        };

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video._comments)
            {
                Console.WriteLine($"- {comment._name}: {comment._text}");
            }

            Console.WriteLine();
        }
    }


public class Video
{
    public string _title { get; set; }
    public string _author { get; set; }
    public int _length { get; set; }
    public List<Comment> _comments { get; set; }

    public Video()
    {
        _comments = new List<Comment>();
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }
}

public class Comment
{
    public string _name { get; set; }
    public string _text { get; set; }
}


}
