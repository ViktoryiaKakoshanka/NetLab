using VectorProgram.Model;

namespace VectorProgram.UserInput
{
    public interface IProcessingUserInput
    {
        string RequestUserInput(DataType dataType, string welcomeMessage);
    }
}
