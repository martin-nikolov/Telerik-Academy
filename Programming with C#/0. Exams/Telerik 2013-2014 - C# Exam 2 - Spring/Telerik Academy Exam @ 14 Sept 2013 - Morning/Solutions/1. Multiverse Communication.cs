using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
 
class MultiverseCommunication
{
    static List<string> ciphers = new List<string>();
 
    static void Main()
    {
        //  Console.WriteLine('5' - '0');
        string message = Console.ReadLine();
        string mess = string.Empty;
        for (int i = 0; i < message.Length; i++)
        {
            if (char.IsLower(message[i]))
            {
                mess += char.ToUpper(message[i]);
            }
            else
            {
                mess += message[i];
            }
        }
 
        AddCiphersToList();
 
        string hexMessage = Decrypt(mess);
        // Console.WriteLine(hexMessage);
 
        Console.WriteLine(Encrypt(hexMessage));
 
    }
 
    static void AddCiphersToList()
    {
        ciphers = new List<string>() { "CHU", "TEL", "OFT", "IVA", "EMY", "VNB", "POQ", "ERI", "CAD", "K-A", "IIA", "YLO", "PLA" };
    }
 
    static string Decrypt(string message)
    {
        string decryptedMessage = string.Empty;
 
        while (message.Length > 0)
        {
            for (int i = 0; i < ciphers.Count; i++)
            {
                if (message.StartsWith(ciphers[i]))
                {
                    if (i == 10)
                    {
                        decryptedMessage += "A";
                    }
                    else if(i==11)
                    {
                        decryptedMessage += "B";
                    }
                    else if (i == 12)
                    {
                        decryptedMessage += "C";
                    }
                    else
                    {
                        decryptedMessage += i;
                    }
 
                    message = message.Remove(0, ciphers[i].Length);
                }
            }
        }
 
        return decryptedMessage;
    }
 
    static BigInteger Encrypt(string message)
    {
        BigInteger encrypt = 0;
        BigInteger pow = 1;
 
        for (int i = message.Length - 1; i >= 0; i--)
        {
            if (message[i] == 'A')
            {
                encrypt = encrypt + (10 * pow);
            }
            else if (message[i] == 'B')
            {
                encrypt = encrypt + (11 * pow);
            }
            else if (message[i] == 'C')
            {
                encrypt = encrypt + (12 * pow);
            }
            else
            {
                encrypt = encrypt + (ulong)(message[i] - '0') * pow;
            }
 
            pow *= 13;
        }
 
        return encrypt;
    }
}