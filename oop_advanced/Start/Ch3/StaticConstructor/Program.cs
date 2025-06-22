MyClass mc = new MyClass();

Console.WriteLine($"CallCounter: {MyClass.CallCounter}");
Console.WriteLine($"LastCaller: {MyClass.LastCaller}");

mc.MethodA();
MyClass.MethodB();
mc.MethodA();
MyClass.MethodB();

Console.WriteLine($"CallCounter: {MyClass.CallCounter}");
Console.WriteLine($"LastCaller: {MyClass.LastCaller}");
