using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;


//Интерфейс ФИГУРА
//В котором перечислить следующий методы:
//отрисовать фигуру+
//переместить фигуру+
//стереть фигуру+
//Получить площадь фигуры+
//Получить периметр фигуры
//записать данные о фигуре в файл+
//считать данные из файла+

//Унаследовать от данного интерфейса
//Класс Треугольник
//Класс Прямоугольник
//Класс Окружность

//В данных классах реализовать все методы интерфейса.
//У каждого класса есть поля:
//цвет
//точка начала отрисовки
//Высота и ширина

//у прямоугольника и треугольника есть метод - Вернуть количества углов.

//В main создать список указателей на классы наследники.
//Организовать возможность взаимодействия с любой из фигур списка.


namespace @interface
{
    enum Direction { Up, Down, left, Right }
    
    interface IShape
    {
        void Print(bool isBlack);
        void Move(Direction direction);
        void Dell();
        double Area();
        double Perimeter();
        void SaveData(string filePath);
        Shape Read(string filePath);
    }
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
            position = new Position(Xpos, Ypos);
            config = new Config(height, width);
            lastPosX = position.Xpos;
            lastPosY = position.Ypos;
        }
    }
    [Serializable]
    class Triangle : Shape, IShape
    {
        public Triangle(ConsoleColor color, int Xpos, int Ypos, int height, int width) : base(color, Xpos, Ypos, height, width)
        {
        }
        public double Area()
        {
            return (config.Height * config.Width) / 2;
        }

        public void Dell()
        {
            bool isBlack = true;
            
            Console.SetCursorPosition(lastPosX, lastPosY);
            for (int i = 0; i < config.Height; i++)
            {
                for (int j = 0; j < config.Width; j++)
                {
                    Console.SetCursorPosition(lastPosX + j, lastPosY + i);
                    if (i + 1 > j)
                    {
                        if (isBlack)
                            Console.ForegroundColor = ConsoleColor.Black;
                        else
                            Console.ForegroundColor = Color;
                        Console.Write("@");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("@");
                    }
                }
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.ForegroundColor = ConsoleColor.Black;
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
                    if (position.Ypos == Console.WindowHeight)
                        break;
                    position.Ypos++;
                    break;
                case Direction.left:
                    if (position.Xpos == 0)
                        break;
                    position.Xpos--;
                    break;
                case Direction.Right:
                    if (position.Xpos == Console.WindowWidth)
                        break;
                    position.Xpos++;
                    break;
                default:
                    break;
            }
        }

        public double Perimeter()//TODO: допилить
        {
            double gipo = config.Height * config.Height + config.Width * config.Width;
            gipo = Math.Sqrt(gipo);



                
        }

        public void Print(bool isBlack = false)
        {
            Console.SetCursorPosition(position.Xpos, position.Ypos);
            for (int i = 0; i < config.Height; i++)
            {
                for (int j = 0; j < config.Width; j++)
                {
                    Console.SetCursorPosition(position.Xpos + j, position.Ypos + i);
                    if (i + 1 > j)
                    {
                        if (isBlack)
                            Console.ForegroundColor = ConsoleColor.Black;
                        else
                            Console.ForegroundColor = Color;
                        Console.Write("@");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("@");
                    }
                }
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public Shape Read(string filePath = "data.dat")
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Triangle deserilizePeople;
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                deserilizePeople = (Triangle)formatter.Deserialize(fs);
            }
            return deserilizePeople;
        }


        public void SaveData(string filePath = "data.dat")
        {
            // создаем объект BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, (Triangle)this);

                Console.WriteLine("Объект сериализован");
            }
        }
    }


    class Rectangle : IShape
    {
        public double Area()
        {
            throw new NotImplementedException();
        }

        public void Dell()
        {
            throw new NotImplementedException();
        }

        public void Move(Direction direction)
        {
            throw new NotImplementedException();
        }

        public double Perimeter()
        {
            throw new NotImplementedException();
        }

        public void Print(bool isBlack = false)
        {
            throw new NotImplementedException();
        }

        public Shape Read(string filePath = "data.dat")
        {
            throw new NotImplementedException();
        }

        public void SaveData(string filePath = "data.dat")
        {
            throw new NotImplementedException();
        }
    }



    class Circle : IShape
    {
        public double Area()
        {
            throw new NotImplementedException();
        }

        public void Dell()
        {
            throw new NotImplementedException();
        }

        public void Move(Direction direction)
        {
            throw new NotImplementedException();
        }

        public double Perimeter()
        {
            throw new NotImplementedException();
        }

        public void Print(bool isBlack = false)
        {
            throw new NotImplementedException();
        }

        public Shape Read(string filePath = "data.dat")
        {
            throw new NotImplementedException();
        }

        public void SaveData(string filePath = "data.dat")
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle(ConsoleColor.Blue, 6, 6, 9, 9);
            //triangle.Print();
            //triangle.Dell();
            triangle = ((Triangle)triangle.Read());
            for (int i = 0; i < 5; i++)
            {
                triangle.Print();
                triangle.Move(Direction.Right);
                Thread.Sleep(500);
                triangle.Dell();
            }
            for (int i = 0; i < 5; i++)
            {
                triangle.Print();
                triangle.Move(Direction.Down);
                Thread.Sleep(500);
                triangle.Dell();
            }

            for (int i = 0; i < 20; i++)
            {
                triangle.Print();
                triangle.Move(Direction.left);
                Thread.Sleep(500);
                triangle.Dell();
            }



        }
    }
}
