using @interface.Exeptions;
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
    
   

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "interface";
            Console.WindowLeft = 0;
            Console.WindowTop = 0;
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(50, 25);
            Console.SetBufferSize(50, 25);
            Console.CursorVisible = false;

            //В main создать список указателей на классы наследники.
            List<IShape> shapesList = new List<IShape>();
            shapesList.Add(new Circle(ConsoleColor.Magenta, 0, 0, 2));
            shapesList.Add(new Rectangle(ConsoleColor.Blue, 0, 0, 4, 4));
            shapesList.Add(new Triangle(ConsoleColor.Blue, 0, 0, 3, 3));

            shapesList[0].Print();


            Console.ReadKey(true);
            //Организовать возможность взаимодействия с любой из фигур списка.
            Circle circle = new Circle(ConsoleColor.Magenta, 0, 0, 2);
            Rectangle rectangle = new Rectangle(ConsoleColor.Blue, 0, 0, 4, 4);
            Triangle triangle = new Triangle(ConsoleColor.Blue, 0, 0, 3, 3);
            Controller controller = new Controller(triangle);

            controller.Go();

            Console.ReadKey(true);
        }
    }
}
