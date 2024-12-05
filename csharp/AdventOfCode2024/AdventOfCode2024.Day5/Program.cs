namespace AdventOfCode2024.Day5;

public static class Program
{
    public static int Part1(string filename)
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

        var total = 0;
        foreach (var pageText in pageTexts)
        {
            var pageNumbers = pageText.Split(',').Select(p=>int.Parse(p)).ToList();
            var pageCount = pageNumbers.Count;
            var middleIndex = pageCount / 2;

            var passes = true;
            for(var i=0; i<pageNumbers.Count; i++)
            {
                var pageNumber = pageNumbers[i];
                if (rules.ContainsKey(pageNumber))
                {
                    var previousPages = pageNumbers.Take(i).ToList();
                    
                    if (previousPages.Any(p=>rules[pageNumber].Contains(p)))
                    {
                        passes = false;
                        break;
                    }
                }
            }
            
            if (passes)
            {
                total+= pageNumbers[middleIndex];
            }
        }
        
        return total;
    }
}