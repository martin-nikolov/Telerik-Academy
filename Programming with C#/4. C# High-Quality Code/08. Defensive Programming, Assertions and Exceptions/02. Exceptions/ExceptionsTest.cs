namespace StudentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class ExceptionsTest
    {
        static void Main()
        {
            var substr = Utils.Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(substr);

            var subarr = Utils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
            Console.WriteLine(String.Join(" ", subarr));

            var allarr = Utils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
            Console.WriteLine(String.Join(" ", allarr));

            var emptyarr = Utils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
            Console.WriteLine(String.Join(" ", emptyarr));

            Console.WriteLine(Utils.ExtractEnding("I love C#", 2));
            Console.WriteLine(Utils.ExtractEnding("Nakov", 4));
            Console.WriteLine(Utils.ExtractEnding("beer", 4));
            Console.WriteLine(Utils.ExtractEnding("Hi", 100));

            var validPrime = 23;
            var isPrime = Utils.CheckPrime(validPrime);
            Console.WriteLine(validPrime + " is prime: " + isPrime);

            var invalidNumber = -23;
            try
            {
                Utils.CheckPrime(invalidNumber);
                Console.WriteLine(invalidNumber + " is prime.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(invalidNumber + " is not prime. ");
            }

            var peterExams = new List<Exam>()
            {
                new SimpleMathExam(2),
                new CSharpExam(55),
                new CSharpExam(100),
                new SimpleMathExam(1),
                new CSharpExam(0),
            };
            Student peter = new Student("Peter", "Petrov", peterExams);
            var peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
    }
}