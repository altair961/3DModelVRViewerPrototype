using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HelixToolkit.Wpf;
using System.Windows.Media.Media3D;

namespace SpaceShipConstructor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Model3DGroup Model3DGroup;
        public ModelImporter ModelImporter;
        public Model3D SpaceshipModel;

        public Model3D Model { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            ModelImporter = new ModelImporter();
            Model3DGroup = new Model3DGroup();

            Material material = new DiffuseMaterial(new SolidColorBrush(Colors.Beige));
            ModelImporter.DefaultMaterial = material;

            SpaceshipModel = ModelImporter.Load(@"Spaceship.obj");

            Model3DGroup.Children.Add(SpaceshipModel);

            this.Model = Model3DGroup;
            overall_grid.DataContext = this;

            Transform3DGroup transfomrs = new Transform3DGroup();

            RotateTransform3D xRotateTransform = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(1, 0, 0), 90));
            transfomrs.Children.Add(xRotateTransform);

            RotateTransform3D yRotateTransform = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 1, 0), 0));
            transfomrs.Children.Add(yRotateTransform);

            RotateTransform3D zRotateTransform = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 0, 1), 270));
            transfomrs.Children.Add(zRotateTransform);
            Model3DGroup.Transform = transfomrs;
        }
    }
}
