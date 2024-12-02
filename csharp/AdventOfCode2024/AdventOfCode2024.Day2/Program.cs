namespace AdventOfCode2024.Day2;

public static class Program
{
    public static int Part1(string filename)
    {
        var totalSafe = 0;
        var lines = File.ReadAllLines(filename);
        foreach (var line in lines)
        {
            var isSafe = true;
            var numbers = line.Split(' ').Select(int.Parse).ToArray();
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
            
            if(isSafe)
            {
                totalSafe++;
            }
        }

        return totalSafe;
    }
}