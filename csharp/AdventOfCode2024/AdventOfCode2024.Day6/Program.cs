namespace AdventOfCode2024.Day6;

public static class Program
{
    private enum Direction
    {
        Up,
        Right,
        Down,
        Left
    }
    
    public static int Part1(string filename)
    {
        var lines = File.ReadAllLines(filename);

        var height = lines.Length;
        var width = lines[0].Length;

        var grid = new bool[width][];
        var position = (x: 0, y: 0);
        var direction = Direction.Up;
        
        for(var x = 0; x < width; x++)
        {
            grid[x] = new bool[height];
            for(var y = 0; y < height; y++)
            {
                grid[x][y] = lines[y][x] == '#';
                
                if (lines[y][x] == '^')
                {
                    position = (x, y);
                }
            }
        }

        bool IsInBounds(int x, int y) => x >= 0 && x < width && y >= 0 && y < height;
        
        var positions = new HashSet<(int x, int y)>();
        while (IsInBounds(position.x, position.y))
        {
            positions.Add(position);
            switch (direction)
            {
                case Direction.Up:
                    if (IsInBounds(position.x, position.y - 1) && grid[position.x][position.y - 1])
                    {
                        direction = Direction.Right;
                    }
                    else
                    {
                        position = (position.x, position.y - 1);
                    }

                    break;
                
                case Direction.Right:
                    if(IsInBounds(position.x + 1, position.y) && grid[position.x + 1][position.y])
                    {
                        direction = Direction.Down;
                    }
                    else
                    {
                        position = (position.x + 1, position.y);
                    }
                    
                    break;
                
                case Direction.Down:
                    if(IsInBounds(position.x, position.y + 1) && grid[position.x][position.y + 1])
                    {
                        direction = Direction.Left;
                    }
                    else
                    {
                        position = (position.x, position.y + 1);
                    }
                    
                    break;
                
                case Direction.Left:
                    if(IsInBounds(position.x - 1, position.y) && grid[position.x - 1][position.y])
                    {
                        direction = Direction.Up;
                    }
                    else
                    {
                        position = (position.x - 1, position.y);
                    }

                    break;
                
                default:
                    throw new Exception("Invalid direction");
            }
        }

        return positions.Count;
    }
}