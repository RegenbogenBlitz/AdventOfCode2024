using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day3;

public static class Program
{
    public static int Part1(string filename)
    {
        var text = File.ReadAllText(filename);
        return GetMulTotal(text);
    }
    
    public static int Part2(string filename)
    {
        var text = File.ReadAllText(filename);
        
        var total = 0;
        var doSplits = text.Split("do()");
        foreach (var doSplit in doSplits)
        {
            var dontSplits = doSplit.Split("don't()");
            total += GetMulTotal(dontSplits[0]);
        }
        return total;
    }

    private static int GetMulTotal(string text)
    {
        var regex = new Regex(@"mul\([0-9]+\,[0-9]+\)");
        
        var total = 0;
        var matches = regex.Matches(text);
        foreach (var match in matches)
        {
            var matchText = match.ToString();
            var stripped = matchText.Replace("mul(", "").Replace(")", "");
            var parts = stripped.Split(",");
            var a = int.Parse(parts[0]);
            var b = int.Parse(parts[1]);
            total += a * b;
        }
        
        return total;
    }
}