namespace Lab5;

public static class Program
{
   public static List<int> FindPatternInText(string pattern, string text)
    {
        List<int> endIndexes = new List<int>();
        int currentTextIndex = pattern.Length - 1;

        while (currentTextIndex < text.Length)
        {
            int currentPatternIndex = pattern.Length - 1;
            string tempMatch = "";

            for (int i = currentTextIndex; i >= currentTextIndex - pattern.Length + 1; i--)
            {
                if (text[i] == pattern[currentPatternIndex])
                {
                    tempMatch = pattern[currentPatternIndex] + tempMatch;
                    if (tempMatch.Length == pattern.Length)
                    {
                        currentTextIndex++;
                        break;
                    }
                }
                else
                {
                    int step = 0;
                    int j = currentPatternIndex;

                    while (j >= 0)
                    {
                        if (text[i] == pattern[j])
                        {
                            step = pattern.Length - tempMatch.Length - j - 1;
                            break;
                        }
                        j--;
                    }

                    if (j == -1)
                    {
                        step = pattern.Length - tempMatch.Length;
                    }

                    currentTextIndex += step;
                    break;
                }

                currentPatternIndex--;
            }

            if (tempMatch == pattern)
            {
                endIndexes.Add(currentTextIndex);
            }
        }

        return endIndexes;
    }

    public static void WriteToFile(List<int> endIndexes, string fileOut, int patternLen, double? timeTaken = null)
    {
        using (StreamWriter file = new StreamWriter(fileOut))
        {
            foreach (int i in endIndexes)
            {
                file.WriteLine("Pattern matched at index {0} to {1}", i - patternLen, i);
            }

            if (timeTaken.HasValue)
            {
                file.WriteLine($"Processing time: {timeTaken.Value}");
            }
        }        
    }
    public static void Main(string[] args)
    {
        string worstPattern = "bbbbbbbbbb";
        string bestPattern = "riteruisdh";
        string avgPattern = "bsbabsbbsb";

        string worstText = File.ReadAllText("D:\\Labs\\algo\\lab5\\lab5\\resourses\\worst_case.txt");
        string bestText = File.ReadAllText("D:\\Labs\\algo\\lab5\\lab5\\resourses\\best_case.txt");
        string avgText = File.ReadAllText("D:\\Labs\\algo\\lab5\\lab5\\resourses\\avg_case.txt");


        string wosrtFileOut = "D:\\Labs\\algo\\lab5\\lab5\\results\\worst_case_result.txt";
        string bestFileOut = "D:\\Labs\\algo\\lab5\\lab5\\results\\best_case_result.txt";
        string avgFileOut = "D:\\Labs\\algo\\lab5\\lab5\\results\\avg_case_result.txt";

        List<int> worstEndIndexes = FindPatternInText(worstPattern, worstText);
        WriteToFile(worstEndIndexes, wosrtFileOut, worstPattern.Length);
        List<int> bestEndIndexes = FindPatternInText(bestPattern, bestText);
        WriteToFile(bestEndIndexes, bestFileOut, bestPattern.Length);
        List<int> avgEndIndexes = FindPatternInText(avgPattern, avgText);
        WriteToFile(avgEndIndexes, avgFileOut, avgPattern.Length);
    }
}