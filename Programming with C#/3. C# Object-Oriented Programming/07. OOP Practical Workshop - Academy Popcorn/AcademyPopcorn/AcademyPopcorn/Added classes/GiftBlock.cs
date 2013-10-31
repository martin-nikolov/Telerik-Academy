using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyPopcorn
{
    class GiftBlock : Block
    {
        /* Exercise: 12 */
        public const char Symbol = '\u25A0';

        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body[0, 0] = Symbol;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return true;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override System.Collections.Generic.IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed)
            {
                return new GameObject[1] { new Gift(this.TopLeft) };
            }

            return new List<GameObject>();
        }
    }
}