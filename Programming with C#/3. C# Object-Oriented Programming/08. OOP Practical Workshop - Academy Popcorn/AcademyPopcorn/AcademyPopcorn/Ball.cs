using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class Ball : MovingObject
    {
        public new const string CollisionGroupString = "ball";

        public Ball(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, new char[,] { { 'o' } }, speed)
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket" || otherCollisionGroupString == "block";
        }

        public override string GetCollisionGroupString()
        {
            return Ball.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            if (collisionData.CollisionForceDirection.Row * this.Speed.Row < 0)
            {
                this.Speed.Row *= -1;
            }
            if (collisionData.CollisionForceDirection.Col * this.Speed.Col < 0)
            {
                this.Speed.Col *= -1;
            }
        }
    }
}
