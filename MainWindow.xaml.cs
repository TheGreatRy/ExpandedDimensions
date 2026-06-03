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
        public DrawingCommand Command { get; set; }
        
        public MainWindow()
        {
            InitializeComponent(); 
            Command = new DrawingCommand();
        }

        public void Draw(Shape shape) 
        {
            if (Command.DrawShape() != null)
            {
                DrawingArea.Children.Add(Command.DrawShape());
            }
        }

        public static Point GetMousePositionWindowsForms()
        {
            var point = Mouse.GetPosition(Application.Current.MainWindow);
            return new Point((int)point.X, (int)point.Y);
        }

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Command._drawingFlyweight.PointListener(GetMousePositionWindowsForms());
            Draw(Command.DrawShape());
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
            }
           
        }
    }
}