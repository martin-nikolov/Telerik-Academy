using System;
using System.Linq;

namespace AcademyPopcorn
{
    public interface IRenderable
    {
        MatrixCoords GetTopLeft();

        char[,] GetImage();
    }
}