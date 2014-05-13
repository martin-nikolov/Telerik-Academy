namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Class provides extension methods for processing and manipulating strings and text information.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Calculate MD5 hash for this string.
        /// </summary>
        /// <param name="input">The string to be encoded.</param>
        /// <returns>The MD5 result checksum of string hashing.</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new StringBuilder to collect the bytes
            // and create a string.
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        /// <summary>
        /// Returns true if this string contains some of the values: "true", "ok", "yes", "1", "да",
        /// otherwise returns false.
        /// </summary>
        /// <param name="input">The string to be checked for existence of positive attitudes.</param>
        /// <returns>A boolean value indicate existence of positive attitudes.</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent
        /// 16-bit signed integer.
        /// </summary>
        /// <param name="input">A string that contains the number to convert.</param>
        /// <returns>A 16-bit signed integer that is equivalent to the number in <paramref name="input"/>,
        /// or 0 (zero) if <paramref name="input"/> is null.</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent
        /// 32-bit signed integer.
        /// </summary>
        /// <param name="input">A string that contains the number to convert.</param>
        /// <returns>A 32-bit signed integer that is equivalent to the number in <paramref name="input"/>,
        /// or 0 (zero) if <paramref name="input"/> is null.</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent
        /// 64-bit signed integer.
        /// </summary>
        /// <param name="input">A string that contains the number to convert.</param>
        /// <returns>A 64-bit signed integer that is equivalent to the number in <paramref name="input"/>,
        /// or 0 (zero) if <paramref name="input"/> is null.</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Converts the specified string representation of a date and time to its
        /// <see cref="T:System.DateTime"/> equivalent and returns a value that indicates
        /// whether the conversion succeeded.
        /// </summary>
        /// <param name="input">A string containing a date and time to convert.</param>
        /// <returns>When this method returns, contains the <see cref="T:System.DateTime"/>
        /// value equivalent to the date and time contained in <paramref name="input"/>, if the
        /// conversion succeeded, or <see cref="F:System.DateTime.MinValue"/> if the conversion
        /// failed. The conversion fails if the <paramref name="input"/> parameter is null, is
        /// an empty string (""), or does not contain a valid string representation of a
        /// date and time.</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Returns a copy of this string with capitalized first letter.
        /// </summary>
        /// <param name="input">The string of which the first letter to be capitalized.</param>
        /// <returns>A string with capitalized first letter if the <paramref name="input"/> 
        /// parameter is not null or empty.</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            string firstCharToUpper = input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture);
            string restChars = input.Substring(1, input.Length - 1);

            return firstCharToUpper + restChars;
        }

        /// <summary>
        /// Returns a part of this string located between two substrings of 
        /// <paramref name="input"/> starting from a specific index.
        /// </summary>
        /// <param name="input">The string from which will be take the substring.</param>
        /// <param name="startString">The startup substring.</param>
        /// <param name="endString">The end substring.</param>
        /// <param name="startFrom">The index from which to start processing in <paramref name="input"/>.</param>
        /// <returns>The substring located between <paramref name="startString"/> and <paramref name="startFrom"/></returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            // Check if startString exists and get start position
            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            // Check if endString exists and get end position
            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Replaces the cyrillic letters with their latin representation.
        /// </summary>
        /// <param name="input">The string which letters must be converts.</param>
        /// <returns>A string which cyrillic letters is replaced with their latin representation.</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };

            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };

            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                string bulgarianLetter = bulgarianLetters[i];
                string latinRepresentationsOfBulgarianLetter = latinRepresentationsOfBulgarianLetters[i];

                input = input.Replace(bulgarianLetter, latinRepresentationsOfBulgarianLetter);
                input = input.Replace(bulgarianLetter.ToUpper(), latinRepresentationsOfBulgarianLetter.ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Replaces the latin letters with their cyrillic representation.
        /// </summary>
        /// <param name="input">The string which letters must be converts.</param>
        /// <returns>A string which latin letters is replaced with their cyrillic representation.</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                string latinLetter = latinLetters[i];
                string bulgarianRepresentationOfLatinLetter = bulgarianRepresentationOfLatinKeyboard[i];

                input = input.Replace(latinLetter, bulgarianRepresentationOfLatinLetter);
                input = input.Replace(latinLetter.ToUpper(), bulgarianRepresentationOfLatinLetter.ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Returns a string of which special symbols are removed and 
        /// cyrillic letters of which is replaced with their latin equivalents.
        /// </summary>
        /// <param name="input">The string to be escaped and normalized.</param>
        /// <returns>An escaped and normalized string.</returns>
        public static string ToValidUsername(this string input)
        {
            string convertedCyrillicToLatin = input.ConvertCyrillicToLatinLetters();

            return Regex.Replace(convertedCyrillicToLatin, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Returns a string of which special symbols are removed and 
        /// cyrillic letters of which is replaced with their latin equivalents.
        /// </summary>
        /// <param name="input">The string to be escaped and normalized.</param>
        /// <returns>An escaped and normalized string.</returns>
        public static string ToValidLatinFileName(this string input)
        {
            string escapedString = input.Replace(" ", "-");
            string convertedCyrillicToLatin = escapedString.ConvertCyrillicToLatinLetters();

            return Regex.Replace(convertedCyrillicToLatin, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Returns the first of number characters of this string.
        /// </summary>
        /// <param name="input">The string of which will be taken the first of number characters.</param>
        /// <param name="charsCount">The number of characters to be taken.</param>
        /// <returns>A string of first <paramref name="charsCount"/> of number characters 
        /// in <paramref name="input"/>.</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Gets the file extension from the file name passed as parameter.
        /// </summary>
        /// <param name="fileName">The string specifying the full file name + extension.
        /// For example: 'picture.jpg'.</param>
        /// <returns>A string specifying the file extension of <paramref name="fileName"/> if it exists.</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Returns the corresponding content type of this string specified file extension.
        /// </summary>
        /// <param name="fileExtension">A string specifies the file extension.</param>
        /// <returns>A string specifies the content type of specific file extension.</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };

            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Converts a set of characters from this string into a sequence of bytes.
        /// </summary>
        /// <param name="input">The string to be converted to array of bytes.</param>
        /// <returns>A byte array containing the specified set of characters.</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
