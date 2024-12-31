namespace AdventOfCode2024.Day7;

public static class Program
{
    public static long Part1(string filename)
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
                    if (possible + inputs[i] <= target)
                    {
                        nextPossibles.Add(possible + inputs[i]);
                    }
                    
                    if (possible * inputs[i] <= target)
                    {
                        nextPossibles.Add(possible * inputs[i]);
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