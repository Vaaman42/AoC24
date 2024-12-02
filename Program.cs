do
{
    Console.WriteLine("Input day");
    switch (Console.ReadLine())
    {
        case "1":
            Day1();
            break;
        case "2":
            Day2();
            break;
        default:
            Console.WriteLine("Incorrect input, try again.");
            break;
    };
}
while (true);

void Day2()
{
    Console.WriteLine("Enter input, followed by \"END\"");
    var safeReportsPart1 = 0;
    var safeReportsPart2 = 0;
    var input = Console.ReadLine();
    do
    {
        List<int> report = [];

        foreach (var levelStr in input.Split(' '))
        {
            report.Add(int.Parse(levelStr));
        }

        if (ProcessReport(report))
        {
            safeReportsPart1++;
            safeReportsPart2++;
        }
        else
        {
            for (var i = 0; i < report.Count; i++)
            {
                var testReport = report.ToList();
                testReport.RemoveAt(i);

                if (ProcessReport(testReport))
                {
                    safeReportsPart2++;
                    break;
                }
            }
        }

        input = Console.ReadLine();
    } while (input != "END");

    Console.WriteLine($"PART 1: {safeReportsPart1}");
    Console.WriteLine($"PART 2: {safeReportsPart2}");
}

bool ProcessReport(List<int> report)
{
    var increasing = report[0] < report[1];

    for (var i = 1; i < report.Count; i++)
    {
        var level = report[i];
        var previousLevel = report[i - 1];

        if (previousLevel == level)
        {
            return false;
        }
        else if (increasing && (previousLevel > level || level - previousLevel > 3))
        {
            return false;
        }
        else if (!increasing && (previousLevel < level || previousLevel - level > 3))
        {
            return false;
        }
    }

    return true;
}

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