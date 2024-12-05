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
}