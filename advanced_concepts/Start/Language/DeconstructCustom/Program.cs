Planet Earth = new Planet("Earth", 6371, 1, 150_980_000);
Planet Venus = new Planet("Venus", 6052, 0, 108_930_000);

var (name, moons) = Earth;
Console.WriteLine($"{name},{moons}");

var (name, moons) = Venus;
Console.WriteLine($"{name},{moons}");