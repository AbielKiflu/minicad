using HelixToolkit.Wpf;
using MiniCAD.Domain.Scene;
using System.Windows.Media.Media3D;

namespace MiniCAD.GUI.Rendering
{
    public sealed class SceneRenderer
    {
        private readonly Dictionary<Guid, ModelVisual3D> _visuals = new();

        public void Render(
            SceneManager sceneManager,
            HelixViewport3D viewport)
        {
            viewport.Children.Clear();
            _visuals.Clear();

            foreach (var obj in sceneManager.Objects)
            {
                var visual = MeshRenderer.CreateVisual(obj.Geometry);

                _visuals.Add(obj.Id, visual);
                viewport.Children.Add(visual);
            }
        }

        public void Clear(
            HelixViewport3D viewport)
        {
            viewport.Children.Clear();
            _visuals.Clear();
        }

        public ModelVisual3D? GetVisual(Guid id)
        {
            return _visuals.TryGetValue(id, out var visual)
                ? visual
                : null;
        }
    }
}

