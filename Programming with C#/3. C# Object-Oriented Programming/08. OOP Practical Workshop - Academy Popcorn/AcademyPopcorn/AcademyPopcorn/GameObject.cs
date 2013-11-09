using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyPopcorn
{
    public abstract class GameObject : IRenderable, ICollidable, IObjectProducer
    {
        public const string CollisionGroupString = "object";

        protected MatrixCoords topLeft;
        protected char[,] body;

        protected GameObject(MatrixCoords topLeft, char[,] body)
        {
            this.TopLeft = topLeft;

            int imageRows = body.GetLength(0);
            int imageCols = body.GetLength(1);

            this.body = this.CopyBodyMatrix(body);

            this.IsDestroyed = false;
        }

        public MatrixCoords TopLeft
        {
            get { return new MatrixCoords(this.topLeft.Row, this.topLeft.Col); }

            protected set { this.topLeft = new MatrixCoords(value.Row, value.Col); }
        }

        public bool IsDestroyed { get; protected set; }

        public abstract void Update();

        public virtual List<MatrixCoords> GetCollisionProfile()
        {
            List<MatrixCoords> profile = new List<MatrixCoords>();

            int bodyRows = this.body.GetLength(0);
            int bodyCols = this.body.GetLength(1);

            for (int row = 0; row < bodyRows; row++)
            {
                for (int col = 0; col < bodyCols; col++)
                {
                    profile.Add(new MatrixCoords(row + this.topLeft.Row, col + this.topLeft.Col));
                }
            }

            return profile;
        }

        public virtual void RespondToCollision(CollisionData collisionData)
        {
        }

        public virtual bool CanCollideWith(string otherCollisionGroupString)
        {
            return GameObject.CollisionGroupString == otherCollisionGroupString;
        }

        public virtual string GetCollisionGroupString()
        {
            return GameObject.CollisionGroupString;
        }

        public virtual MatrixCoords GetTopLeft()
        {
            return this.TopLeft;
        }

        public virtual char[,] GetImage()
        {
            return this.CopyBodyMatrix(this.body);
        }

        public virtual IEnumerable<GameObject> ProduceObjects()
        {
            return new List<GameObject>();
        }

        char[,] CopyBodyMatrix(char[,] matrixToCopy)
        {
            int rows = matrixToCopy.GetLength(0);
            int cols = matrixToCopy.GetLength(1);

            char[,] result = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    result[row, col] = matrixToCopy[row, col];
                }
            }

            return result;
        }
    }
}