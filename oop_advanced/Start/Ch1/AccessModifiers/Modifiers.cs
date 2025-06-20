public class MyClass {
    public MyClass() {}

    public void Func1() {
        Console.WriteLine("This is Func1");
        SomeValue += 1;
    }

    protected void Func2() {
        Console.WriteLine("This is Func2");
        SomeValue -= 1;
    }

    private int SomeValue = 1;

    
    public int Data {
        get => SomeValue;
        set => SomeValue = value;
    }
}

public class DerivedClass : MyClass {
    public DerivedClass() {}

    public void Func3() {
        Console.WriteLine("This is Func3");
        base.Func2();
    }
}
