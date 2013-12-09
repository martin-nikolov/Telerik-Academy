namespace AcademyGeometry
{
    using System;
    using System.Linq;

    class ExtendedFigureController : FigureController
    {
        public override void ExecuteFigureCreationCommand(string[] splitFigString)
        {
            switch (splitFigString[0])
            {
                case "circle":
                    {
                        Vector3D location = Vector3D.Parse(splitFigString[1]);
                        var radius = double.Parse(splitFigString[2]);
                        this.currentFigure = new Circle(location, radius);
                        break;
                    }
                case "cylinder":
                    {
                        Vector3D bottom = Vector3D.Parse(splitFigString[1]);
                        Vector3D top = Vector3D.Parse(splitFigString[2]);
                        var radius = double.Parse(splitFigString[3]);
                        this.currentFigure = new Cylinder(bottom, top, radius);
                        break;
                    }
                default:
                    {
                        base.ExecuteFigureCreationCommand(splitFigString);
                        break;
                    }
            }

            this.EndCommandExecuted = false;
        }

        protected override void ExecuteFigureInstanceCommand(string[] splitCommand)
        {
            switch (splitCommand[0])
            {
                case "area":
                    {
                        if (this.currentFigure is IAreaMeasurable)
                        {
                            Console.WriteLine("{0:0.00}", (this.currentFigure as IAreaMeasurable).GetArea());
                        }
                        else
                        {
                            Console.WriteLine("undefined");
                        }

                        break;
                    }
                case "volume":
                    {
                        if (this.currentFigure is IVolumeMeasurable)
                        {
                            Console.WriteLine("{0:0.00}", (this.currentFigure as IVolumeMeasurable).GetVolume());
                        }
                        else
                        {
                            Console.WriteLine("undefined");
                        }

                        break;
                    }
                case "normal":
                    {
                        if (this.currentFigure is IFlat)
                        {
                            Console.WriteLine("{0:0.00}", (this.currentFigure as IFlat).GetNormal());
                        }
                        else
                        {
                            Console.WriteLine("undefined");
                        }

                        break;
                    }
                default:
                    {
                        base.ExecuteFigureInstanceCommand(splitCommand);
                        break;
                    }
            }
        }
    }
}