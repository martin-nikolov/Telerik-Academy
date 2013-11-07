using System;
using System.Linq;

namespace AcademyPopcorn
{
    public class EngineForShootingRacket : Engine
    {
        /* Exercise: 4 */
        public ShootingRacket shootingRacket;

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
            if (this.shootingRacket != null)
                this.shootingRacket.Fire();
        }

        public override void AddObject(GameObject obj)
        {
            ShootingRacket racket = obj as ShootingRacket;

            if (racket != null)
                this.shootingRacket = racket;

            base.AddObject(obj);
        }
    }
}