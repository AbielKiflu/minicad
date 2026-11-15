namespace MiniCAD.Domain.Geometry
{
    public readonly record struct Triangle3D
    {
        public Point3D A { get; }
        public Point3D B { get; }
        public Point3D C { get; }

        public Vector3D Normal
        {
            get
            {
                Vector3D ab = B - A;
                Vector3D ac = C - A;

                return ab.Cross(ac).Normalize();
            }
        }

        public double Area
        {
            get
            {
                Vector3D ab = B - A;
                Vector3D ac = C - A;

                return ab.Cross(ac).Length / 2.0;
            }
        }

        public Triangle3D(Point3D a, Point3D b, Point3D c)
        {
            A = a;
            B = b;
            C = c;
        }
    }
}
