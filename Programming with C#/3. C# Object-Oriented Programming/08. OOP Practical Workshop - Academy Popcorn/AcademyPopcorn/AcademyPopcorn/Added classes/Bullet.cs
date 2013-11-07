using System;
using System.Linq;

namespace AcademyPopcorn
{
    class Bullet : MovingObject
    {
        /* Exercise: 13 */
        public const char Symbol = '^';

        public Bullet(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { Bullet.Symbol } }, new MatrixCoords(-1, 0))
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return true;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }
    }
}