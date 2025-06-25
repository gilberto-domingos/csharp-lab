(decimal, decimal, decimal) GetStockValues(string ticker) {
    
    if (ticker == "ABCD") {
        return (22.0m, 19.0m, 20.5m);
    }
    else if (ticker == "WXYZ") {
        return (50.0m, 47.0m, 49.25m);
    }
    else {
        return (0,0,0);
    }
}


var result = GetStockValues("ABCD");
Console.WriteLine($"{result.Item1}, {result.Item2}, {result.Item3}");

// mais limpo e legível
var (hight, low, close) = GetStockValues("WXYZ");
Console.WriteLine($"{hight}, {low}, {close}");

decimal cl;
(_,_,cl) = GetStockValues("ABCD");
Console.WriteLine($"{cl}");