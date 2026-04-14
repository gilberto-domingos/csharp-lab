public abstract class Vehicle
{
    public Vehicle() {}

    public string? Model {
        get;
        init;
    }

    public string? Make {
        get;
        init;
    }

    public virtual void SoundHorn() {
        Console.WriteLine("Add horn sound here");
    }

    public override string ToString() {
        return $"{GetType()}: {Make} {Model}";
    }
}

// Declare sublasses that inherit from the abstract class
public class Car : Vehicle
{
    public Car() {
    }
    public override void SoundHorn()
    {
        Console.WriteLine("Beep Beep");
    }
}

public class Motorcycle : Vehicle
{
    public Motorcycle() {
    }

    
}
