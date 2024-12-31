namespace AdventOfCode2024.Day7;

public class Tests
{
    [Test]
    public void Part1Example()
    {
        var total = Program.Part1("example1.txt");
        
        Assert.That(total, Is.EqualTo(3749));
    }

    [Test]
    public void Part1Solution()
    {
        var total = Program.Part1("input.txt");

        Assert.That(total, Is.EqualTo(10741443549536));
    }
    
    [Test]
    public void Part2Example()
    {
        var total = Program.Part2("example1.txt");
        
        Assert.That(total, Is.EqualTo(11387));
    }

    [Test]
    public void Part2Solution()
    {
        var total = Program.Part2("input.txt");

        Assert.That(total, Is.EqualTo(500335179214836));
    }
}