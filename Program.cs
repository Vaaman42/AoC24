do
{
    Console.WriteLine("Input day");
    switch (Console.ReadLine())
    {
        case "1":
            Day1();
            break;
        default:
            Console.WriteLine("Incorrect input, try again.");
            break;
    };
}
while (true);

void Day1()
{
    Console.WriteLine("Enter input, followed by \"END\"");
    List<int> leftNumbers = [], rightNumbers = [];
    var input = Console.ReadLine();
    do
    {
        var splittedInput = input.Split("   ");
        leftNumbers.Add(int.Parse(splittedInput[0]));
        rightNumbers.Add(int.Parse(splittedInput[1]));
        input = Console.ReadLine();
    }
    while (input != "END");

    leftNumbers = [.. leftNumbers.OrderBy(l => l)];
    rightNumbers = [.. rightNumbers.OrderBy(r => r)];

    var sum = 0;
    var similarity = 0;

    for (var i = 0; i < leftNumbers.Count; i++)
    {
        if (leftNumbers[i].CompareTo(rightNumbers[i]) == 0)
        {

        }
        else if (leftNumbers[i].CompareTo(rightNumbers[i]) > 0)
        {
            sum += leftNumbers[i] - rightNumbers[i];
        }
        else if (leftNumbers[i].CompareTo(rightNumbers[i]) < 0)
        {
            sum += rightNumbers[i] - leftNumbers[i];
        }

        similarity += leftNumbers[i] * rightNumbers.Count(r => r == leftNumbers[i]);
    }

    Console.WriteLine($"PART 1: {sum}");
    Console.WriteLine($"PART 2: {similarity}");
}