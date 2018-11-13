﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TriangleLib.Model;

namespace TriangleLib.View
{
    public interface IConsoleView
    {
        void ShowWarningMessage();
        void PrintPerimetrTriangle(double perimetr);
        void PrintAreaTriangle(double square);
        void PrintDetailsTriangle(Triangle triangle);
        void ShowWarningMessageTriangleNotExist();
        void WriteLine(string text);
        string ReadLine();
        void Clear();
        ConsoleKeyInfo ReadKey();
    }
}
