using ExpandedDimensions.Controllers;
using System.Windows.Shapes;

namespace ExpandedDimensions.Views
{
    public class DrawingCommand
    {
        protected string _key = "";
        public DrawingFlyweight _drawingFlyweight
        {  
            get
            {
                return flyweightFactory.GetDrawing(_key);
            }
        }
        public DrawingCommand() { }
        public DrawingFlyweightFactory flyweightFactory = new DrawingFlyweightFactory();
        virtual public Shape DrawShape() { return _drawingFlyweight.Draw(); }
    }

    public class SwitchToLineCommand : DrawingCommand 
    {
        public SwitchToLineCommand() 
        {
            _key = "line";
        }
    }
    public class SwitchToEllipseCommand : DrawingCommand 
    {
        public SwitchToEllipseCommand() 
        {
            _key = "ellipse";
        }
    }
    public class SwitchToPolylineCommand : DrawingCommand 
    {
        public SwitchToPolylineCommand() 
        {
            _key = "polyline";
        }
    }
    public class SwitchToPolygonCommand : DrawingCommand 
    {
        public SwitchToPolygonCommand() 
        {
            _key = "polygon";
        }
    }
    public class SwitchToRectangleCommand : DrawingCommand 
    {
        public SwitchToRectangleCommand() 
        {
            _key = "rectangle";
        }
    }
}
