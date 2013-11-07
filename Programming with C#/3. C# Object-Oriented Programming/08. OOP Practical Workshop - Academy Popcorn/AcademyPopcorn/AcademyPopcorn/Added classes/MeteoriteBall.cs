using System;
using System.Linq;

namespace AcademyPopcorn
{
    class MeteoriteBall : Ball
    {
        /* Exercise: 6 */
        static Random rnd = new Random();

        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
        }

        public override System.Collections.Generic.IEnumerable<GameObject> ProduceObjects()
        {
            return new GameObject[1] { new TrailObject(this.TopLeft, 3) };
        }
    }
}