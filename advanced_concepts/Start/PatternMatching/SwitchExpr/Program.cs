// LinkedIn Learning Course exercise file for Advanced C# Programming by Joe Marini
// C# Pattern Matching using enhanced switch expressions

// switch statements are very common in C#:
string NumToString(int num) {
    switch (num) {
        case 1:
            return "One";
        case 2:
            return "Two";
        case 3:
            return "Three";
        default:
            return "Unknown";
    }
}
Console.WriteLine(NumToString(2));
Console.WriteLine(NumToString(4));

// switch statements can operate on just about any type
// string ShapeToString(object shape) {
// }


// This can be made a little more concise with the switch expression
