using System;
using System.Collections.Generic;

class LabyrinthPaths
{
    static List<string> paths = new List<string>(); // Списък за съхранение на намерените пътища
    static char[,] labyrinth;
    static int rows, cols;

    static void Main()
    {
        // Примерен вход
        rows = 3;
        cols = 3;
        labyrinth = new char[,]
        {
            { '-', '-', '-' },
            { '-', '*', '-' },
            { '-', '-', 'e' }
        };

        FindPaths(0, 0, ""); // Започваме от горния ляв ъгъл
        foreach (var path in paths)
        {
            Console.WriteLine(path);
        }
    }

    static void FindPaths(int row, int col, string currentPath)
    {
        if (!IsInBounds(row, col) || labyrinth[row, col] == '*' || labyrinth[row, col] == 'v')
        {
            return; // Извън границите на лабиринта, на стена или вече посетено поле
        }

        if (labyrinth[row, col] == 'e')
        {
            paths.Add(currentPath); // Добавяме намерения път
            return;
        }

        labyrinth[row, col] = 'v'; // Маркираме текущото поле като посетено

        // Рекурсивно изследваме всички посоки
        FindPaths(row, col + 1, currentPath + "R"); // Надясно
        FindPaths(row + 1, col, currentPath + "D"); // Надолу
        FindPaths(row, col - 1, currentPath + "L"); // Наляво
        FindPaths(row - 1, col, currentPath + "U"); // Нагоре

        labyrinth[row, col] = '-'; // Отмаркираме (връщане назад)
    }

    static bool IsInBounds(int row, int col)
    {
        return row >= 0 && row < rows && col >= 0 && col < cols;
    }
}
