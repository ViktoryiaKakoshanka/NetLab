using BinaryTreeApplication.Model;
using System;
using System.Collections.Generic;

namespace BinaryTreeApplication.Helpers
{
    public class StudentTestRegisterHelper //: IProperty<int>, IProperty<DateTime>, IProperty<string>
    {
        object GetProperty(StudentTestRegister register, string nameProperty)
        {
            if (nameProperty == nameof(StudentTestRegister.Student))
            {
                return register.Student;
            }

            if (nameProperty == nameof(StudentTestRegister.TestName))
            {
                return register.TestName;
            }

            if (nameProperty == nameof(StudentTestRegister.Date))
            {
                return register.Date;
            }

            return register.Mark;
        }
        /*
        DateTime IProperty<DateTime>.GetProperty(StudentTestRegister register, string nameProperty)
        {
            return register.Date;
        }

        int IProperty<int>.GetProperty(StudentTestRegister register, string nameProperty)
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
        }*/
    }
}
