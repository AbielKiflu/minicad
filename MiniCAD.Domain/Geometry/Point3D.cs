namespace MiniCAD.Domain.Geometry
{
    public readonly record struct Point3D
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y; 
            Z = z;
        }

        public double DistanceTo(Point3D point)
        {
            double dx = point.X;
            double dy = point.Y;
            double dz = point.Z;

            return Math.Sqrt(dx*dx + dy*dy + dz*dz);
        }


        public static Vector3D operator -(Point3D a, Point3D b) {
            return new Vector3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z)    ;
        }

        public static Vector3D operator +(Point3D a, Point3D b)
        {
            return new Vector3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Point3D operator +(Point3D point, Vector3D vector)
        {
            return new Point3D(point.X + vector.X, point.Y + vector.Y, point.Z + vector.Z);
        }


    }
}
