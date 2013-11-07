using System;
using System.Linq;

namespace AcademyPopcorn
{
    class TrailObject : GameObject
    {
        /* Exercise: 5 */
        public TrailObject(MatrixCoords topLeft, int lifeTime)
            : base(topLeft, new char[,] { { '*' } })
        {
            this.LifeTime = lifeTime;
        }

        public int LifeTime { get; private set; }

        public override void Update()
        {
            if (this.LifeTime-- <= 0)
            {
                this.IsDestroyed = true;
            }
        }
    }
}