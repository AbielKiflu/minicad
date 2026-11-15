using MiniCAD.Domain.Geometry;

namespace MiniCAD.Domain.Scene
{
    public sealed class SceneObject3D
    {
        public Guid Id { get; } = Guid.NewGuid();

        public string Name { get; set; }

        public Mesh3D Geometry { get; }

        public SceneObject3D(string name, Mesh3D geometry)
        {
            Name = name;
            Geometry = geometry;
        }
    }
}
