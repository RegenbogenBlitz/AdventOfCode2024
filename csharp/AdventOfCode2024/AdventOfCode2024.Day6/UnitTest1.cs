namespace AdventOfCode2024.Day6;

public class Tests
{
    [Test]
    public void Part1Example()
    {
        var total = Program.Part1("example1.txt");
        
        Assert.That(total, Is.EqualTo(41));
    }

    [Test]
    public void Part1Solution()
    {
        var total = Program.Part1("input.txt");

        Assert.That(total, Is.EqualTo(4711));
    }
}