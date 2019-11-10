using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace @interface
{
    [Serializable]
    class Rectangle : Shape, IShape
    {
        public Rectangle() : base()
        {
        }
        public Rectangle(ConsoleColor color, int Xpos, int Ypos, int height, int width) : base(color, Xpos, Ypos, height, width)
        {
        }
        public double Area()
        {
            return config.Height * config.Width;
        }
        public void Dell()
        {
            Console.SetCursorPosition(lastPosX, lastPosY);
            Console.ForegroundColor = ConsoleColor.Black;
            for (int i = 0; i < config.Height; i++)
            {
                for (int j = 0; j < config.Width; j++)
                {
                    Console.SetCursorPosition(lastPosX + j, lastPosY + i);
                    Console.Write("@");
                }
            }
            Console.ResetColor();
        }
        public void Move(Direction direction)
        {
            lastPosX = position.Xpos;
            lastPosY = position.Ypos;
            switch (direction)
            {
                case Direction.Up:
                    if (position.Ypos == 0)
                        break;
                    position.Ypos--;
                    break;
                case Direction.Down:
                    if (position.Ypos == Console.WindowHeight - config.Height - 1)
                        break;
                    position.Ypos++;
                    break;
                case Direction.left:
                    if (position.Xpos == 0)
                        break;
                    position.Xpos--;
                    break;
                case Direction.Right:
                    if (position.Xpos == Console.WindowWidth - config.Width - 1)
                        break;
                    position.Xpos++;
                    break;
                default:
                    break;
            }
        }
        public double Perimeter()
        {
            return config.Height + config.Height + config.Width + config.Width;
        }
        public void Print()
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(position.Xpos, position.Ypos);
            for (int i = 0; i < config.Height; i++)
            {
                for (int j = 0; j < config.Width; j++)
                {
                    Console.SetCursorPosition(position.Xpos + j, position.Ypos + i);
                    Console.Write("@");
                }
            }
            Console.ResetColor();
        }
        public Shape Read(string filePath = "data.dat")
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Rectangle deserilizePeople;
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                deserilizePeople = (Rectangle)formatter.Deserialize(fs);
            }
            return deserilizePeople;
        }
        public void SaveData(string filePath = "data.dat")
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, this);
                Console.WriteLine("Объект сериализован");
            }
        }
        public int GetAngles()
        {
            return 4;
        }
    }
}
