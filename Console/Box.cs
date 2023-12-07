using System;

namespace Console
{
    public class Box
    {
        public int Id { get; }
        public string Title { get; }
        public string Content { get; }
        public float X { get; set; } 
        public float Y { get; set; } 

        public Box(int id, string title, string content)
        {
            Id = id;
            Title = title;
            Content = content;
            X = 0; 
            Y = 0; 
        }
    }
}
