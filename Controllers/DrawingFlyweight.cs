using ExpandedDimensions.Models;
using System.Windows;
using System.Windows.Shapes;

namespace ExpandedDimensions.Controllers
{
    public interface DrawingFlyweight
    {
        public DrawingBuilder _drawingBuilder { get; }
        public void PointListener(Point point)
        {
            _drawingBuilder.AddPoint(point.X, point.Y);
        }
        public Shape Draw(bool stopKey)
        {
            return _drawingBuilder.BuildShape(stopKey);
        }

        public void ClearCheck()
        {
            if (_drawingBuilder.GetDrawing().GetMaxCheck()) _drawingBuilder.GetDrawing().Clear();
        }
    }

    public class DrawingFlyweightFactory
    {
        public static Dictionary<string, DrawingFlyweight> drawingCache = new Dictionary<string, DrawingFlyweight>();

        public DrawingFlyweight GetDrawing(string key)
        {
            if (drawingCache.ContainsKey(key))
            {
                return drawingCache[key];
            }
            else
            {
                DrawingFlyweight flyweight = null;
                switch (key)
                {
                    case ("line"):
                        flyweight = new LineFlyweight();
                        break;
                    case ("ellipse"):
                        flyweight = new EllipseFlyweight();
                        break;
                    case ("polyline"):
                        flyweight = new PolylineFlyweight();
                        break;
                    case ("polygon"):
                        flyweight = new PolygonFlyweight();
                        break;
                    case ("rectangle"):
                        flyweight = new RectangleFlyweight();
                        break;
                    default:
                        throw new ArgumentException("Invalid Drawing Type");
                }
                drawingCache.Add(key, flyweight);
                return flyweight;
            }
        }
    }

    public class LineFlyweight : DrawingFlyweight
    {
        public DrawingBuilder _drawingBuilder { get; } = new LineDrawingBuilder();
    }
    public class EllipseFlyweight : DrawingFlyweight
    {
        public DrawingBuilder _drawingBuilder { get; } = new EllipseDrawingBuilder();

    }
    public class PolylineFlyweight : DrawingFlyweight
    {
        public DrawingBuilder _drawingBuilder { get; } = new PolylineDrawingBuilder();
    }
    public class PolygonFlyweight : DrawingFlyweight
    {
        public DrawingBuilder _drawingBuilder { get; } = new PolygonDrawingBuilder();

    }
    public class RectangleFlyweight : DrawingFlyweight
    {
        public DrawingBuilder _drawingBuilder { get; } = new RectangleDrawingBuilder();
    }

}