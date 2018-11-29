﻿using System.Collections.Generic;
using VectorProgram.Controller;
using VectorProgram.Model;
using VectorProgram.UserInput;
using VectorProgram.View;

namespace VectorProgram
{
    class ProgramRun
    {
        private IConsoleView _view;
        private FormattedOutput _formattedOutput;
        private IUserInputProcessor _userInput;

        public void Run(IConsoleView view)
        {
            _view = view;
            _userInput = new UserInputProcessor(_view);
            _formattedOutput = new FormattedOutput(_view);

            var vectors = CreateVectors();

            _formattedOutput.ShowVectors(vectors);

            CallActionsWithVectors(vectors[0], vectors[1]);
            CallScalarMultiplication(vectors[0], vectors[1]);
            CompareVectors(vectors[0], vectors[1]);
            CallAngleBetweenVectors(vectors[0], vectors[1]);

            _view.WaitForAnyKeyPress();
        }

        private List<Vector> CreateVectors()
        {
            Vector vectorFirst = RequestVector("first");
            Vector vectorSecond = RequestVector("second");

            return new List<Vector>()  { vectorFirst, vectorSecond, vectorFirst };
        }
        
        private void CallActionsWithVectors(Vector first, Vector second)
        {
            CallSimpleActionsWithVectors(first, second);
            CallVectorMultiplication(first, second);
            CallMultiplyVectorsByNumber(first, second);
        }

        private void CompareVectors(Vector first, Vector second)
        {
            var equalityResult = (first == second);
            var inequalityResult = first != second;
            _formattedOutput.ShowVectorsComparisonResults(first, second, equalityResult, inequalityResult);
        }

        private void CallAngleBetweenVectors(Vector first, Vector second)
        {
            var angle = VectorHelper.CalculateAngle(first, second);
            _formattedOutput.ShowAngleBetweenVectorsResult(first, second, angle);
        }

        private void CallSimpleActionsWithVectors(Vector first, Vector second)
        {
            var sumResult = first + second;
            var differenceResult = first - second;

            _formattedOutput.ShowSimpleActionsWithVectorsResults(first, second, sumResult, differenceResult);
        }

        private void CallScalarMultiplication(Vector first, Vector second)
        {
            var multiplicationResult = VectorHelper.CalculateScalarMultiplication(first, second);
            _formattedOutput.ShowScalarMultiplicationResult(first, second, multiplicationResult);
        }

        private void CallVectorMultiplication(Vector first, Vector second)
        {
            var vectorMultiplicationResult = VectorHelper.CalculateVectorMultiplication(first, second);
            _formattedOutput.ShowVectorsMultiplicationResult(first, second, vectorMultiplicationResult);
        }

        private void CallMultiplyVectorsByNumber(Vector first, Vector second)
        {
            var multiplier = RequestMultiplier();

            var multiplicationVectorsByNumberRight = new List<Vector>
            {
                (first * multiplier),
                (second * multiplier)
            };

            var multiplicationVectorsByNumberLeft = new List<Vector>
            {
                (multiplier * first),
                (multiplier * second)
            };
            
            _formattedOutput.ShowMultiplicationVectorsByNumberResults(first, second, multiplicationVectorsByNumberRight, multiplicationVectorsByNumberLeft, multiplier);
        }
        
        private Vector RequestVector(string orderByVectors)
        {
            var userInput = _userInput.RequestInput(DataType.Vector, $"Enter the coordinates of the {orderByVectors} three-dimensional vector separated by a space:");
            return ParseVector(userInput);
        }

        private double RequestMultiplier()
        {
            var userInput = _userInput.RequestInput(DataType.Multiplier, "Enter multiplier:");
            return DataParser.ParseDouble(userInput);
        }
                
        private Vector ParseVector(string userInput)
        {
            var coords = DataParser.ParseArray(userInput);
            return new Vector(coords[0], coords[1], coords[2]);
        }
    }
}
