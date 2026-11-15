namespace MiniCAD.Domain.Geometry
{
    public readonly record struct Line3D
    {
        public Point3D Start { get; }

        public Point3D End { get; }

        public double Length => Start.DistanceTo(End);

        public Vector3D Direction => (End - Start).Normalize();

        public Line3D(Point3D start, Point3D end)
        {
            Start = start;
            End = end;
        }

        public Point3D PointAt(double t)
        {
            Vector3D direction = End - Start;

            return Start + direction * t;
        }
        

    }
}
