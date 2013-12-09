namespace AcademyGeometry
{
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
}