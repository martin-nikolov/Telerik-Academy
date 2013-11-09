using System;
using System.Linq;

namespace AcademyPopcorn
{
    public class MovingObject : GameObject
    { 
        public MovingObject(MatrixCoords topLeft, char[,] body, MatrixCoords speed)
            : base(topLeft, body)
        {
            this.Speed = speed;
        }

        public MatrixCoords Speed { get; protected set; }

        public override void Update()
        {
            this.UpdatePosition();
        }

        protected virtual void UpdatePosition()
        {
            this.TopLeft += this.Speed;
        }
    }
}