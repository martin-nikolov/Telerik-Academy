/*
* 12. Write a program that removes from a text file all words listed
* in given another text file. Handle all possible exceptions in your methods.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class RemoveBlackListWords
{
    static List<string> blackList = new List<string>();

    static void Main()
    {
        try
        {
            string pathText = "../../text.txt";
            string pathBlackList = "../../blacklist.txt";
            string pathResult = "../../result.txt";

            GetBlackWords(pathBlackList);
            ExtractTextWithoutTags(pathText, pathResult);
        }
        catch (DriveNotFoundException driveError)
        {
            PrintErrorMessage(driveError);
        }
        catch (DirectoryNotFoundException directoryError)
        {
            PrintErrorMessage(directoryError);
        }
        catch (EndOfStreamException eose)
        {
            PrintErrorMessage(eose);
        }
        catch (FileNotFoundException fnfe)
        {
            PrintErrorMessage(fnfe);
        }
        catch (FileLoadException fle)
        {
            PrintErrorMessage(fle);
        }
        catch (PathTooLongException ptle)
        {
            PrintErrorMessage(ptle);
        }
    }

    static void PrintErrorMessage(Exception error)
    {
        Console.Error.WriteLine("-> Error! {0}\n", error.Message);
    }

    static void GetBlackWords(string pathBlackList)
    {
        using (StreamReader reader = new StreamReader(pathBlackList))
        {
            while (!reader.EndOfStream)
            {
                string[] tokens = reader.ReadLine().Split(new char[] { ' ', ',', '\n' },
                    StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < tokens.Length; i++)
                    if (!blackList.Contains(tokens[i])) blackList.Add(tokens[i]);
            }
        }
    }

    static void ExtractTextWithoutTags(string pathText, string pathResult)
    {
        using (StreamWriter result = new StreamWriter(pathResult))
        {
            using (StreamReader reader = new StreamReader(pathText))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    for (int i = 0; i < blackList.Count; i++)
                        line = Regex.Replace(line, "\\b" + blackList[i] + "\\b", String.Empty);

                    result.WriteLine(line);
                }
            }
        }
    }
}