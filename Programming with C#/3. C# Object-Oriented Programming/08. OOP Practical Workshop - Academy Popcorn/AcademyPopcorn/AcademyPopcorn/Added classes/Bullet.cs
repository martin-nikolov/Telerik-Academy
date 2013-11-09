using System;
using System.Linq;
using AcademyPopcorn;

/// <summary>
/// Task 13
/// </summary>
class Bullet : MovingObject
{
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