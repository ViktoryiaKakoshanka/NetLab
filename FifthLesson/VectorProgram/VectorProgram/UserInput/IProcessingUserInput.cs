using VectorProgram.Model;

namespace VectorProgram.UserInput
{
    public interface IUserInputProcessor
    {
        string RequestUserInput(DataType dataType, string welcomeMessage);
    }
}
