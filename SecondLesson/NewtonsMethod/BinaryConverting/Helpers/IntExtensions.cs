using System.Linq;
using System.Text;

namespace BinaryConverting.Helpers
{
    public static class IntExtensions
    {
        public static string ByConvert(this int number)
        {
            var binary = new StringBuilder();

            while (number > 0)
            {
                var remainder = number % 2;
                number /= 2;
                binary.Append(remainder);
            }
            
            return new string(binary.ToString().Reverse().ToArray());
        }
    }
}
