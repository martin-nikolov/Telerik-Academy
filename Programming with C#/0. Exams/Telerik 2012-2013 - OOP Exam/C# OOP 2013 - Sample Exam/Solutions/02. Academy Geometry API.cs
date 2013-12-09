using System.Collections.Generic;
using System.Linq;
using System;

public class Circle : Figure, IAreaMeasurable, IFlat
{
    public Circle(Vector3D location, double radius)
        : base(location)
    {
        this.Radius = radius;
    }

    public double Radius { get; private set; }

    public Vector3D GetNormal()
    {
        Vector3D center = this.GetCenter();

        Vector3D a = new Vector3D(center.X + this.Radius, center.Y, center.Z);
        Vector3D b = new Vector3D(center.X, center.Y + this.Radius, center.Z);

        Vector3D normal = Vector3D.CrossProduct(center - a, center - b);
        normal.Normalize();

        return normal;
    }

    public double GetArea()
    {
        return Math.PI * this.Radius * this.Radius;
    }

    public override double GetPrimaryMeasure()
    {
        return this.GetArea();
    }
}

class Cylinder : Figure, IAreaMeasurable, IVolumeMeasurable
{
    public Cylinder(Vector3D bottom, Vector3D top, double radius)
        : base(bottom, top)
    {
        this.Radius = radius;
    }

    public double Radius { get; private set; }

    public Vector3D Top
    {
        get { return new Vector3D(this.vertices[0].X, this.vertices[0].Y, this.vertices[0].Z); }
        private set { this.vertices[0] = new Vector3D(value.X, value.Y, value.Z); }
    }

    public Vector3D Bottom
    {
        get { return new Vector3D(this.vertices[1].X, this.vertices[1].Y, this.vertices[1].Z); }
        private set { this.vertices[1] = new Vector3D(value.X, value.Y, value.Z); }
    }

    public double GetVolume()
    {
        return Math.PI * this.Radius * this.Radius * (this.Top - this.Bottom).Magnitude;
    }

    public double GetArea()
    {
        double baseArea = Math.PI * this.Radius * this.Radius;
        double topAndBottomArea = baseArea * 2;

        double basePerimeter = 2 * Math.PI * this.Radius;

        double sideArea = basePerimeter * (this.Top - this.Bottom).Magnitude;

        return sideArea + topAndBottomArea;
    }

    public override double GetPrimaryMeasure()
    {
        return this.GetVolume();
    }
}

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

public abstract class Figure : ITransformable
{
    protected List<Vector3D> vertices;

    public Figure(params Vector3D[] vertices)
    {
        this.vertices = new List<Vector3D>();
        foreach (var vertex in vertices)
        {
            this.vertices.Add(vertex);
        }
    }

    public virtual Vector3D GetCenter()
    {
        Vector3D verticesSum = new Vector3D(0, 0, 0);

        for (int i = 0; i < this.vertices.Count; i++)
        {
            verticesSum += this.vertices[i];
        }

        return verticesSum / this.vertices.Count;
    }

    public abstract double GetPrimaryMeasure();

    public void Translate(Vector3D translationVector)
    {
        for (int i = 0; i < this.vertices.Count; i++)
        {
            this.vertices[i] += translationVector;
        }
    }

    public void Scale(Vector3D scaleCenter, double scaleFactor)
    {
        for (int i = 0; i < this.vertices.Count; i++)
        {
            Vector3D centeredCurrent = this.vertices[i] - scaleCenter;

            Vector3D scaledCenteredCurrent = centeredCurrent * scaleFactor;

            this.vertices[i] = scaledCenteredCurrent + scaleCenter;
        }
    }

    public void RotateInXY(Vector3D rotCenter, double angleDegrees)
    {
        for (int i = 0; i < this.vertices.Count; i++)
        {
            Vector3D centeredCurrent = this.vertices[i] - rotCenter;

            double angleRads = angleDegrees * Math.PI / 180.0;

            Vector3D rotatedCenteredCurrent = new Vector3D(
                centeredCurrent.X * Math.Cos(angleRads) - centeredCurrent.Y * Math.Sin(angleRads),
                centeredCurrent.X * Math.Sin(angleRads) + centeredCurrent.Y * Math.Cos(angleRads),
                centeredCurrent.Z);

            this.vertices[i] = rotatedCenteredCurrent + rotCenter;
        }
    }
}

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

public interface IAreaMeasurable
{
    double GetArea();
}

public interface IFlat
{
    Vector3D GetNormal();
}

public interface ILengthMeasurable
{
    double GetLength();
}

public interface ITransformable
{
    void Translate(Vector3D translationVector);

    void Scale(Vector3D scaleCenter, double scaleFactor);

    void RotateInXY(Vector3D rotCenter, double angleDegrees);
}

public interface IVolumeMeasurable
{
    double GetVolume();
}

public class LineSegment : Figure, ILengthMeasurable
{
    double length;

    public LineSegment(Vector3D a, Vector3D b)
        : base(a, b)
    {
        this.length = (this.A - this.B).Magnitude;
    }

    private Vector3D A
    {
        get { return this.vertices[0]; }
        set { this.vertices[0] = value; }
    }

    private Vector3D B
    {
        get { return this.vertices[1]; }
        set { this.vertices[1] = value; }
    }

    public double GetLength()
    {
        return this.length;
    }

    public override double GetPrimaryMeasure()
    {
        return this.GetLength();
    }
}

class Program
{
    private static FigureController GetFigureController()
    {
        return new ExtendedFigureController();
    }

