﻿using System;
using Greatest_Common_Divisor.Model;

namespace Greatest_Common_Divisor.Algorithms
{
    public class EuclideanAlgorithm : IAlgorithmGcd
    {
        private readonly GcdResult _result = new GcdResult();

        public GcdResult Calculate(int[] numbers)
        {
            var iterationsCount = 0;
            if (numbers.Length == 5)
            {
                _result.GreatestCommonDivisor = AlgorithmEuclidean(numbers[0], numbers[1], numbers[2], numbers[3], numbers[4], out iterationsCount);

            }
            else if (numbers.Length == 4)
            {
                _result.GreatestCommonDivisor = AlgorithmEuclidean(numbers[0], numbers[1], numbers[2], numbers[3], out iterationsCount);
            }
            else if (numbers.Length == 3)
            {
                _result.GreatestCommonDivisor = AlgorithmEuclidean(numbers[0], numbers[1], numbers[2], out iterationsCount);
            }
            else if (numbers.Length == 2)
            {
                _result.GreatestCommonDivisor = AlgorithmEuclidean(numbers[0], numbers[1], out iterationsCount);
            }

            _result.NumberOfIterations = iterationsCount;
            return _result;
        }

        private int AlgorithmEuclidean(int first, int second, out int pass, int count = 0)
        {
            pass = count;
            if (first == 0 && second != 0)
            {
                return second;
            }

            if (second == 0 && first != 0)
            {
                return first;
            }

            if (first == 0 && second == 0)
            {
                return 1;
            }

            while (second != 0)
            {
                pass++;
                _result.AddCalculationHistory(first, second, pass);
                second = first % (first = second);
            }
            _result.AddCalculationHistory(first, first, ++pass);
            return Math.Abs(first);
        }

        private int AlgorithmEuclidean(int first, int second, int thirdNumber, out int pass)
        {
            var topTwo = AlgorithmEuclidean(first, second, out var step);
            var result = AlgorithmEuclidean(topTwo, thirdNumber, out var step1, step);
            pass = step1;
            return result;
        }

        private int AlgorithmEuclidean(int first, int second, int thirdNumber, int fourthNumber, out int pass)
        {
            var topThree = AlgorithmEuclidean(first, second, thirdNumber, out var step);
            var result = AlgorithmEuclidean(topThree, fourthNumber, out var step1, step);
            pass = step1;
            return result;
        }

        private int AlgorithmEuclidean(int first, int second, int thirdNumber, int fourthNumber, int fifthNumber, out int pass)
        {
            var topFour = AlgorithmEuclidean(first, second, thirdNumber, fourthNumber, out var step);
            var result = AlgorithmEuclidean(topFour, fifthNumber, out var step1, step);
            pass = step1;
            return result;
        }
    }
}