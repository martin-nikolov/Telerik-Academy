namespace AcademyGeometry
{
    using System;

    public class FigureController
    {
        protected Figure currentFigure;

        static readonly string[] separators = new string[] { " " };

        public FigureController()
        {
            this.currentFigure = null;
            this.EndCommandExecuted = false;
        }

        public bool EndCommandExecuted { get; protected set; }

        public void ExecuteCommand(string commandStr)
        {
            string[] splitCommand = commandStr.Split(FigureController.separators, StringSplitOptions.RemoveEmptyEntries);

            if (this.currentFigure == null)
            {
                this.ExecuteFigureCreationCommand(splitCommand);
            }
            else if (splitCommand[0] == "end")
            {
                this.currentFigure = null;
                this.EndCommandExecuted = true;
            }
            else
            {
                this.ExecuteFigureInstanceCommand(splitCommand);
            }
        }

        public virtual void ExecuteFigureCreationCommand(string[] splitFigString)
        {
            switch (splitFigString[0])
            {
                case "vertex":
                    {
                        Vector3D location = Vector3D.Parse(splitFigString[1]);
                        this.currentFigure = new Vertex(location);
                        break;
                    }
                case "segment":
                    {
                        Vector3D a = Vector3D.Parse(splitFigString[1]);
                        Vector3D b = Vector3D.Parse(splitFigString[2]);
                        this.currentFigure = new LineSegment(a, b);
                        break;
                    }
                case "triangle":
                    {
                        Vector3D a = Vector3D.Parse(splitFigString[1]);
                        Vector3D b = Vector3D.Parse(splitFigString[2]);
                        Vector3D c = Vector3D.Parse(splitFigString[3]);
                        this.currentFigure = new Triangle(a, b, c);
                        break;
                    }
            }

            this.EndCommandExecuted = false;
        }

        protected virtual void ExecuteFigureInstanceCommand(string[] splitCommand)
        {
            switch (splitCommand[0])
            {
                case "translate":
                    {
                        Vector3D transVector = Vector3D.Parse(splitCommand[1]);
                        this.currentFigure.Translate(transVector);
                        break;
                    }
                case "rotate":
                    {
                        Vector3D center = Vector3D.Parse(splitCommand[1]);
                        double degrees = double.Parse(splitCommand[2]);
                        this.currentFigure.RotateInXY(center, degrees);
                        break;
                    }
                case "scale":
                    {
                        Vector3D center = Vector3D.Parse(splitCommand[1]);
                        double factor = double.Parse(splitCommand[2]);
                        this.currentFigure.Scale(center, factor);
                        break;
                    }
                case "center":
                    {
                        Vector3D figCenter = this.currentFigure.GetCenter();
                        Console.WriteLine(figCenter.ToString());
                        break;
                    }
                case "measure":
                    {
                        Console.WriteLine("{0:0.00}", this.currentFigure.GetPrimaryMeasure());
                        break;
                    }
            }
        }
    }
}