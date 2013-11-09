using System;
using System.Collections.Generic;
using System.Linq;
using AcademyPopcorn;

/// <summary>
/// Task 11
/// </summary>
class Gift : MovingObject
{
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
        this.IsDestroyed = true;
    }

    public override System.Collections.Generic.IEnumerable<GameObject> ProduceObjects()
    {
        List<GameObject> racket = new List<GameObject>();

        if (this.IsDestroyed)
            racket.Add(new ShootingRacket(new MatrixCoords(this.topLeft.Row + 1, this.topLeft.Col - 3), 6));

        return racket;
    }
}