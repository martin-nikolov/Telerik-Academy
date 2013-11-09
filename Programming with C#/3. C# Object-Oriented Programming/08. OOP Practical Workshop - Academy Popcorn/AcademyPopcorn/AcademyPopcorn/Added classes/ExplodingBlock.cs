using System;
using System.Collections.Generic;
using System.Linq;
using AcademyPopcorn;

/// <summary>
/// Task 10
/// </summary>
class ExplodingBlock : Block
{
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
        this.isHit = true;
        this.IsDestroyed = true;
    }

    public override System.Collections.Generic.IEnumerable<GameObject> ProduceObjects()
    {
        if (this.isHit)
        {
            return new List<Explode>()
            {
                new Explode(this.TopLeft, new MatrixCoords(-1, 0)),
                new Explode(this.TopLeft, new MatrixCoords(0, -1)),
                new Explode(this.TopLeft, new MatrixCoords(1, 0)),
                new Explode(this.TopLeft, new MatrixCoords(0, 1))
            };
        }

        return base.ProduceObjects();
    }
}