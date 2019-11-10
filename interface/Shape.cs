using System;

namespace @interface
{
    [Serializable]
    abstract class Shape
    {
        [Serializable]
        protected struct Position
        {
            public int Xpos;
            public int Ypos;
            public Position(int Xpos, int Ypos)
            {
                this.Xpos = Xpos;
                this.Ypos = Ypos;
            }
        }
        [Serializable]
        protected struct Config
        {
            public int Height;
            public int Width;
            public Config(int height, int width)
            {
                Height = height;
                Width = width;
            }
        }
        protected ConsoleColor Color { get; set; }
        protected Position position;
        protected Config config;
        protected int lastPosX;
        protected int lastPosY;
        public Shape() : this(ConsoleColor.Green, 0, 0, 2, 2) { }
        public Shape(ConsoleColor color, int Xpos, int Ypos, int height, int width)
        {
            Color = color;
            if (Xpos < Console.WindowWidth - config.Width - 1 & Ypos < Console.WindowHeight - config.Height - 1)
                position = new Position(Xpos, Ypos);
            else
                throw new Exception();
            if (0 < height & height <= 5 & 0 < width & width <= 5)
                config = new Config(height, width);
            else
                throw new Exception();

            lastPosX = position.Xpos;
            lastPosY = position.Ypos;
        }
    }
}
