public class MyClass {
    public static long CallCounter;
    public static string LastCaller;

    static MyClass()
    {
        CallCounter = 0;
        LastCaller = "Nobody";
        Console.WriteLine("Static constructor has been called");
    }


    public MyClass() {
        Console.WriteLine("Regular constructor has been called");
    }

    public void MethodA() {
        CallCounter++;
        LastCaller = "MethodA";
    }

    public static void MethodB () {
        CallCounter++;
        LastCaller = "MethodB";
    }
}
