using MiniCAD.Domain.Modeling;
using MiniCAD.UI.Rendering;
using System.Windows;


namespace MiniCAD.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Create geometry
            var box = BoxGeometry.Create(2, 3, 4);

            // Render geometry
            var visual = MeshRenderer.CreateVisual(box);

            Viewport.Children.Add(visual);

            Viewport.ZoomExtents();
        }
    }
}