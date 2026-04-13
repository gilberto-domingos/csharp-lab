StockRecord stock1 = new StockRecord();

Console.WriteLine($"Average: {stock1.Average:C}");
Console.WriteLine($"High: {stock1.High:C}");
Console.WriteLine($"Low: {stock1.Low:C}");

Console.WriteLine($"Days: {stock1.length}");

for (int i = 0; i < stock1.length; i++)
{
    decimal val = stock1[i];
    Console.WriteLine($"Val: {val:c3}");
}

Console.WriteLine($"Val: {stock1["mon"]:C}");
Console.WriteLine($"Val: {stock1["tue"]:C}");
Console.WriteLine($"Val: {stock1["BLA BLA BLÁ"]:C}");