using System;
using System.Text.RegularExpressions;

int calValSum = 0;
foreach (var line in File.ReadLines(args[0]))
{
    Match matchFirst = Regex.Match(line, "^[^0-9]*([0-9])");
    Match matchLast = Regex.Match(line, "([0-9])[^0-9]*$");
    if (matchFirst.Success)
    {
        string calValue = matchFirst.Groups[1].Value + matchLast.Groups[1].Value;
        calValSum += Convert.ToInt32(calValue);
    }
}
Console.WriteLine(calValSum);

Dictionary<string, string> digits = new()
{
    ["one"] = "1",
    ["two"] = "2",
    ["three"] = "3",
    ["four"] = "4",
    ["five"] = "5",
    ["six"] = "6",
    ["seven"] = "7",
    ["eight"] = "8",
    ["nine"] = "9"
};

calValSum = 0;
foreach (var line in File.ReadLines(args[0]))
{
    string numMatch = "([0-9]|one|two|three|four|five|six|seven|eight|nine)";
    Match matchFirst = Regex.Match(line, "^.*?" + numMatch);
    Match matchLast = Regex.Match(line, ".*" + numMatch + ".*$");
    if (matchFirst.Success)
    {
        string calVal = "";
        string firstDigit = matchFirst.Groups[1].Value;
        string lastDigit = matchLast.Groups[1].Value;
        try
        {
            calVal += digits[firstDigit];
        }
        catch (KeyNotFoundException)
        {
            calVal += firstDigit;
        }
        try
        {
            calVal += digits[lastDigit];
        }
        catch (KeyNotFoundException)
        {
            calVal += lastDigit;
        }
        calValSum += Convert.ToInt32(calVal);
    }
}
Console.WriteLine(calValSum);

