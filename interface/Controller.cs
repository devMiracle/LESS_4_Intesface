using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @interface
{
    class Controller
    {
        IShape shape;
        public Controller(IShape shape)
        {
            this.shape = shape;
        }
        public void Go()
        {
            ConsoleKeyInfo button;
            Console.Clear();
            do
            {
                shape.Print();
                button = Console.ReadKey(true);//ждем нажатие пользователя
                switch (button.Key)
                {
                    case ConsoleKey.Enter:
                        
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.UpArrow:
                        shape.Move(Direction.Up);
                        break;
                    case ConsoleKey.DownArrow:
                        shape.Move(Direction.Down);
                        break;
                    case ConsoleKey.LeftArrow:
                        shape.Move(Direction.left);
                        break;
                    case ConsoleKey.RightArrow:
                        shape.Move(Direction.Right);
                        break;
                            default:
                        break;
                }
                shape.Dell();
            } while (true);
        }
    }
}
