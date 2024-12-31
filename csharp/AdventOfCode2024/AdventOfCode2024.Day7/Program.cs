namespace AdventOfCode2024.Day7;

public static class Program
{
    public static long Part1(string filename)
    {
        return Calculate(filename, false);
    }
    
    public static long Part2(string filename)
    {
        return Calculate(filename, true);
    }

    public static long Calculate(string filename, bool hasConcatOperator)
    {
        var lines = File.ReadAllLines(filename);

        long total = 0;
        foreach (var line in lines)
        {
            var parts = line.Split(": ");
            var target = long.Parse(parts[0]);
            var inputs = parts[1].Split(" ").Select(long.Parse).ToArray();
            
            var possibles = new List<long>();
            possibles.Add(inputs.First());
            var nextPossibles = new List<long>();
            for (var i = 1; i < inputs.Length; i++)
            {
                foreach(var possible in possibles)
                {
                    var sum = possible + inputs[i];
                    if (sum <= target)
                    {
                        nextPossibles.Add(sum);
                    }
                    
                    var product = possible * inputs[i];
                    if (product <= target)
                    {
                        nextPossibles.Add(product);
                    }
                    
                    if (hasConcatOperator)
                    {
                        var concat = long.Parse(possible.ToString() + inputs[i].ToString());
                        if (hasConcatOperator && concat <= target)
                        {
                            nextPossibles.Add(concat);
                        }
                    }
                }
                possibles = nextPossibles;
                nextPossibles = new List<long>();
            }

            if (possibles.Any(p=> p == target))
            {
                total+= target;
            }
        }
        return total;
    }
}