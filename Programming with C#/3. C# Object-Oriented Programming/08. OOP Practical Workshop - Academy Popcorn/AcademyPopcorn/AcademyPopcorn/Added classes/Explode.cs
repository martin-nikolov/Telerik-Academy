using System;
using System.Linq;
using AcademyPopcorn;

/// <summary>
/// Task 10
/// </summary>
class Explode : MovingObject
{
    public const char Symbol = '+';

    public Explode(MatrixCoords topLeft, MatrixCoords speed)
        : base(topLeft, new char[,] { { Explode.Symbol } }, speed)
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