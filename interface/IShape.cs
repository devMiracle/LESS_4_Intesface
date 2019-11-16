
namespace @interface
{
    interface IShape : System.IComparable<Shape>
    {
        void Print();
        void Move(Direction direction);
        void Dell();
        double Area();
        double Perimeter();
        void SaveData(string filePath);
        Shape Read(string filePath);
    }
}
