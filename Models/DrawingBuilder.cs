using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ExpandedDimensions.Models
{
    //Allows different types of shapes to be drawn
    public class DrawingBuilder
    {
        //The drawing object to reference
        protected Drawing _drawing = new Drawing();
        //Default Constructor: internally sets the max amount of points
        public DrawingBuilder() { SetMaxPoints(); }
        //Sets the max amount of points
        protected virtual void SetMaxPoints() { }
        //Add a point to the Drawing points array
        public void AddPoint(double x, double y) { _drawing.AddPoint(x, y); }
        //The resulting Shape from the DrawingBuilder
        public virtual Shape BuildShape() { return null; }
        public Drawing GetDrawing() { return _drawing; }
    }
    public class LineDrawingBuilder : DrawingBuilder
    {
        //Force max to be 2
        protected override void SetMaxPoints()
        {
            _drawing.SetMaxPoints(2);
        }
        //Creates a Line object from the points array
        public override Shape BuildShape()
        {
            if (_drawing.GetPointsLength() > 1)
            {
                Line drawing = new Line();
                drawing.X1 = _drawing.GetPointsList()[0].X;
                drawing.Y1 = _drawing.GetPointsList()[0].Y;
                drawing.X2 = _drawing.GetPointsList()[1].X;
                drawing.Y2 = _drawing.GetPointsList()[1].Y;

                drawing.Stroke = Brushes.LightSteelBlue;

                drawing.HorizontalAlignment = HorizontalAlignment.Left;
                drawing.VerticalAlignment = VerticalAlignment.Center;
                drawing.StrokeThickness = 2;

                return drawing;
            }
            return null;
        }
    }

    public class EllipseDrawingBuilder : DrawingBuilder
    {
        //Force max to be 2
        protected override void SetMaxPoints()
        {
            _drawing.SetMaxPoints(2);
        }
        //Creates an Ellipse object from the points array
        public override Shape BuildShape()
        {
            if (_drawing.GetPointsLength() > 1)
            {
                Ellipse drawing = new Ellipse();
                double width = Math.Abs((_drawing.GetPointsList()[0].X - _drawing.GetPointsList()[1].X));
                double height = Math.Abs((_drawing.GetPointsList()[0].Y - _drawing.GetPointsList()[1].Y));

                drawing.Width = width;
                drawing.Height = height;

                Canvas.SetLeft(drawing,Math.Min(_drawing.GetPointsList()[0].X, _drawing.GetPointsList()[1].X));
                Canvas.SetTop(drawing, Math.Min(_drawing.GetPointsList()[0].Y, _drawing.GetPointsList()[1].Y));
                
                drawing.Stroke = Brushes.DarkCyan;

                drawing.HorizontalAlignment = HorizontalAlignment.Left;
                drawing.VerticalAlignment = VerticalAlignment.Center;
                drawing.StrokeThickness = 2;


                return drawing;
            }
            return null;
        }
    }

    public class PolygonDrawingBuilder : DrawingBuilder
    {
        //Allow *infinite* amount of points
        protected override void SetMaxPoints()
        {
            _drawing.SetMaxPoints(int.MaxValue);
        }
        //Creates a Polygon object from the points array
        public override Shape BuildShape()
        {
            if (_drawing.GetPointsLength() > 1)
            {
                Polygon drawing = new Polygon();
                PointCollection points = new PointCollection();

                for (int i = 0; i < _drawing.GetPointsList().Count; i++)
                {
                   points.Add(_drawing.GetPointsList()[i]);
                }

                //Polygon needs to be a closed drawing
                points.Add(_drawing.GetPointsList()[0]);

                drawing.Points = points;

                drawing.Stroke = Brushes.HotPink;

                drawing.HorizontalAlignment = HorizontalAlignment.Left;
                drawing.VerticalAlignment = VerticalAlignment.Center;
                drawing.StrokeThickness = 2;


                return drawing;
            }
            return null;
        }
    }

    public class PolylineDrawingBuilder : DrawingBuilder
    {
        //Allow *infinite* amount of points
        protected override void SetMaxPoints()
        {
            _drawing.SetMaxPoints(int.MaxValue);
        }
        //Creates a Polygon object from the points array
        public override Shape BuildShape()
        {
            if (_drawing.GetPointsLength() > 1)
            {
                Polygon drawing = new Polygon();
                PointCollection points = new PointCollection();

                for (int i = 0; i < _drawing.GetPointsList().Count; i++)
                {
                    points.Add(_drawing.GetPointsList()[i]);
                }

                drawing.Points = points;

                drawing.Stroke = Brushes.Orange;

                drawing.HorizontalAlignment = HorizontalAlignment.Left;
                drawing.VerticalAlignment = VerticalAlignment.Center;
                drawing.StrokeThickness = 2;


                return drawing;
            }
                return null;
        }
    }

    public class RectangleDrawingBuilder : DrawingBuilder
    {
        //Force max to be 2
        protected override void SetMaxPoints()
        {
            _drawing.SetMaxPoints(2);
        }
        //Creates a Rectangle object from the points array
        public override Shape BuildShape()
        {
            if (_drawing.GetPointsLength() > 1)
            {
                Rectangle drawing = new Rectangle();
                double width = Math.Abs((_drawing.GetPointsList()[0].X - _drawing.GetPointsList()[1].X));
                double height = Math.Abs((_drawing.GetPointsList()[0].Y - _drawing.GetPointsList()[1].Y));

                drawing.Width = width;
                drawing.Height = height;

                Canvas.SetLeft(drawing, Math.Min(_drawing.GetPointsList()[0].X, _drawing.GetPointsList()[1].X));
                Canvas.SetTop(drawing, Math.Min(_drawing.GetPointsList()[0].Y, _drawing.GetPointsList()[1].Y));
                
                drawing.Stroke = Brushes.Violet;

                drawing.HorizontalAlignment = HorizontalAlignment.Left;
                drawing.VerticalAlignment = VerticalAlignment.Center;
                drawing.StrokeThickness = 2;


                return drawing;
            }
            return null;
        }
    }
}
