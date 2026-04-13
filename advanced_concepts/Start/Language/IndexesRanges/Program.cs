string[] words = [
    "The","quick","brown","fox","jumps",
    "over","the","lazy","dog"       
];

Index idx = ^4;
Console.WriteLine(words[idx]);

Console.WriteLine(words[1]);
Console.WriteLine(words[words.Length - 1]);
Console.WriteLine(words[^1]);

Range rng = 3..^1;

string[] WordRange;

 WordRange = words[rng];
Console.WriteLine($"{string.Join(",",WordRange)}");

 WordRange = words[2..5];
Console.WriteLine($"{string.Join(",",WordRange)}");

 WordRange = words[2..];
Console.WriteLine($"{string.Join(",",WordRange)}");

 WordRange = words[..5];
Console.WriteLine($"{string.Join(",",WordRange)}");

 

