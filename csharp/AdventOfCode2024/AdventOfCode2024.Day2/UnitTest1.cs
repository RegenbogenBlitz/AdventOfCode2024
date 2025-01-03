namespace AdventOfCode2024.Day2;

public class Tests
{
    [Test]
    public void Part1Example()
    {
        var total = Program.Part1("example1.txt");
        
        Assert.That(total, Is.EqualTo(2));
    }
    
    [Test]
    public void Part1Solution()
    {
        var total = Program.Part1("input.txt");
        
        Assert.That(total, Is.EqualTo(411));
    }   
    
    [Test]
    public void Part2Example()
    {
        var total = Program.Part2("example1.txt");
        
        Assert.That(total, Is.EqualTo(4));
    }
    
    [Test]
    public void Part2Solution()
    {
        var total = Program.Part2("input.txt");
        
        Assert.That(total, Is.EqualTo(465));
    }   
}