namespace AdventOfCode2024;

public static class Program
{
    public static int Part1(string filename)
    {
        var lines = File.ReadAllLines(filename);
        var total = 0;
        
        var height = lines.Length;
        var width = lines[0].Length;
        for(var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            for(var j = 0; j < width; j++)
            {
                var c = line[j];
                if (c == 'X')
                {
                    if (j >= 3 && line[j-1] == 'M' && line[j-2] == 'A' && line[j-3] == 'S')
                    {
                        total++;
                    } 
                    if (width-j > 3 && line[j+1] == 'M' && line[j+2] == 'A' && line[j+3] == 'S')
                    {
                        total++;
                    } 
                    if (i >= 3 && lines[i-1][j] == 'M' && lines[i-2][j] == 'A' && lines[i-3][j] == 'S')
                    {
                        total++;
                    } 
                    if (height-i > 3 && lines[i+1][j] == 'M' && lines[i+2][j] == 'A' && lines[i+3][j] == 'S')
                    {
                        total++;
                    } 
                    if (j >= 3 && i >= 3 && lines[i-1][j-1] == 'M' && lines[i-2][j-2] == 'A' && lines[i-3][j-3] == 'S')
                    {
                        total++;
                    } 
                    if (width-j > 3 && i >= 3 && lines[i-1][j+1] == 'M' && lines[i-2][j+2] == 'A' && lines[i-3][j+3] == 'S')
                    {
                        total++;
                    } 
                    if (j >= 3 && height-i > 3 && lines[i+1][j-1] == 'M' && lines[i+2][j-2] == 'A' && lines[i+3][j-3] == 'S')
                    {
                        total++;
                    } 
                    if (width-j > 3 && height-i > 3 && lines[i+1][j+1] == 'M' && lines[i+2][j+2] == 'A' && lines[i+3][j+3] == 'S')
                    {
                        total++;
                    } 
                }
            }
        }
        
        return total;
    }

    public static int Part2(string filename)
    {
        var lines = File.ReadAllLines(filename);
        var total = 0;

        var height = lines.Length;
        var width = lines[0].Length;
        for (var i = 0; i < height; i++)
        {
            var line = lines[i];
            for (var j = 0; j < width; j++)
            {
                var c = line[j];
                if (c == 'A' && i >= 1 && height - i > 1 && j >= 1 && width - j > 1)
                {
                    var char1 = lines[i - 1][j - 1];
                    var char2 = lines[i - 1][j + 1];
                    var char3 = lines[i + 1][j + 1];
                    var char4 = lines[i + 1][j - 1];
                    if (char1 == 'M' && char2 == 'M' && char3 == 'S' && char4 == 'S')
                    {
                        total++;
                    }
                    else if (char1 == 'S' && char2 == 'M' && char3 == 'M' && char4 == 'S')
                    {
                        total++;
                    }
                    else if (char1 == 'S' && char2 == 'S' && char3 == 'M' && char4 == 'M')
                    {
                        total++;
                    }
                    else if (char1 == 'M' && char2 == 'S' && char3 == 'S' && char4 == 'M')
                    {
                        total++;
                    }
                }
            }
        }

        return total;
    }
}