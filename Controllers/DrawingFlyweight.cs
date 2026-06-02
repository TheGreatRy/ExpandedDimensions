using ExpandedDimensions.Models;

namespace ExpandedDimensions.Controllers
{
    public interface DrawingFlyweight
    {
        DrawingBuilder drawingBuilder { set; get; }
        void Draw();
    }

    public class LineFlyweight : DrawingFlyweight
    {
        public DrawingBuilder drawingBuilder
        {
            set
            {
                drawingBuilder = new LineDrawingBuilder();
            }
            get
            {
                return drawingBuilder;
            }
        }

        public void Draw()
        {
            
        }
    }
    public class EllipseFlyweight : DrawingFlyweight
    {
        public DrawingBuilder drawingBuilder
        {
            set
            {
                drawingBuilder = new EllipseDrawingBuilder();
            }
            get
            {
                return drawingBuilder;
            }
        }

        public void Draw()
        {
            
        }
    }
    public class PolylineFlyweight : DrawingFlyweight
    {
        public DrawingBuilder drawingBuilder
        {
            set
            {
                drawingBuilder = new PolylineDrawingBuilder();
            }
            get
            {
                return drawingBuilder;
            }
        }

        public void Draw()
        {
           
        }
    }
    public class PolygonFlyweight : DrawingFlyweight
    {
        public DrawingBuilder drawingBuilder
        {
            set
            {
                drawingBuilder = new PolygonDrawingBuilder();
            }
            get
            {
                return drawingBuilder;
            }
        }

        public void Draw()
        {
            
        }
    }
    public class RectangleFlyweight : DrawingFlyweight
    {
        public DrawingBuilder drawingBuilder
        {
            set
            {
                drawingBuilder = new RectangleDrawingBuilder();
            }
            get
            {
                return drawingBuilder;
            }
        }

        public void Draw()
        {
            
        }
    }
}