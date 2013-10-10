using System;
using System.Linq;

class Discipline : ICommentable, IEquatable<Discipline>
{
    private string topic = string.Empty;

    public Discipline(string topic, uint lecturesCount = 0, uint exercisesCount = 0)
    {
        this.Topic = topic;
        this.LecturesCount = lecturesCount;
        this.ExercisesCount = exercisesCount;
    }

    public string Comment { get; set; }

    public string Topic
    {
        get
        {
            return this.topic;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("The Discipline Topic cannot be null or empty!");

            this.topic = value;
        }
    }

    public uint LecturesCount { get; set; }

    public uint ExercisesCount { get; set; }

    public bool Equals(Discipline other)
    {
        return this.Topic.Equals(other.Topic) &&
               this.LecturesCount.Equals(other.LecturesCount) &&
               this.ExercisesCount.Equals(other.ExercisesCount);
    }

    public override string ToString()
    {
        return string.Format("-> Topic: {0}, Number of lectures: {1}, Number of exercises: {2}",
            this.Topic, this.LecturesCount, this.ExercisesCount);
    }
}