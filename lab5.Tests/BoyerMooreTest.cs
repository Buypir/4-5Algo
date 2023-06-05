using System.Diagnostics;

public class BoyerMooreTest
{
    private string worstCasePattern = "bbbbbbbbbb";
    private string bestCasePattern = "riteruisdh";
    private string avgCasePattern = "bsbabsbbsb";

    [Fact]
    public void TestBmWorstCase()
    {
        string text = File.ReadAllText("D:\\Labs\\algo\\lab5\\lab5\\Resourses\\WorstCase.txt");

        Stopwatch stopwatch = Stopwatch.StartNew();
        List<int> endIndexes = Lab5.Program.FindPatternInText(worstCasePattern, text);
        stopwatch.Stop();

        Lab5.Program.WriteToFile(endIndexes, "D:\\Labs\\algo\\lab5\\lab5\\Results\\WorstCaseResult.txt", worstCasePattern.Length, stopwatch.Elapsed.TotalMilliseconds);
        Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds}ms - worst case");
    }

    [Fact]
    public void TestBmBestCase()
    {
        string text = File.ReadAllText("D:\\Labs\\algo\\lab5\\lab5\\Resourses\\BestCase.txt");

        Stopwatch stopwatch = Stopwatch.StartNew();
        List<int> endIndexes = Lab5.Program.FindPatternInText(bestCasePattern, text);
        stopwatch.Stop();

        Lab5.Program.WriteToFile(endIndexes, "D:\\Labs\\algo\\lab5\\lab5\\Results\\BestCaseResult.txt", bestCasePattern.Length, stopwatch.Elapsed.TotalMilliseconds);
        Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds}ms - best case");
    }

    [Fact]
    public void TestBmAverageCase()
    {
        string text = File.ReadAllText("D:\\Labs\\algo\\lab5\\lab5\\Resourses\\AvgCase.txt");

        Stopwatch stopwatch = Stopwatch.StartNew();
        List<int> endIndexes = Lab5.Program.FindPatternInText(avgCasePattern, text);
        stopwatch.Stop();

        Lab5.Program.WriteToFile(endIndexes, "D:\\Labs\\algo\\lab5\\lab5\\Results\\AvgCaseResult.txt", avgCasePattern.Length, stopwatch.Elapsed.TotalMilliseconds);
        Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds}ms - average case");
    }
}