using System;
using System.Linq;

namespace AcademyPopcorn
{
    class UnstoppableBall : Ball
    {
        /* Exercise: 8 */
        public const char Symbol = 'X';
        public new const string CollisionGroupString = "unstoppableBall";

        public UnstoppableBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            this.body[0, 0] = '@';
        }

        public override string GetCollisionGroupString()
        {
            return UnstoppableBall.CollisionGroupString;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket" || otherCollisionGroupString == "block" ||
                   otherCollisionGroupString == "unpassableBlock";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            foreach (var obj in collisionData.hitObjectsCollisionGroupStrings)
            {
                if (obj.Equals(UnpassableBlock.CollisionGroupString) ||
                    obj.Equals(Racket.CollisionGroupString) || obj.Equals(IndestructibleBlock.CollisionGroupString))
                {
                    base.RespondToCollision(collisionData);
                }
            }
        }
    }
}