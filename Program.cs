
using System.Text.RegularExpressions;

do
{
    Console.WriteLine("Input day");
    switch (Console.ReadLine())
    {
        case "1":
            while (true) Day1();
        case "2":
            while (true) Day2();
        case "3":
            while (true) Day3();
        case "4":
            while (true) Day4();
        default:
            Console.WriteLine("Incorrect input, try again.");
            break;
    };
}
while (true);

void Day4()
{
    Console.WriteLine("Enter input, followed by \"END\"");
    List<List<char>> grid = [];
    var xmasCount = 0;
    var input = Console.ReadLine();
    do
    {
        grid.Add(input.ToList());
        input = Console.ReadLine();
    } while (input != "END");

    for (var i = 0; i < grid.Count; i++)
    {
        var canSearchUp = i >= 3;
        var canSearchDown = i < grid.Count - 3;
        for (var j = 0; j < grid[i].Count; j++)
        {
            var canSearchLeft = j >= 3;
            var canSearchRight = j < grid[i].Count - 3;
            if (grid[i][j] == 'X') //Start checking for XMAS
            {
                if (canSearchUp
                    && grid[i - 1][j] == 'M'
                    && grid[i - 2][j] == 'A'
                    && grid[i - 3][j] == 'S')
                {
                    xmasCount++;
                }

                if (canSearchRight
                    && grid[i][j + 1] == 'M'
                    && grid[i][j + 2] == 'A'
                    && grid[i][j + 3] == 'S')
                {
                    xmasCount++;
                }

                if (canSearchDown
                    && grid[i + 1][j] == 'M'
                    && grid[i + 2][j] == 'A'
                    && grid[i + 3][j] == 'S')
                {
                    xmasCount++;
                }

                if (canSearchLeft
                    && grid[i][j - 1] == 'M'
                    && grid[i][j - 2] == 'A'
                    && grid[i][j - 3] == 'S')
                {
                    xmasCount++;
                }

                if (canSearchUp && canSearchRight
                    && grid[i - 1][j + 1] == 'M'
                    && grid[i - 2][j + 2] == 'A'
                    && grid[i - 3][j + 3] == 'S')
                {
                    xmasCount++;
                }

                if (canSearchUp && canSearchLeft
                    && grid[i - 1][j - 1] == 'M'
                    && grid[i - 2][j - 2] == 'A'
                    && grid[i - 3][j - 3] == 'S')
                {
                    xmasCount++;
                }

                if (canSearchDown && canSearchRight
                    && grid[i + 1][j + 1] == 'M'
                    && grid[i + 2][j + 2] == 'A'
                    && grid[i + 3][j + 3] == 'S')
                {
                    xmasCount++;
                }

                if (canSearchDown && canSearchLeft
                    && grid[i + 1][j - 1] == 'M'
                    && grid[i + 2][j - 2] == 'A'
                    && grid[i + 3][j - 3] == 'S')
                {
                    xmasCount++;
                }
            }
        }
    }

    Console.WriteLine($"PART 1: {xmasCount}");
    Console.WriteLine($"PART 2: ");
}

void Day3()
{
    Console.WriteLine("Enter input, followed by \"END\"");
    int result = 0, result2 = 0;
    var input = Console.ReadLine();
    var enabled = true;
    do
    {
        var matches = MultiplyRegex().Matches(input);
        foreach (var match in matches.ToList())
        {
            if (match.Value == "do()")
            {
                enabled = true;
                continue;
            }
            else if (match.Value == "don't()")
            {
                enabled = false;
                continue;
            }

            var splittedInput = match.Value.TrimStart('m', 'u', 'l', '(').TrimEnd(')').Split(',');

            result += int.Parse(splittedInput[0]) * int.Parse(splittedInput[1]);
            if (enabled)
            {
                result2 += int.Parse(splittedInput[0]) * int.Parse(splittedInput[1]);
            }
        }

        input = Console.ReadLine();
    } while (input != "END");

    Console.WriteLine($"PART 1: {result}");
    Console.WriteLine($"PART 2: {result2}");
}

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

partial class Program
{
    [GeneratedRegex("(?:mul\\(\\d{1,3},\\d{1,3}\\))|(?:do\\(\\))|(?:don't\\(\\))")]
    private static partial Regex MultiplyRegex();
}