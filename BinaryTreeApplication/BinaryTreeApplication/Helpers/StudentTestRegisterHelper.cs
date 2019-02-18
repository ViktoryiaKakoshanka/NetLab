using BinaryTreeApplication.Model;
using System;

namespace BinaryTreeApplication.Helpers
{
    public class StudentTestRegisterHelper : IProperty<int>, IProperty<string>, IProperty<DateTime>
    {
        public int GetProperty(StudentTestRegister register, string nameProperty)
        {
            return register.Mark;
        }

        string IProperty<string>.GetProperty(StudentTestRegister register, string nameProperty)
        {
            if (nameProperty == nameof(StudentTestRegister.Student))
            {
                return register.Student;
            }

            return register.TestName;
        }

        DateTime IProperty<DateTime>.GetProperty(StudentTestRegister register, string nameProperty)
        {
            return register.Date;
        }
    }
}
