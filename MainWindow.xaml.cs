using ExpandedDimensions.Views;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;

namespace ExpandedDimensions
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _stopKey = true;
        public DrawingCommand Command { get; set; }
        
        public MainWindow()
        {
            InitializeComponent(); 
            Command = new DrawingCommand();

            //// Create a viewport
            //var viewport = new Viewport3DX();

            //// Create a camera
            //var camera = new PerspectiveCamera
            //{
            //    Position = new System.Windows.Media.Media3D.Point3D(5, 5, 5),
            //    LookDirection = new System.Windows.Media.Media3D.Vector3D(-5, -5, -5)
            //};
            //viewport.Camera = camera;

            //// Add to your UI
            //Content = viewport;
        }

        public void Draw(Shape shape) 
        {
            if (Command.DrawShape(_stopKey) != null)
            {
                DrawingArea.Children.Add(Command.DrawShape(_stopKey));
            }
        }

        public static Point GetMousePos()
        {
            var point = Mouse.GetPosition(Application.Current.MainWindow);
            return new Point((int)point.X, (int)point.Y);
        }

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Command.DrawingFlyweight.PointListener(GetMousePos());
            Draw(Command.DrawShape(_stopKey));
            Command.DrawingFlyweight.ClearCheck();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Q:
                    Command = new SwitchToLineCommand();
                    break;
                case Key.W:
                    Command = new SwitchToEllipseCommand();
                    break;
                case Key.E:
                    Command = new SwitchToPolylineCommand();
                    break;
                case Key.R:
                    Command = new SwitchToPolygonCommand();
                    break;
                case Key.T:
                    Command = new SwitchToRectangleCommand();
                    break;
                case Key.Escape:
                    App.Current.MainWindow.Close();
                    break;
                //case Key.Space:
                //    _stopKey = false;
                //    break;
            }
           
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.Space) _stopKey = true;
        }
    }
}