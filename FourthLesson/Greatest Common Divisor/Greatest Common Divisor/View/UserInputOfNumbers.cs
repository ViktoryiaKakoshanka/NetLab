using GreatestCommonDivisorProgram.Controller;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GreatestCommonDivisorProgram.View
{
    class UserInputOfNumbers
    {

        private string _result = "";
        private static bool TryUserInt(string userInput)
        {
            var regex = new Regex(@"^[-+]?[0-9]{1,3} [-+]?[0-9]{1,3}( [-+]?[0-9]{1,3})?( [-+]?[0-9]{1,3})?( [-+]?[0-9]{1,3})?$");
            return (regex.IsMatch(userInput));
        }

        public void ReadUserInputAndWriteResult(string userInput, string nameButton)
        {
            if (TryUserInt(userInput))
            {
                new GreatestCommonDivisor().ClearIntermediateData();
                var arrNumbers = ParseUserInput(userInput);
                var result = (nameButton == "GCDEuclide") ? RunGCDEuclidean(arrNumbers) : RunGCDStain(arrNumbers);
                FormatedResult(arrNumbers, result);
            }
            else
            {
                WarningMessage();
            }
        }

        private int[] ParseUserInput(string userInput)
        {
            var arr = userInput.Split(' ');
            var arrResult = new int[arr.Length];

            for (var i = 0; i < arr.Length; i++)
            {
                arrResult[i] = Convert.ToInt32(arr[i]);
            }

            return arrResult;
        }

        private int[] RunGCDEuclidean(int[] userNumbers)
        {
            var resArr = new int[2];
            int pass;
            
            if (userNumbers.Length == 5)
            {
                resArr[0] = new GreatestCommonDivisor().GCDEuclideanAlgorithm(userNumbers[0], userNumbers[1], userNumbers[2], userNumbers[3], userNumbers[4], out pass);
                resArr[1] = pass;
            }
            if (userNumbers.Length == 4)
            {
                resArr[0] = new GreatestCommonDivisor().GCDEuclideanAlgorithm(userNumbers[0], userNumbers[1], userNumbers[2], userNumbers[3], out pass);
                resArr[1] = pass;
            }
            if (userNumbers.Length == 3)
            {
                resArr[0] = new GreatestCommonDivisor().GCDEuclideanAlgorithm(userNumbers[0], userNumbers[1], userNumbers[2], out pass);
                resArr[1] = pass;
            }
            if (userNumbers.Length == 2)
            {
                resArr[0] = new GreatestCommonDivisor().GCDEuclideanAlgorithm(userNumbers[0], userNumbers[1], out pass);
                resArr[1] = pass;
            }
            return resArr;
        }

        private int[] RunGCDStain(int[] userNumbers)
        {
            var resArr = new int[2];
            resArr[0] = new GreatestCommonDivisor().GCDStainAlgorithm(userNumbers[0], userNumbers[1], out int pass);
            resArr[1] = pass;
            return resArr;
        }
        
        private void FormatedResult(int[] numbers, int[] resultGCD)
        {
            var s = new StringBuilder();
            s.AppendFormat("{0}", "НОД( ");
            foreach (var item in numbers)
            {
                s.AppendFormat("{0} ", item.ToString());
            }
            s.Append($") = {resultGCD[0]}");
            s.Append((resultGCD[1]== 0) ? "\n" : $" и кол-во итераций = {resultGCD[1]}\n");
            _result = s.ToString();
        }

        public string PrintResult()
        {
            return _result;
        }

        public void WarningMessage()
        {
            MessageBox.Show("Числа должны быть целыми и отделяться пробелами. Введите числа заново.");
        }


    }
}
