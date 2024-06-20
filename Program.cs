const int count = 5;

var randoms = new List<int>(count);
var generator = new Random();
for (int i = 0; i < count; i++)
{
    int value;
    do
    {
        value = generator.Next(100);
    } while (randoms.Contains(value));

    randoms.Add(value);
}

var valuesToGuess = randoms.Order().Select(v => randoms.IndexOf(v) + 1).ToList();

Console.WriteLine("начали");
while (true)
{
    Console.Write(">");
    var input = Console.ReadLine();
    if (input is not { Length: 5 }) continue;
    var hitCount = 0;
    for (int i = 0; i < count; i++)
    {
        var digit = input[i] - 48;
        if (digit == valuesToGuess[i]) hitCount++;
    }

    if (hitCount < count) Console.WriteLine(hitCount + " совпало");
    else
    {
        Console.WriteLine("молодец!");
        break;
    }
}