namespace FirstLessonConsoleApp.Model
{
    public class Coordinate
    {
        private readonly double _x, _y;

        public Coordinate() : this(0.0, 0.0) { }

        public Coordinate(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public override string ToString()
        {
            return $"X: {_x:#.####} Y: {_y:#.####}";
        }
    }
}
