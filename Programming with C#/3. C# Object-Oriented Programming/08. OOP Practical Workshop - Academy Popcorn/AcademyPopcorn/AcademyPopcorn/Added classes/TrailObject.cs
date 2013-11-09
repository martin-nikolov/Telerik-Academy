using System;
using System.Linq;
using AcademyPopcorn;

/// <summary>
/// Task 5
/// </summary>
class TrailObject : GameObject
{
    public const char Symbol = '*';

    public TrailObject(MatrixCoords topLeft, uint lifeTime)
        : base(topLeft, new char[,] { { TrailObject.Symbol } })
    {
        this.LifeTime = lifeTime;
    }

    public uint LifeTime { get; private set; }

    public override void Update()
    {
        if (--this.LifeTime <= 0)
        {
            this.IsDestroyed = true;
        }
    }
}