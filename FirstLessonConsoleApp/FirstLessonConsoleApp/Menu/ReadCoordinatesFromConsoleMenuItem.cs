﻿using FirstLessonConsoleApp.Model;
using FirstLessonConsoleApp.View;
using System.Collections.Generic;

namespace FirstLessonConsoleApp.Menu
{
    public class ReadCoordinatesFromConsoleMenuItem : MenuItem
    {
        public ReadCoordinatesFromConsoleMenuItem(int orderNumber, string text, IView view) : 
            base(orderNumber, text, view)
        {
        }

        public override void Execute()
        {
            var coordinates = new List<Coordinate>();

            GetView().PrintMessage("Enter the coordinates:");

            var coordinate = new Coordinate();

            while (coordinate != null)
            {
                var userInput = GetView().RequestInput();
                coordinate = CoordinatesHelper.ParseUserInputToCoordinate(userInput);
                if (coordinate != null)
                {
                    coordinates.Add(coordinate);
                }
            }

            GetView().PrintCoordinates(coordinates);
        }
    }
}
