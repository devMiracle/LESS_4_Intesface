using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

using @interface.Exeptions;
namespace @interface
{
    [Serializable]
    class Circle : Shape, IShape
    {
        private int radius;
        public int Radius
        {
            get { return radius; }
            set
            {
                if (value > 0 & value > position.Xpos & value > position.Ypos)
                    radius = value;
                else
                    throw new RadiusExeption("значение радиуса вне диапазода допустимых значений");
            }
        }
        private const double PI = 3.14;
        public Circle() : base()
        {
        }
        public Circle(ConsoleColor color, int Xpos, int Ypos, int radius) : base(color, Xpos, Ypos, 1, 1)
        {
            try
            {
                Radius = radius;
            }
            catch (RadiusExeption e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.MyMessage);
                Console.ResetColor();
                Console.ReadKey(true);
                Environment.Exit(0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey(true);
                Environment.Exit(0);
            }
        }
        public double Area()
        {
            return PI * (Radius * Radius);
        }
        public void Dell()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Action<int, int> Write = (xp, yp) => { Console.SetCursorPosition(xp, yp); Console.Write("@"); };
            int centerX = lastPosX + Radius, centerY = lastPosY + Radius, x = -Radius;
            while (x <= radius)
            {
                var y = (int)Math.Floor(Math.Sqrt(Radius * Radius - x * x));

                Write(x + centerX, y + centerY);
                y = -y;
                Write(x + centerX, y + centerY);
                x++;
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
                    if (position.Ypos == Console.WindowHeight - radius * 2 - 1)
                        break;
                    position.Ypos++;
                    break;
                case Direction.left:
                    if (position.Xpos == 0)
                        break;
                    position.Xpos--;
                    break;
                case Direction.Right:
                    if (position.Xpos == Console.WindowWidth - radius * 2 - 1)
                        break;
                    position.Xpos++;
                    break;
                default:
                    break;
            }
        }

        public double Perimeter()
        {
            return 2 * PI * Radius;
        }

        public void Print()
        {
            Console.ForegroundColor = Color;
            Action<int, int> Write = (xp, yp) => { Console.SetCursorPosition(xp, yp); Console.Write("@"); };
            int centerX = position.Xpos + Radius, centerY = position.Ypos + Radius, x = -Radius;
            while (x <= radius)
            {
                var y = (int)Math.Floor(Math.Sqrt(Radius * Radius - x * x));

                Write(x + centerX, y + centerY);
                y = -y;
                Write(x + centerX, y + centerY);
                x++;
            }
            Console.ResetColor();
        }
        public Shape Read(string filePath = "data.dat")
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Circle deserilizePeople;
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                deserilizePeople = (Circle)formatter.Deserialize(fs);
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
    }
}
