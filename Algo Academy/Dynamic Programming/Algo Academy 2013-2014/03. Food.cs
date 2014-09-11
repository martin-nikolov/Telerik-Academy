namespace DynamicProgramming
{
    using System;
    using System.Linq;

    public class Product
    {
        public Product(string name, int weight, int cost)
        {
            this.Name = name;
            this.Weight = weight;
            this.Cost = cost;
        }

        public string Name { get; set; }

        public int Weight { get; set; }

        public int Cost { get; set; }
    }

    public class Food
    {
        private static Product[] foods;
        private static int[,] matrix;

        public static void Main()
        {
            int maxFoodCapacity = int.Parse(Console.ReadLine());
            int foodCount = int.Parse(Console.ReadLine());
            foods = ParseInput(foodCount);

            matrix = new int[foodCount + 1, maxFoodCapacity + 1];
            FillMatrix();

            int maxValueColIndex = FindMaxValueIndexInLastRow();
            var maxValueInLastRow = matrix[foodCount, maxValueColIndex];

            Console.WriteLine(maxValueInLastRow);
            PrintChosenFoods(maxValueInLastRow, maxValueColIndex);
        }
     
        private static void FillMatrix()
        {
            for (int row = 1; row < matrix.GetLongLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLongLength(1); col++)
                {
                    int upperValue = matrix[row - 1, col], leftValue = 0;
                    int colIndex = col - foods[row - 1].Weight;
                    if (colIndex >= 0)
                    {
                        leftValue = matrix[row - 1, colIndex] + foods[row - 1].Cost;
                    }

                    matrix[row, col] = Math.Max(upperValue, leftValue);
                }
            }
        }

        private static int FindMaxValueIndexInLastRow()
        {
            int maxValue = int.MinValue, indexOfMaxValue = 0;
            for (int col = 0; col < matrix.GetLongLength(1); col++)
            {
                var cellValue = matrix[matrix.GetLongLength(0) - 1, col];
                if (cellValue > maxValue)
                {
                    maxValue = cellValue;
                    indexOfMaxValue = col;
                }
            }

            return indexOfMaxValue;
        }

        private static void PrintChosenFoods(int maxValue, int maxValueColIndex)
        {
            int currentRow = (int)(matrix.GetLongLength(0) - 1), currentCol = maxValueColIndex;
            int currentValue = maxValue, upperValue = 0;

            while (currentRow > 0 && currentCol > 0)
            {
                upperValue = matrix[currentRow - 1, currentCol];

                if (upperValue != currentValue)
                {
                    Console.WriteLine(foods[currentRow - 1].Name); // The chosen food
                    currentCol -= foods[currentRow - 1].Weight;
                }

                currentValue = matrix[--currentRow, currentCol];
            }
        }

        private static Product[] ParseInput(int foodCount)
        {
            var foods = new Product[foodCount];

            for (int i = 0; i < foodCount; i++)
            {
                var splittedLine = Console.ReadLine().Split(' ');
                foods[i] = new Product(splittedLine[0], int.Parse(splittedLine[1]), int.Parse(splittedLine[2]));
            }

            return foods;
        }
    }
}