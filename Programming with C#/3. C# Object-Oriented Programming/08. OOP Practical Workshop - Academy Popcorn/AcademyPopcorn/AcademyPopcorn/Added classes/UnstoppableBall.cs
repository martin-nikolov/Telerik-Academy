using System;
using System.Linq;
using AcademyPopcorn;

/// <summary>
/// Task 8
/// </summary>
class UnstoppableBall : Ball
{
    public const char Symbol = '@';
    public new const string CollisionGroupString = "unstoppableBall";

    public UnstoppableBall(MatrixCoords topLeft, MatrixCoords speed)
        : base(topLeft, speed)
    {
        this.body[0, 0] = UnstoppableBall.Symbol;
    }

    public override bool CanCollideWith(string otherCollisionGroupString)
    {
        return otherCollisionGroupString == "racket" ||
               otherCollisionGroupString == "block" || otherCollisionGroupString == "unpassableBlock";
    }

    public override string GetCollisionGroupString()
    {
        return UnstoppableBall.CollisionGroupString;
    }
}