using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
  
class FeaturingWithGrisko
{
    static StringBuilder result;
    static char[] letters;
    static HashSet<string> answers = new HashSet<string>();
  
    static void Check(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (i > 0 && i + 1 < letters.Length)
            {
                if (letters[arr[i - 1]] == letters[arr[i]] || letters[arr[i + 1]] == letters[arr[i]])
                    return;
            }
            else if (i == 0 && i + 1 < letters.Length)
            {
                if (letters[arr[i]] == letters[arr[i + 1]])
                    return;
            }
            else if (i == letters.Length - 1 && i > 0)
            {
                if (letters[arr[i]] == letters[arr[i - 1]])
                    return;
            }
        }
  
        for (int i = 0; i < letters.Length; i++) result[i] = letters[arr[i]];
  
        answers.Add(result.ToString());
    }
  
    static void Permutation(int[] arr, bool[] used, int i)
    {
        if (i == arr.Length)
        {
            Check(arr);
            return;
        }
  
        for (int j = 0; j < arr.Length; j++)
        {
            if (used[j]) continue;
  
            arr[i] = j;
  
            used[j] = true;
            Permutation(arr, used, i + 1);
            used[j] = false;
        }
    }
  
    static void Main()
    {
        string input = Console.ReadLine();
        letters = new char[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            letters[i] = input[i];
            answers.Add(letters[i].ToString());
        }
  
        if(answers.Count > input.Length)
        {
            Console.WriteLine(0);
            return;
        }
  
        answers.Clear();
  
        int[] arr = new int[input.Length];
        result = new StringBuilder();
        result.Append(new string('-', input.Length));
  
        bool[] used = new bool[arr.Length];
        Permutation(arr, used, 0);
        Console.WriteLine(answers.Count);
    }
}