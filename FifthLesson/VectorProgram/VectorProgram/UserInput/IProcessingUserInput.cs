using VectorProgram.Model;

namespace VectorProgram.UserInput
{
    public interface IUserInputProcessor
    {
        string RequestInput(DataType dataType, string welcomeMessage);
    }
}
