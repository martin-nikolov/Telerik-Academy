/*
* 7. Write a program that encodes and decodes a string using given encryption
* key (cipher). The key consists of a sequence of characters. The encoding/decoding
* is done by performing XOR (exclusive or) operation over the first letter of 
* the string with the first of the key, the second – with the second, etc. 
* When the last key character is reached, the next is the first.
*/

using System;
using System.Linq;
using System.Text;

class EncodingAndDecodingOfWord
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string word = Console.ReadLine(); // Example: Processing

        Console.Write("Enter a KEY (characters on one line - without spaces): ");
        string key = Console.ReadLine(); // Example: ab

        Console.WriteLine("\nEncryption: {0}", Encrypt(word, key));

        Console.WriteLine("\nEncryption + decryption: {0}\n", Decrypt(Encrypt(word, key), key));
    }
  
    static string Encrypt(string word, string key)
    {
        StringBuilder cipher = new StringBuilder();

        for (int i = 0; i < word.Length; i++)
            cipher.Append((char)(word[i] ^ key[i % key.Length]));

        return cipher.ToString();
    }

    static string Decrypt(string word, string key)
    {
        return Encrypt(word, key);
    }
}