namespace DataStructuresAndAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Frames
    {
        private const int MaximalFramesCount = 6;
        private static readonly bool[] used = new bool[MaximalFramesCount];
        private static readonly int[] permutations = new int[MaximalFramesCount];

        private static int numberOfFrames;
        private static readonly Frame[] frames = new Frame[MaximalFramesCount];
        private static readonly ISet<string> uniqueFrames = new SortedSet<string>();

        internal static void Main()
        {
            #if DEBUG
                Console.SetIn(new System.IO.StreamReader("../../input.txt"));
            #endif

            ParseInput();
            PermutationsWithoutReps();
            PrintAnswer();
        }
 
        private static void ParseInput()
        {
            numberOfFrames = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfFrames; i++)
            {
                var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                frames[i] = new Frame(numbers[0], numbers[1]);
            }
        }

        private static void PermutationsWithoutReps(int index = 0)
        {
            if (index >= numberOfFrames)
            {
                var currentFrames = GetFramePermutation();
                SaveFramePermutation(currentFrames);
                FlipFrames(currentFrames, 0);
                return;
            }

            for (int i = 0; i < numberOfFrames; i++)
            {
                if (used[i])
                {
                    continue;
                }

                used[i] = true;
                permutations[index] = i;
                PermutationsWithoutReps(index + 1);
                used[i] = false;
            }
        }

        private static void FlipFrames(Frame[] framesToFlip, int index)
        {
            if (index == numberOfFrames)
            {
                return;
            }

            // Swap values
            framesToFlip[index] = new Frame(framesToFlip[index].SecondValue, framesToFlip[index].FirstValue);
            FlipFrames(framesToFlip, index + 1);

            SaveFramePermutation(framesToFlip);

            // Swap values again - recover to original frame
            framesToFlip[index] = new Frame(framesToFlip[index].SecondValue, framesToFlip[index].FirstValue);
            FlipFrames(framesToFlip, index + 1);
        }

        private static void SaveFramePermutation(Frame[] framesToFlip)
        {
            uniqueFrames.Add(string.Join(" | ", framesToFlip));
        }

        private static Frame[] GetFramePermutation()
        {
            var currentFrames = new Frame[numberOfFrames];

            for (int i = 0; i < numberOfFrames; i++)
            {
                currentFrames[i] = frames[permutations[i]];
            }

            return currentFrames;
        }

        private static void PrintAnswer()
        {
            Console.WriteLine(uniqueFrames.Count);
            foreach (var frame in uniqueFrames)
            {
                Console.WriteLine(frame);
            }
        }
    }

    public struct Frame
    {
        public Frame(int firstValue, int secondValue)
            : this()
        {
            this.FirstValue = firstValue;
            this.SecondValue = secondValue;
        }

        public int FirstValue { get; set; }

        public int SecondValue { get; set; }

        public override string ToString()
        {
            return string.Format("({0}, {1})", this.FirstValue, this.SecondValue);
        }
    }
}