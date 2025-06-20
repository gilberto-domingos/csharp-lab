
Retangle rect1 = new Retangle(10,20);
Retangle rect2 = new Retangle(30);

Console.WriteLine(rect1.GetArea());
Console.WriteLine(rect2.GetArea());

rect1.BorderSize = 5;
Console.WriteLine($"{rect1.BorderSize}");

rect1.Width = 5;
rect1.Height = 6;
Console.WriteLine(rect1.GetArea());