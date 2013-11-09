using System;
using System.Linq;
using AcademyPopcorn;

/// <summary>
/// Task 8
/// </summary>
class UnpassableBlock : IndestructibleBlock
{
    public const char Symbol = 'X';
    public new const string CollisionGroupString = "unpassableBlock";

    public UnpassableBlock(MatrixCoords upperLeft)
        : base(upperLeft)
    {
        this.body[0, 0] = UnpassableBlock.Symbol;
    }

    public override string GetCollisionGroupString()
    {
        return IndestructibleBlock.CollisionGroupString;
    }
}