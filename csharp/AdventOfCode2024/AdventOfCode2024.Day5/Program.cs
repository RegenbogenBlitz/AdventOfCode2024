namespace AdventOfCode2024.Day5;

public static class Program
{
    public static int Part1(string filename)
    {
        var (_, passingLines, _) = PassingLines(filename);

        var total = 0;
        foreach (var pageNumbers in passingLines)
        {
            var pageCount = pageNumbers.Length;
            var middleIndex = pageCount / 2;
            total += pageNumbers[middleIndex];
        }
        return total;
    }

    public static int Part2(string filename)
    {
        var (rules, _, _failingLines) = PassingLines(filename);

        var total = 0;
        foreach (var failingLine in _failingLines)
        {
            failingLine.Sort(
                (a, b) =>
                {
                    if (rules.ContainsKey(a) && rules[a].Contains(b))
                    {
                        return -1;
                    }

                    if (rules.ContainsKey(b) && rules[b].Contains(a))
                    {
                        return 1;
                    }

                    return 0;
                });
            
            var asArray = failingLine.ToArray();
            var pageCount = asArray.Length;
            var middleIndex = pageCount / 2;
            
            total += asArray[middleIndex];
        }
        
        return total;
    }
    
    private static (Dictionary<int, List<int>> rules, List<int[]> passingLines, List<List<int>> failingLines) PassingLines(string filename)
    {
        var lines = File.ReadAllLines(filename);
        var ruleTexts = lines.Where(l => l.Contains('|'));
        var pageTexts = lines.Where(l => l.Contains(','));

        var rules = new Dictionary<int,List<int>>();
        foreach(var ruleText in ruleTexts)
        {
            var parts = ruleText.Split('|');
            var first = int.Parse(parts[0]);
            var second = int.Parse(parts[1]);

            if (!rules.ContainsKey(first))
            {
                rules[first] = new List<int>();
            }
            rules[first].Add(second);
        }
        
        var passingLines = new List<int[]>();
        var failingLines = new List<List<int>>();
        
        foreach (var pageText in pageTexts)
        {
            var pageNumbers = pageText.Split(',').Select(p=>int.Parse(p)).ToList();
            
            var passes = true;
            for (var i = 0; i < pageNumbers.Count; i++)
            {
                var pageNumber = pageNumbers[i];
                if (rules.ContainsKey(pageNumber))
                {
                    var previousPages = pageNumbers.Take(i).ToList();

                    if (previousPages.Any(p => rules[pageNumber].Contains(p)))
                    {
                        passes = false;
                        break;
                    }
                }
            }

            if (passes)
            {
                passingLines.Add(pageNumbers.ToArray());
            }
            else
            {
                failingLines.Add(pageNumbers);
            }
        }

        return (rules, passingLines, failingLines);
    }
}