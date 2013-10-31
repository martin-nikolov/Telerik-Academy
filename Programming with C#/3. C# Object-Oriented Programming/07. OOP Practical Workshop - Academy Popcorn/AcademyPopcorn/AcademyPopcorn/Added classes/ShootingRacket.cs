using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyPopcorn
{
    public class ShootingRacket : Racket
    {
        bool canShoot = false;

        public ShootingRacket(MatrixCoords topLeft, int width)
            : base(topLeft, width)
        {
        }

        public void Fire()
        {
            this.canShoot = true;
        }

        public override System.Collections.Generic.IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> bullet = new List<GameObject>();

            if (this.canShoot)
            {
                this.canShoot = false;
                bullet.Add(new Bullet(new MatrixCoords(this.TopLeft.Row, this.TopLeft.Col + 1)));
            }

            return bullet;
        }
    }
}