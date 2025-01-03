namespace AdventOfCode2024.Day2;

public static class Program
{
    public static int Part1(string filename) =>
        File.ReadAllLines(filename)
            .Select(line =>
                line.Split(' ')
                    .Select(int.Parse)
                    .ToArray())
            .Count(SequenceIsSafe);
    
    public static int Part2(string filename) =>
        File.ReadAllLines(filename)
            .Select(line =>
                line.Split(' ')
                    .Select(int.Parse)
                    .ToArray())
            .Count(SequenceIsDampenerSafe);
    
    private static bool SequenceIsSafe(int[] numbers)
    {
        var isSafe = true;
        if(numbers.Length <= 1)
        {
            throw new NotImplementedException();
        }
        var isIncreasing = numbers[1] > numbers[0];
        for (var i = 1; i < numbers.Length; i++)
        {
            var diff = Math.Abs(numbers[i] - numbers[i - 1]);
            if(diff < 1 || diff > 3)
            {
                isSafe = false;
                break;
            }
                
            if(isIncreasing && numbers[i] < numbers[i - 1])
            {
                isSafe = false;
                break;
            }
            else if (!isIncreasing && numbers[i] > numbers[i - 1])
            {
                isSafe = false;
                break;
            }
        }

        return isSafe;
    }
    
    private static bool SequenceIsDampenerSafe(int[] numbers)
    {
        if (SequenceIsSafe(numbers))
        {
            return true;
        }
        
        for(var i = 0; i < numbers.Length; i++)
        {
            var newNumbers = numbers.Take(i).Concat(numbers.Skip(i + 1)).ToArray();
            
            if(SequenceIsSafe(newNumbers))
            {
                return true;
            }
        }
        
        return false;
    }
}