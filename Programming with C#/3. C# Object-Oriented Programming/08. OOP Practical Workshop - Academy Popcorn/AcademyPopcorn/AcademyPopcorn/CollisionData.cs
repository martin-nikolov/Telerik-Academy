using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class CollisionData
    {
        public readonly MatrixCoords CollisionForceDirection;
        public readonly List<string> hitObjectsCollisionGroupStrings;
       
        public CollisionData(MatrixCoords collisionForceDirection, string objectCollisionGroupString)
        {
            this.CollisionForceDirection = collisionForceDirection;
            this.hitObjectsCollisionGroupStrings = new List<string>();
            this.hitObjectsCollisionGroupStrings.Add(objectCollisionGroupString);
        }

        public CollisionData(MatrixCoords collisionForceDirection, List<string> hitObjectsCollisionGroupStrings)
        {
            this.CollisionForceDirection = collisionForceDirection;

            this.hitObjectsCollisionGroupStrings = new List<string>();

            foreach (var str in hitObjectsCollisionGroupStrings)
            {
                this.hitObjectsCollisionGroupStrings.Add(str);
            }
        }
    }
}
