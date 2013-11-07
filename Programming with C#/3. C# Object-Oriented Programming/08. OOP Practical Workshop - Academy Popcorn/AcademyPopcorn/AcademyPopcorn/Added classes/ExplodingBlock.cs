using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyPopcorn
{
    class ExplodingBlock : Block
    {
        /* Exercise: 10 */
        public const char Symbol = '%';
        public new const string CollisionGroupString = "explodingBlock";
        private bool isHit = false;

        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body[0, 0] = ExplodingBlock.Symbol;
        }

        public override string GetCollisionGroupString()
        {
            return ExplodingBlock.CollisionGroupString;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return true;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
            this.isHit = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.isHit)
            {
                List<GameObject> explosions = new List<GameObject>()
                {
                    new Explode(this.TopLeft, new MatrixCoords(-1, 0)),
                    new Explode(this.TopLeft, new MatrixCoords(0, -1)),
                    new Explode(this.TopLeft, new MatrixCoords(1, 0)),
                    new Explode(this.TopLeft, new MatrixCoords(0, 1))
                };

                return explosions;
            }

            return new List<GameObject>();
        }
    }
}