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

    public void Desconstruct(out string Name, out int Moons)
    {
        Name = this.Name;
        Moons = this.MoonCount;
    }
    
    public void Desconstruct(out string Name, out int Moons, out int Radius)
    {
        Name = this.Name;
        Moons = this.MoonCount;
        Radius = this.Radius;
    }

    public void Desconstruct(out string name, out int distance)
    {
        name = this.Name;
        distance = this.DistanceFromSunKm;
    }
}
