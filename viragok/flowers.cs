using System;

namespace viragok
{
    internal class Flowers
    {
        public string? Name { get; set; }
        public int Price { get; set; }
        public string Color { get; set; }
        public string ImagePath { get; set; }

        public Flowers(string line, string separator)
        {
            string[] data = line.Split(separator);
            Name = data[0];
            Price = int.Parse(data[1]);
            Color = data[2];
            ImagePath = data[3];
        }

        public override string ToString()
        {
            return $"Name: {Name}, Price: {Price}, Color: {Color}";
        }
    }
}
