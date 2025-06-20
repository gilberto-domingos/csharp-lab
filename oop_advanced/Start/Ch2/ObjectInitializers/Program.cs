Dog dog = new Dog(){Name="Fido", Age = 4, IsTrained = true};
Cat cat = new Cat(){Name = "Mr.Meowington", Age = 7, IsDeclawed = false};

  /*Console.WriteLine($"Dog : {dog.Name}, {dog.Age}");
  Console.WriteLine($"Cat : {cat.Name}, {cat.Age}");*/
  
  var pet = new {Name="Charlie", Age=5};
  //Console.WriteLine($"Pet : {pet.Name}, {pet.Age}");
  
  /*int[] numbers = new int[]{1,2,3,4,5,6};
  Console.WriteLine(numbers.Length);*/
  
  PetOwner owner = new PetOwner
  {
      Name = "Joe Marini",
      Pets = new List<Pet>
      {
          new Dog{Name = "Junebug", Age = 4},
          new Cat{Name = "Wiskers", Age = 3},
          new Dog{Name = "Max", Age = 10}
      }
  };
  
  Console.WriteLine($"{owner.Name}'s Pets : ");
  foreach (Pet p in owner.Pets)
  {
      Console.WriteLine($"{p.Name}");
  }