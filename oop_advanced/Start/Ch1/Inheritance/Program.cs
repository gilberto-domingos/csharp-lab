

Circle c = new Circle(10);
Rectangle r = new Rectangle(10,20);

Square s = new Square(10);

Console.WriteLine($"{c}");
Console.WriteLine($"{r}");

Console.WriteLine($"{c is Shape2D}");
Console.WriteLine($"{c is Rectangle}");

Console.WriteLine(c.GetArea());
Console.WriteLine(r.GetArea());
Console.WriteLine(s.GetArea());

void PrintArea(Shape2D shape)
{
    Console.WriteLine(($"{shape.GetArea()}"));
}

PrintArea(c);
PrintArea(r);
PrintArea(s);