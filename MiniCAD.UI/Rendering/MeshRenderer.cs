using MiniCAD.Domain.Geometry;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace MiniCAD.UI.Rendering
{
    public static class MeshRenderer
    {
        public static ModelVisual3D CreateVisual(Mesh3D mesh)
        {
            var geometry = new MeshGeometry3D();

            foreach (var face in mesh.Faces)
            {
                var normal = face.Normal;

                int index = geometry.Positions.Count;

                // Triangle vertices
                geometry.Positions.Add(
                    new System.Windows.Media.Media3D.Point3D(
                        face.A.X, face.A.Y, face.A.Z));

                geometry.Positions.Add(
                    new System.Windows.Media.Media3D.Point3D(
                        face.B.X, face.B.Y, face.B.Z));

                geometry.Positions.Add(
                    new System.Windows.Media.Media3D.Point3D(
                        face.C.X, face.C.Y, face.C.Z));

                // Face normals (flat shading)
                var wpfNormal =
                    new System.Windows.Media.Media3D.Vector3D(
                        normal.X, normal.Y, normal.Z);

                geometry.Normals.Add(wpfNormal);
                geometry.Normals.Add(wpfNormal);
                geometry.Normals.Add(wpfNormal);

                // Triangle indices
                geometry.TriangleIndices.Add(index);
                geometry.TriangleIndices.Add(index + 1);
                geometry.TriangleIndices.Add(index + 2);
            }

            var material = new DiffuseMaterial(
                new SolidColorBrush(Color.FromRgb(70, 150, 220)));

            var model = new GeometryModel3D
            {
                Geometry = geometry,
                Material = material,
                BackMaterial = material
            };

            return new ModelVisual3D
            {
                Content = model
            };
        }
    }
}
