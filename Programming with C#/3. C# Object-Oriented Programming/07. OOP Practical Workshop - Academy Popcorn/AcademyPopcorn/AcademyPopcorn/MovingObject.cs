using System;
using System.Linq;

namespace AcademyPopcorn
{
    public class MovingObject : GameObject
    { 
        public MatrixCoords Speed { get; protected set; }

        public MovingObject(MatrixCoords topLeft, char[,] body, MatrixCoords speed)
            : base(topLeft, body)
        {
            this.Speed = speed;
        }

        protected virtual void UpdatePosition()
        {
            this.TopLeft += this.Speed;
        }

        public override void Update()
        {
            this.UpdatePosition();
        }
    }
}