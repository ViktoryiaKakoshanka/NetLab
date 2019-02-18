using BinaryTreeApplication.Model;

namespace BinaryTreeApplication.Helpers
{
    public static class RegisterHelper
    {
        public static object GetProperty(Register register, string nameProperty)
        {
            if (nameProperty == nameof(Register.Student))
            {
                return register.Student;
            }

            if (nameProperty == nameof(Register.TestName))
            {
                return register.TestName;
            }

            if (nameProperty == nameof(Register.Date))
            {
                return register.Date;
            }

            return register.Mark;
        }
    }
}
