namespace AdventOfCode2024.Day1;

public static class Program
{
    public static int Part1(string filename)
    {
        var total = 0;
        var lines = File.ReadAllLines(filename);
        var list1 = new List<int>();
        var list2 = new List<int>();
        foreach (var line in lines)
        {
            var numbers = line.Split("   ");
            var firstNumber = int.Parse(numbers[0]);
            var lastNumber = int.Parse(numbers[1]);
            
            list1.Add(firstNumber);
            list2.Add(lastNumber);
        }

        list1.Sort();
        list2.Sort();
        for (var i = 0; i < list1.Count; i++)
        {
            total += Math.Abs(list1[i] - list2[i]);
        }
        
        return total;
    }
}