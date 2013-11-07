using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyPopcorn
{
    class Gift : MovingObject
    {
        /* Exercise: 11 */
        public const char Symbol = '♥';

        public Gift(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { Gift.Symbol } }, new MatrixCoords(1, 0))
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString.Equals(Racket.CollisionGroupString);
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            foreach (var collisionItem in collisionData.hitObjectsCollisionGroupStrings)
            {
                if (collisionItem.Equals(Racket.CollisionGroupString))
                {
                    this.IsDestroyed = true;
                }
            }
        }

        public override System.Collections.Generic.IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> racket = new List<GameObject>();

            if (this.IsDestroyed)
                racket.Add(new ShootingRacket(new MatrixCoords(this.topLeft.Row + 1, this.topLeft.Col - 3), 6));

            return racket;
        }
    }
}