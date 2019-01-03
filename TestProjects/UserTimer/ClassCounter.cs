using System;

namespace UserTimer
{
    public class ClassCounter
    {
        public delegate void MethodContainer();

        //public event MethodContainer OnCount = () => {};
        public event EventHandler OnCount;

        public void Count()
        {
            for (var i = 1; i <= 600; i++)
            {
                if (i == 500)
                {
                    OnCount?.Invoke(null, null);
                }
            }
        }
    }
}
