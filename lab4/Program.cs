using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static int GetMaxChainLength(List<string> words)
    {
        words.Sort((a, b) => a.Length.CompareTo(b.Length));

        Dictionary<string, int> dictionary = new Dictionary<string, int>();

        foreach (string word in words)
        {
            dictionary[word] = 1;

            for (int i = 0; i < word.Length; i++)
            {
                string modifiedWord = word.Remove(i, 1);

                if (dictionary.ContainsKey(modifiedWord) && dictionary[modifiedWord] + 1 > dictionary[word])
                {
                    dictionary[word] = dictionary[modifiedWord] + 1;               
                }
            }
            
        }

        return dictionary.Values.Max(); 
    }

    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("D:\\Labs\\algo\\lab4\\lab4\\wchain.in");
        int N = int.Parse(lines[0]);
        List<string> words = new List<string>(lines[1..]);

        int maxChainLength = GetMaxChainLength(words);

        File.WriteAllText("D:\\Labs\\algo\\lab4\\lab4\\wchain.out", maxChainLength.ToString());
    }
}