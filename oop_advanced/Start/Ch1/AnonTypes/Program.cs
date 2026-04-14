var myobj = new
{
    Name = "Joe Marini",
    Age = 45,
    Adress = new
    {
        Street = "123 Main St",
        City = "Any where"
    }
};

  Console.WriteLine($"{myobj.Name}, {myobj.Adress.Street}");
  Console.WriteLine($"{myobj}");
  
  var myobjt2 = myobj with{Name = "Jane Doe"};
  
  Console.WriteLine(myobjt2);
  
  Console.WriteLine($"{myobj.GetType().GetProperty("Name") != null}");
  Console.WriteLine($"{myobj.GetType().GetProperty("Job") != null}");