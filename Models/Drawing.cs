using System.Windows;

namespace ExpandedDimensions.Models
{
    public class Drawing
    {
        //Variables
        private int _maxPoints = 2;
        private List<Point> _points = new List<Point>();
        
        //Check to see if the amount of points exceeds the limit
        public bool GetMaxCheck()
        {
            return _maxPoints >= _points.Count;
        }
        //Get the current count of the point array for comparisons
        public int GetPointsLength()
        { 
            return _points.Count; 
        }
        //Get the array of points being stored
        public List<Point> GetPointsList()
        {
            return _points;
        }
        //Set the max amount of points a Drawing can have
        public void SetMaxPoints(int maxPoints)
        {
            _maxPoints = maxPoints;
        }
        //Add a point to the array for the Drawing
        public void AddPoint(double x, double y)
        {
            if (GetMaxCheck()) _points.Clear();
            else _points.Add(new Point(x, y));
        }
    }
}
