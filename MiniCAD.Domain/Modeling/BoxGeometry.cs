using MiniCAD.Domain.Geometry;

namespace MiniCAD.Domain.Modeling
{
    public static class BoxGeometry
    {
        public static Mesh3D Create(
            double width,
            double height,
            double depth)
        {
            if (width <= 0 || height <= 0 || depth <= 0)
                throw new ArgumentOutOfRangeException(
                    "Box dimensions must be positive.");

            double x = width / 2.0;
            double y = height / 2.0;
            double z = depth / 2.0;

            var vertices = new[]
            {
                new Point3D(-x, -y, -z), // 0
                new Point3D( x, -y, -z), // 1
                new Point3D( x,  y, -z), // 2
                new Point3D(-x,  y, -z), // 3

                new Point3D(-x, -y,  z), // 4
                new Point3D( x, -y,  z), // 5
                new Point3D( x,  y,  z), // 6
                new Point3D(-x,  y,  z)  // 7
            };

            var faces = new[]
            {
                // Bottom
                new Triangle3D(vertices[0], vertices[2], vertices[1]),
                new Triangle3D(vertices[0], vertices[3], vertices[2]),

                // Top
                new Triangle3D(vertices[4], vertices[5], vertices[6]),
                new Triangle3D(vertices[4], vertices[6], vertices[7]),

                // Front
                new Triangle3D(vertices[0], vertices[1], vertices[5]),
                new Triangle3D(vertices[0], vertices[5], vertices[4]),

                // Back
                new Triangle3D(vertices[3], vertices[7], vertices[6]),
                new Triangle3D(vertices[3], vertices[6], vertices[2]),

                // Left
                new Triangle3D(vertices[0], vertices[4], vertices[7]),
                new Triangle3D(vertices[0], vertices[7], vertices[3]),

                // Right
                new Triangle3D(vertices[1], vertices[2], vertices[6]),
                new Triangle3D(vertices[1], vertices[6], vertices[5])
            };

            return new Mesh3D(vertices, faces);
        }
    }
}
