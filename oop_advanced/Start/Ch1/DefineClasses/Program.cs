
Retangle rect1 = new Retangle(10,20);
Retangle rect2 = new Retangle(30);

Console.WriteLine(rect1.GetArea());
Console.WriteLine(rect2.GetArea());

rect2.width = 5;;
rect2.height = 7;
Console.WriteLine(rect2.GetArea());