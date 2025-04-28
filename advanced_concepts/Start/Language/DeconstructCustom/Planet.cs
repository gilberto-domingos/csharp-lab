// LinkedIn Learning Course exercise file for Advanced C# Programming by Joe Marini
// Using Deconstruction on a custom defined type

public class Planet
{
    public string Name { get; set; }
    public int Radius { get; set; }
    public int MoonCount { get; set; }
    public int DistanceFromSunKm { get; set; }

    public Planet(string name, int rads, int moons, int distance ) {
        Name = name;
        Radius = rads;
        MoonCount = moons;
        DistanceFromSunKm = distance;
    }

    // Define a Deconstruct method to return the name and moon count


    // Define a Deconstruct method to return the name, moon count, and radius


    // Defining a Deconstruct with the name number of parameters will cause an error
}
