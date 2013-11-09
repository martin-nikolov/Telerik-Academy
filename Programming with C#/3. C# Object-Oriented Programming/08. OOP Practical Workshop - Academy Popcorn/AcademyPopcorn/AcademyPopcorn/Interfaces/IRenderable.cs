using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public interface IRenderable
    {
        MatrixCoords GetTopLeft();

        char[,] GetImage();
    }
}
