namespace VectorProgram.Model
{
    public interface IVector
    {
        double FirstCoordinate { get; }
        double SecondCoordinate { get; }
        double ThirdCoordinate { get; }
        double Length { get; }
        double AngleBetweenVectors(IVector vector);
    }
}
