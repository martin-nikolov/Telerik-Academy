using System;
using System.Linq;

namespace AcademyPopcorn
{
    public class Racket : GameObject
    {
        public new const string CollisionGroupString = "racket";

        public Racket(MatrixCoords topLeft, int width)
            : base(topLeft, new char[,] { { '=' } })
        {
            this.Width = width;
            this.body = this.GetRacketBody(this.Width);
        }

        public int Width { get; protected set; }

        public void MoveLeft()
        {
            this.topLeft.Col--;
        }

        public void MoveRight()
        {
            this.topLeft.Col++;
        }

        public override string GetCollisionGroupString()
        {
            return Racket.CollisionGroupString;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block" ||
                   otherCollisionGroupString == Racket.CollisionGroupString || otherCollisionGroupString == "ball";
        }

        public override void Update()
        {
        }

        char[,] GetRacketBody(int width)
        {
            char[,] body = new char[1, width];

            for (int i = 0; i < width; i++)
            {
                body[0, i] = '=';
            }

            return body;
        }
    }
}