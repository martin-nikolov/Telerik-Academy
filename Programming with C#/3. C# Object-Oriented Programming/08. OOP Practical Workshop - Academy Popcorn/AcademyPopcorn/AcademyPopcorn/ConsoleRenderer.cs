using System;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class ConsoleRenderer : IRenderer
    {
        int renderContextMatrixRows;
        int renderContextMatrixCols;
        char[,] renderContextMatrix;

        public ConsoleRenderer(int visibleConsoleRows, int visibleConsoleCols)
        {
            this.renderContextMatrix = new char[visibleConsoleRows, visibleConsoleCols];

            this.renderContextMatrixRows = this.renderContextMatrix.GetLength(0);
            this.renderContextMatrixCols = this.renderContextMatrix.GetLength(1);

            this.ClearQueue();
        }

        public void EnqueueForRendering(IRenderable obj)
        {
            char[,] objImage = obj.GetImage();

            int imageRows = objImage.GetLength(0);
            int imageCols = objImage.GetLength(1);

            MatrixCoords objTopLeft = obj.GetTopLeft();

            int lastRow = Math.Min(objTopLeft.Row + imageRows, this.renderContextMatrixRows);
            int lastCol = Math.Min(objTopLeft.Col + imageCols, this.renderContextMatrixCols);

            for (int row = obj.GetTopLeft().Row; row < lastRow; row++)
            {
                for (int col = obj.GetTopLeft().Col; col < lastCol; col++)
                {
                    if (row >= 0 && row < this.renderContextMatrixRows &&
                        col >= 0 && col < this.renderContextMatrixCols)
                    {
                        this.renderContextMatrix[row, col] = objImage[row - obj.GetTopLeft().Row, col - obj.GetTopLeft().Col];
                    }
                }
            }
        }

        public void RenderAll()
        {
            Console.SetCursorPosition(0, 0);

            StringBuilder scene = new StringBuilder();

            for (int row = 0; row < this.renderContextMatrixRows; row++)
            {
                for (int col = 0; col < this.renderContextMatrixCols; col++)
                {
                    scene.Append(this.renderContextMatrix[row, col]);
                }

                scene.Append(Environment.NewLine);
            }

            Console.WriteLine(scene.ToString());
        }

        public void ClearQueue()
        {
            for (int row = 0; row < this.renderContextMatrixRows; row++)
            {
                for (int col = 0; col < this.renderContextMatrixCols; col++)
                {
                    this.renderContextMatrix[row, col] = ' ';
                }
            }
        }
    }
}