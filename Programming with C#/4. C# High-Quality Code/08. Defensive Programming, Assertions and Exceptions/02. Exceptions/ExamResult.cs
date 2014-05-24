namespace StudentSystem
{
    using System;

    public class ExamResult
    {
        private int grade, minGrade, maxGrade;
        private string comments;

        public ExamResult(int grade, int minGrade, int maxGrade, string comments)
        {
            this.MinGrade = minGrade;
            this.MaxGrade = maxGrade;
            this.Grade = grade;
            this.Comments = comments;
        }

        public int Grade
        {
            get { return this.grade; }
            private set
            {
                if (value < this.MinGrade || value > this.MaxGrade)
                {
                    throw new ArgumentException(string.Format("Invalid grade value. Grade must be in range [{0}; {1}]",
                        this.MinGrade, this.MaxGrade));
                }

                this.grade = value;
            }
        }

        public int MinGrade
        {
            get { return this.minGrade; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid minGrade value. MinGrade cannot be less than zero.");
                }

                this.minGrade = value;
            }
        }

        public int MaxGrade
        {
            get { return this.maxGrade; }
            private set
            {
                if (value <= this.MinGrade)
                {
                    throw new ArgumentException("Invalid maxGrade value. MaxGrade must be greater than MinGrade.");
                }

                this.maxGrade = value;
            }
        }

        public string Comments
        {
            get { return this.comments; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Comments cannot be null or empty string.");
                }

                this.comments = value;
            }
        }

        public double CalcExamResultInPercents()
        {
            var examResultPercents = (double)(this.Grade - this.MinGrade) / (this.MaxGrade - this.MinGrade);
            return examResultPercents;
        }
    }
}