using System;
using System.Linq;

namespace AcademyPopcorn
{
    class Explode : MovingObject
    {
        public Explode(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, new char[,] { { '+' } }, speed)
        {
        }

        public override void Update()
        {
            base.Update();
            this.IsDestroyed = true;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString.Equals(Ball.CollisionGroupString);
        }

        public override string GetCollisionGroupString()
        {
            return Ball.CollisionGroupString;
        }
    }
}