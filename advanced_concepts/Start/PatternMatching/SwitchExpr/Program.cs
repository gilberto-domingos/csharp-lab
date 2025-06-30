// string NumToString(int num) {
//     switch (num) {
//         case 1:
//             return "One";
//         case 2:
//             return "Two";
//         case 3:
//             return "Three";
//         default:
//             return "Unknown";
//     }
// }
// Console.WriteLine(NumToString(2));
// Console.WriteLine(NumToString(4));


// string ShapeToString(object shape) {
//     switch (shape)
//     {
//         case Circle:
//             return "Circle";
//         case Rectangle:
//             return "Rectangle";
//         case Triangle:
//             return "Triangle";
//         default:
//             return "Unknown";
//     }
// }
// Console.WriteLine(ShapeToString(new Circle { Radius = 10 }));
// Console.WriteLine(ShapeToString(new Rectangle { Length = 5, Width = 10 }));



// string ShapeToString2(object shape) => shape switch
// {
//     Circle => "Circle",
//     Rectangle => "Rectangle",
//     Triangle => "Triangle",
//     _ => "Unknown"
// };
// Console.WriteLine(ShapeToString2(new Circle { Radius = 20 }));
// Console.WriteLine(ShapeToString2(new Circle { Radius = 10 }));
// Console.WriteLine(ShapeToString2(new Rectangle { Length = 10, Width = 10 }));
// Console.WriteLine(ShapeToString2(new Rectangle { Length = 5, Width = 10 }));

string ShapeToString3(object shape) => shape switch
{
    Circle {Radius: var r} when r > 10 => "Big Circle",
    Circle {Radius: var r} when r <=10 => "Litle Circle",
    Rectangle {Length: var l, Width: var w} when l == w => "Square",
    Rectangle => "Rectangle",
    Triangle => "Triangle",
    _ => "Unknown"
};

Console.WriteLine(ShapeToString3(new Circle { Radius = 20 }));
Console.WriteLine(ShapeToString3(new Circle { Radius = 10 }));
Console.WriteLine(ShapeToString3(new Rectangle { Length = 10, Width = 10 }));
Console.WriteLine(ShapeToString3(new Rectangle { Length = 5, Width = 10 }));
