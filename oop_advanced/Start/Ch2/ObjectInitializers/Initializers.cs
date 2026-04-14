public class Pet {
    public string Name { get; set; } = "";
    public int Age { get; set; } = 0;

    public Pet() {}
}

public class Dog : Pet {
    public bool IsTrained { get; set; } = false;

    public Dog () {}
}

public class Cat : Pet {
    public bool IsDeclawed { get; set; } = false;

    public Cat () {}
}

public class PetOwner {
    public string Name { get; set; } = "";

    public List<Pet>? Pets { get; set; }
}
