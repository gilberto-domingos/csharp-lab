public class MyClass {
    
    private int _someValue = 1;
    public MyClass() {}

    public void Func1() {
        Console.WriteLine("This is Func1");
        _someValue += 1;
    }

    protected void Func2() {
        Console.WriteLine("This is Func2");
        _someValue -= 1;
    }
    
    public int Data {
        get => _someValue;
        set => _someValue = value;
    }
}

    public class DerivedClass : MyClass {
        public DerivedClass() {}

        public void Func3() {
            Console.WriteLine("This is Func3");
            base.Func2();
        }
}
