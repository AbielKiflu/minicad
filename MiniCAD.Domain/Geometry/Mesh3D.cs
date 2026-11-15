namespace MiniCAD.Domain.Geometry
{
    public sealed class Mesh3D
    {
        public IReadOnlyList<Point3D> Vertices { get; }
        public IReadOnlyList<Triangle3D> Faces { get; }

        public Mesh3D(
            IEnumerable<Point3D> vertices,
            IEnumerable<Triangle3D> faces)
        {
            Vertices = vertices.ToList().AsReadOnly();
            Faces = faces.ToList().AsReadOnly();
        }

        public double SurfaceArea =>
            Faces.Sum(face => face.Area);

        public int VertexCount => Vertices.Count;

        public int FaceCount => Faces.Count;
    }
}
