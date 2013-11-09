using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public interface ICollidable
    {
        bool CanCollideWith(string objectType);

        List<MatrixCoords> GetCollisionProfile();

        void RespondToCollision(CollisionData collisionData);

        string GetCollisionGroupString();
    }
}