    static void Main(string[] args)
    {
        var figController = GetFigureController();

        int figCreationsCount = int.Parse(Console.ReadLine());
        int endCommandsCount = 0;

        while (endCommandsCount < figCreationsCount)
        {
            figController.ExecuteCommand(Console.ReadLine());
            if (figController.EndCommandExecuted)
            {
                endCommandsCount++;
            }
        }
    }
}

public class Triangle : Figure, IFlat, IAreaMeasurable
{
    public Triangle(Vector3D a, Vector3D b, Vector3D c)
        : base(a, b, c)
    {
    }

    private Vector3D A
    {
        get { return this.vertices[0]; }
        set { this.vertices[0] = value; }
    }

    private Vector3D B
    {
        get { return this.vertices[1]; }
        set { this.vertices[1] = value; }
    }

    private Vector3D C
    {
        get { return this.vertices[2]; }
        set { this.vertices[2] = value; }
    }

    public Vector3D GetNormal()
    {
        Vector3D normal = Vector3D.CrossProduct(this.B - this.A, this.C - this.A);
        normal.Normalize();
        return normal;
    }

    public double GetArea()
    {
        Vector3D AB = this.B - this.A;
        Vector3D AC = this.C - this.A;

        return Math.Abs(Vector3D.CrossProduct(AB, AC).Magnitude) / 2;
    }

    public override double GetPrimaryMeasure()
    {
        return this.GetArea();
    }
}

public abstract class Vector
{
    double[] components;
    double magnitude;

    protected Vector(params double[] components)
    {
        this.Dimensions = components.Length;

        this.components = new double[components.Length];

        for (int i = 0; i < components.Length; i++)
        {
            this.components[i] = components[i];
        }

        this.magnitude = this.CalculateMagnitude();
    }

    public double Magnitude
    {
        get { return this.magnitude; }
    }

    public int Dimensions { get; private set; }

    public double this[int index]
    {
        get { return this.GetComponent(index); }
        set { this.SetComponent(index, value); }
    }

    public bool IsZero()
    {
        foreach (var component in this.components)
        {
            if (component != 0)
            {
                return false;
            }
        }

        return true;
    }

    public void Normalize()
    {
        for (int i = 0; i < this.components.Length; i++)
        {
            this.components[i] = this.components[i] / this.Magnitude;
        }
    }

    private double GetComponent(int index)
    {
        return this.components[index];
    }

    private void SetComponent(int index, double value)
    {
        this.components[index] = value;
        this.magnitude = this.CalculateMagnitude();
    }

    private double CalculateMagnitude()
    {
        double sumOfSquarredComponents = 0;
        foreach (var component in this.components)
        {
            sumOfSquarredComponents += component * component;
        }

        return Math.Sqrt(sumOfSquarredComponents);
    }
}

public class Vector3D : Vector
{
    private const int XComponentIndex = 0;

    private const int YComponentIndex = 1;

    private const int ZComponentIndex = 2;

    public Vector3D(double x, double y, double z)
        : base(x, y, z)
    {
    }

    public double X
    {
        get { return this[Vector3D.XComponentIndex]; }
        set { this[Vector3D.XComponentIndex] = value; }
    }

    public double Y
    {
        get { return this[Vector3D.YComponentIndex]; }
        set { this[Vector3D.YComponentIndex] = value; }
    }

    public double Z
    {
        get { return this[Vector3D.ZComponentIndex]; }
        set { this[Vector3D.ZComponentIndex] = value; }
    }

    public static double DotProduct(Vector3D a, Vector3D b)
    {
        double result = 0;
        for (int d = 0; d < 3; d++)
        {
            result += a[d] * b[d];
        }

        return result;
    }

    public static double GetAngleDegrees(Vector3D a, Vector3D b)
    {
        return Math.Acos(Vector3D.DotProduct(a, b) / a.Magnitude * b.Magnitude);
    }

    public static Vector3D CrossProduct(Vector3D a, Vector3D b)
    {
        double crossX = a.Y * b.Z - a.Z * b.Y;
        double crossY = a.Z * b.X - a.X * b.Z;
        double crossZ = a.X * b.Y - a.Y * b.X;

        return new Vector3D(crossX, crossY, crossZ);
    }

    public static Vector3D Parse(string s)
    {
        s = s.Remove(0, 1);
        s = s.Remove(s.Length - 1, 1);

        string[] componentStrings = s.Split(',');

        return new Vector3D(
            double.Parse(componentStrings[0]),
            double.Parse(componentStrings[1]),
            double.Parse(componentStrings[2]));
    }

    public override string ToString()
    {
        return String.Format("({0:0.00},{1:0.00},{2:0.00})", this.X, this.Y, this.Z);
    }

    public static Vector3D operator +(Vector3D a, Vector3D b)
    {
        return new Vector3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }

    public static Vector3D operator -(Vector3D a, Vector3D b)
    {
        return new Vector3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    public static Vector3D operator *(Vector3D v, double scale)
    {
        return new Vector3D(v.X * scale, v.Y * scale, v.Z * scale);
    }

    public static Vector3D operator /(Vector3D v, double scale)
    {
        return new Vector3D(v.X / scale, v.Y / scale, v.Z / scale);
    }
}

public class Vertex : Figure
{
    public Vertex(Vector3D location)
        : base(location)
    {
    }

    public Vector3D Location
    {
        get { return this.vertices[0]; }
        set { this.vertices[0] = value; }
    }

    public override double GetPrimaryMeasure()
    {
        return 0;
    }
}