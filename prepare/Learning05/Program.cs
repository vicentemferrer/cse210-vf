using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square shape1 = new Square("red", 3.45);
        Rectangle shape2 = new Rectangle("blue", 3.45, 10);
        Circle shape3 = new Circle("yellow", 3.45);

        shapes.Add(shape1);
        shapes.Add(shape2);
        shapes.Add(shape3);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape._Color);
            Console.WriteLine(shape.GetArea());
        }
    }
}