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
        var (grid, position, direction) = GetOriginalSetup(filename);

        var result = CountPositions(grid, position, direction);
        return result.count;
    }
    
    public static int Part2(string filename)
    {
        var (grid, startPosition, startDirection) = GetOriginalSetup(filename);

        var result = CountPositions(grid, startPosition, startDirection);

        var total = 0;
        foreach (var visitedPosition in result.visitedPositions)
        {
            if(startPosition == visitedPosition)
            {
                continue;
            }
            
            grid[visitedPosition.x][visitedPosition.y] = true;
            var newResult = CountPositions(grid, startPosition, startDirection);
            if (newResult.count == -1)
            {
                total++;
            }
            grid[visitedPosition.x][visitedPosition.y] = false;
        }
        
        return total;
    }

    private static (bool[][] grid, (int x, int y), Direction direction) GetOriginalSetup(string filename)
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

        return (grid, position, direction);
    }

    private static (int count, IReadOnlyCollection<(int x, int y)> visitedPositions) CountPositions(bool[][] grid, (int x, int y) position, Direction direction)
    {
        var width = grid.Length;
        var height = grid[0].Length;
        
        bool IsInBounds(int x, int y) => x >= 0 && x < width && y >= 0 && y < height;
        
        var positions = new HashSet<(int x, int y)>();
        var states = new HashSet<(int x, int y, Direction direction)>();
        while (IsInBounds(position.x, position.y))
        {
            if(!states.Add((position.x, position.y, direction)))
            {
                return (-1, positions);
            }

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

        return (positions.Count, positions);
    }
}