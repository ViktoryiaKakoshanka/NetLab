namespace MatrixProject.Model
{
    public struct Matrix
    {
        public double[,] Array { get; }
        public int Lines { get; }
        public int Columns { get; }
        
        public Matrix(double[,] array, int lines, int columns)
        {
            Array = array;
            Lines = lines;
            Columns = columns;
        }
    }
}