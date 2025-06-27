#pragma warning disable CS8321

string? str = "no null";

if (str is null)
    ArgumentNullException.ThrowIfNull(str);

Console.WriteLine($"{str}");

void DashedLine(object o)
{
    int l1 = 0;

    if (o.GetType() == typeof(int))
    {
        l1 = (int)o;
    }

    string? s1 = null;
    if (o.GetType() == typeof(string))
    {
        s1 = (string)o;
        if (!int.TryParse(s1, out l1))
        {
            l1 = 0;
        }
    }

    if (l1 > 0)
    {
        string str1 = new string('-', l1);
        Console.WriteLine(str1);
    }

    if (o is int l2 || (o is string s2 && int.TryParse(s2, out l2)))
    {
        string str2 = new string('-', l2);
        Console.WriteLine(str2);
    }
}

DashedLine(25);
DashedLine("50");
DashedLine(20.5);

bool IsTheIdesOfMarch(DateTime date)
{
    return date is { Month: 3, Day: 14 or 15 };
}

Console.WriteLine(IsTheIdesOfMarch(new DateTime(DateTime.Today.Year, 1, 13)));
Console.WriteLine(IsTheIdesOfMarch(new DateTime(DateTime.Today.Year, 3, 14)));
Console.WriteLine(IsTheIdesOfMarch(new DateTime(DateTime.Today.Year, 3, 15)));
Console.WriteLine(IsTheIdesOfMarch(new DateTime(DateTime.Today.Year, 3, 16)));