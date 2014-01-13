using System;
using System.Linq;
using System.Text;
 
class DecodeAndDecrypt
{
    static void Main()
    {
        // Console.WriteLine(1^18);
        StringBuilder decodedMessage = new StringBuilder();
        string cypheredMessage = Console.ReadLine();
 
        string tmp_cipherLength = string.Empty;
        StringBuilder cipher = new StringBuilder();
 
        long cipherLength = 0;
 
        // Get length of the cipher
        for (int i = cypheredMessage.Length - 1; i >= 0; i--)
        {
            if (char.IsDigit(cypheredMessage[i]))
            {
                tmp_cipherLength = cypheredMessage[i] + tmp_cipherLength;
            }
            else
            {
                break;
            }
        }
 
        if (tmp_cipherLength.Length > 0) cipherLength = long.Parse(tmp_cipherLength);
 
        // Console.WriteLine("Cipher length = " + cipherLength);
 
        // Decode -> 5a = aaaaa
        for (int i = 0; i < cypheredMessage.Length - tmp_cipherLength.Length; i++)
        {
            if (char.IsDigit(cypheredMessage[i]))
            {
                string digit = "" + cypheredMessage[i];
 
                //while (char.IsDigit(cypheredMessage[i + 1]))
                //{
 
                //}
 
                // TODO -> for numbers bigger than 9
 
                while (char.IsDigit(cypheredMessage[i + 1]))
                {
                    i++;
                    digit += cypheredMessage[i];
                }
 
                for (int j = 0; j < int.Parse(digit); j++)
                {
                    decodedMessage.Append(cypheredMessage[i + 1]);
                }
 
                i++;
            }
            else
            {
                decodedMessage.Append(cypheredMessage[i]);
            }
        }
 
        StringBuilder decodedMessage_without_cipher = new StringBuilder();
 
        // Get the cipher
        if (cipherLength > 0)
        {
            for (int i = decodedMessage.Length - 1, count = 0; i >= 0; i--, count++)
            {
                if (count < cipherLength) cipher.Append(decodedMessage[i]);
                else decodedMessage_without_cipher.Append(decodedMessage[i]);
            }
        }
 
        // Reverse
        decodedMessage_without_cipher = new StringBuilder(new string(decodedMessage_without_cipher.ToString().Reverse().ToArray()));
        cipher = new StringBuilder(new string(cipher.ToString().Reverse().ToArray()));
 
        //Console.WriteLine(decodedMessage);
        // Console.WriteLine(decodedMessage_without_cipher);
      //  Console.WriteLine(cipher);
 
        StringBuilder encrypted = new StringBuilder();
        if (cipher.Length > decodedMessage_without_cipher.Length)
        {
            for (int i = 0; i < decodedMessage_without_cipher.Length; i++)
            {
                int result = (decodedMessage_without_cipher[i] - 'A') ^ (cipher[i] - 'A');
                if (cipher.Length > decodedMessage_without_cipher.Length)
                {
                    if (decodedMessage_without_cipher.Length + i < cipher.Length)
                    {
                        result = result ^ (cipher[decodedMessage_without_cipher.Length + i] - 'A');
                    }
                }
                encrypted.Append((char)(result + 65));
            }
        }
        else
        {
            for (int i = 0; i < decodedMessage_without_cipher.Length; i++)
            {
                int result = (decodedMessage_without_cipher[i] - 'A') ^ (cipher[i % cipher.Length] - 'A');
 
                encrypted.Append((char)(result + 65));
            }
        }
        Console.WriteLine(encrypted);
    }
}