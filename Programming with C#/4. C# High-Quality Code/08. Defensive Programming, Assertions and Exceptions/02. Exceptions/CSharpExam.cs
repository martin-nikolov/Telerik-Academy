namespace StudentSystem
{
    using System;

    public class CSharpExam : Exam
    {
        public const int MinGrade = 0;
        public const int MaxGrade = 100;

        private int score;

        public CSharpExam(int score)
        {
            this.Score = score;
        }

        public int Score
        {
            get { return this.score; }
            private set
            {
                if (value < MinGrade || value > MaxGrade)
                {
                    throw new ArgumentException(string.Format("Invalid score value. Score must be in range [{0}; {1}]",
                        MinGrade, MaxGrade));
                }

                this.score = value;
            }
        }

        public override ExamResult Check()
        {
            var examResult = new ExamResult(this.Score, MinGrade, MaxGrade, "Exam results calculated by score.");
            return examResult;
        }
    }
}