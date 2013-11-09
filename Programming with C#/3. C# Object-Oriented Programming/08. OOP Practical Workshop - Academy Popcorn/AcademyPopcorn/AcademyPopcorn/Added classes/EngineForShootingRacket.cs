using System;
using System.Linq;
using AcademyPopcorn;

/// <summary>
/// Task 4
/// </summary>
public class EngineForShootingRacket : Engine
{
    public ShootingRacket ShootingRacket;

    public EngineForShootingRacket(IRenderer renderer, IUserInterface userInterface)
        : this(renderer, userInterface, 500)
    {
    }

    public EngineForShootingRacket(IRenderer renderer, IUserInterface userInterface, ushort sleepTime)
        : base(renderer, userInterface, sleepTime)
    {
    }

    public void ShootPlayerRacket()
    {
        if (this.ShootingRacket != null)
            this.ShootingRacket.Fire();
    }

    public override void AddObject(GameObject obj)
    {
        ShootingRacket racket = obj as ShootingRacket;

        if (racket != null)
            this.ShootingRacket = racket;

        base.AddObject(obj);
    }
}