using System;
using System.Linq;
using AcademyPopcorn;

/// <summary>
/// Task 12
/// </summary>
class GiftBlock : Block
{
    public const char Symbol = '\u25A0';

    public GiftBlock(MatrixCoords topLeft)
        : base(topLeft)
    {
        this.body[0, 0] = GiftBlock.Symbol;
    }

    public override System.Collections.Generic.IEnumerable<GameObject> ProduceObjects()
    {
        if (this.IsDestroyed)
            return new GameObject[] { new Gift(this.TopLeft) };

        return base.ProduceObjects();
    }
}