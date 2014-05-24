namespace StudentSystem
{
    using System;
    using System.Collections.Generic;

    public class SimpleMathExam : Exam
    {
        public const int MinGrade = 2;
        public const int MaxGrade = 6;

        public const int MinProblemsCount = 0;
        public const int MaxProblemsCount = 2;

        private readonly Dictionary<int, KeyValuePair<int, string>> marksByProblemsSolved =
            new Dictionary<int, KeyValuePair<int, string>>()
            {
                { 0, new KeyValuePair<int, string>(2, "Bad result: nothing done.") },
                { 1, new KeyValuePair<int, string>(4, "Average result: something done.") },
                { 2, new KeyValuePair<int, string>(6, "Excellence result: everything done.") }
            };

        private int problemsSolved;

        public SimpleMathExam(int problemsSolved)
        {
            this.ProblemsSolved = problemsSolved;
        }

        public int ProblemsSolved
        {
            get { return this.problemsSolved; }
            private set
            {
                if (value < MinProblemsCount || value > MaxProblemsCount)
                {
                    throw new ArgumentException("Problems solved count has invalid value.");
                }

                this.problemsSolved = value;
            }
        }

        public override ExamResult Check()
        {
            var mark = marksByProblemsSolved[problemsSolved];

            var examResult = new ExamResult(mark.Key, MinGrade, MaxGrade, mark.Value);
            return examResult;
        }
    }
}