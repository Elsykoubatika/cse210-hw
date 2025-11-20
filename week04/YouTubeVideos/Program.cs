using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("A cat playing soccer", "Elsy", 400);
        video1.AddComment(new Comment("waouh cool!", "FK"));
        video1.AddComment(new Comment("it's shame the old voice actor left, really don't like tthis voice", "Jeph"));
        video1.AddComment(new Comment("what if cat play foot ball", "franck"));
        video1.AddComment(new Comment("I don't understand", "japh"));

        Video video2 = new Video("how can i make cakes", "steven", 60);
        video2.AddComment(new Comment("that is the better way very good!", "willie"));
        video2.AddComment(new Comment(" Can i ask sonthing please?", "Sol Hey"));
        video2.AddComment(new Comment("My favorite cake thank you guys", "Tonio"));
        video2.AddComment(new Comment("miam miam", "joseph"));

        Video video3 = new Video("Elder Renlund's historic Momment in Brazzaville", "Danael", 453);
        video3.AddComment(new Comment("i was edified", "miram"));
        video3.AddComment(new Comment("God bless us", "smith"));
        video3.AddComment(new Comment("My campus, i like that place", "Daco"));
        video3.AddComment(new Comment("As young man i'm thankful for this gift", "koko"));

        Video video4 = new Video("15 things that you don't now about Dogs", "Celina", 51);
        video4.AddComment(new Comment("Oh really, thanks brother", "mina"));
        video4.AddComment(new Comment("do think that is true ", "Pedro"));
        video4.AddComment(new Comment("my favorite dog is snopp dogg", "chantal"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);
         
        foreach (Video video in videos)
        {
            video.DisplayVideo();
        }
    }
}