/*
 * Algo Academy February 2013 – Problem 04 – Salaries
 * http://bgcoder.com/Contests/Practice/Index/63#0
 */

using System;
using System.Collections.Generic;
using System.IO;

namespace AlgoAcademy
{
    /// <summary>
    /// Using adjancency list and recursively DFS
    /// </summary>
    class Salaries
    {
        static readonly IDictionary<int, List<int>> adjacencyList = new Dictionary<int, List<int>>();
        static long[] employees;

        static void Main()
        {
            #if DEBUG 
                Console.SetIn(new StreamReader("../../input.txt"));
            #endif

            ParseInput();

            var totalSalary = CalculateTotalSalary();

            Console.WriteLine("Total salary: " + totalSalary);
        }

        static void ParseInput()
        {
            var n = int.Parse(Console.ReadLine());
            employees = new long[n];

            for (int i = 0; i < n; i++)
            {
                var inputLine = Console.ReadLine();
                adjacencyList[i] = new List<int>();

                for (int j = 0; j < n; j++)
                    if (inputLine[j] == 'Y')
                        adjacencyList[i].Add(j);

                if (adjacencyList[i].Count == 0)
                    employees[i] = 1;
            }
        }

        static long CalculateTotalSalary()
        {
            long totalSalary = 0;

            for (int i = 0; i < employees.Length; i++)
                totalSalary += Calculate(i);

            return totalSalary;
        }

        static long Calculate(int employeeId)
        {
            if (employees[employeeId] != 0)
                return employees[employeeId];

            foreach (var employee in adjacencyList[employeeId])
                employees[employeeId] += Calculate(employee);

            return employees[employeeId];
        }
    }
}