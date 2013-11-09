using System;
using System.Linq;
using AcademyPopcorn;

/// <summary>
/// Task 6
/// </summary>
class MeteoriteBall : Ball
{
    public const char Symbol = 'O';

    public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
        : base(topLeft, speed)
    {
        this.body[0, 0] = MeteoriteBall.Symbol;
    }

    public override System.Collections.Generic.IEnumerable<GameObject> ProduceObjects()
    {
        return new GameObject[] { new TrailObject(this.TopLeft, 3) };
    }
}