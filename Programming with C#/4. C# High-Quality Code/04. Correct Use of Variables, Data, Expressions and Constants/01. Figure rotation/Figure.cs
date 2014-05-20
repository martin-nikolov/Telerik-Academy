namespace Shapes
{
    using System;

    public class Figure
    {
        private double width;
        private double height;

        /// <summary>
        /// Create a new figure by given width and height
        /// </summary>
        /// <param name="width">The width of the figure</param>
        /// <param name="height">The height of the figure</param>
        public Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// The width of the figure
        /// </summary>
        public double Width
        {
            get { return this.width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width must be greater than zero.");
                }

                this.width = value;
            }
        }

        /// <summary>
        /// The height of the figure
        /// </summary>
        public double Height
        {
            get { return this.height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height must be greater than zero.");
                }

                this.height = value;
            }
        }

        /// <summary>
        /// Rotate figure by given angle of rotation
        /// </summary>
        /// <param name="figure">The figure to rotate</param>
        /// <param name="rotationAngle">The angle of rotation</param>
        /// <returns>A new figure after rotation by the given angle of rotation</returns>
        public static Figure Rotate(Figure figure, double rotationAngle)
        {
            var sinValue = Math.Abs(Math.Sin(rotationAngle));
            var cosValue = Math.Abs(Math.Cos(rotationAngle));

            var newWidth = cosValue * figure.Width + sinValue * figure.Height;
            var newHeight = sinValue * figure.Width + cosValue * figure.Height;

            Figure rotatedFigure = new Figure(newWidth, newHeight);

            return rotatedFigure;
        }

        public override string ToString()
        {
            var output = string.Format("{0} -> width: {1}, height: {2}", this.GetType().Name, this.width, this.height);

            return output;
        }
    }
}