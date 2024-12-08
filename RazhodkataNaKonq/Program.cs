using System;

class KnightsTour
{
    static int[] dx = { 2, 1, -1, -2, -2, -1, 1, 2 };
    static int[] dy = { 1, 2, 2, 1, -1, -2, -2, -1 };

    static void Main()
    {
        int n = 5; // Размер на шахматната дъска NxN
        int[,] board = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                board[i, j] = -1; // Инициализация на дъската с -1 (непосетени полета)
            }
        }

        int startX = 0; // Начални координати на коня (x0)
        int startY = 0; // Начални координати на коня (y0)
        board[startX, startY] = 0; // Маркираме началното поле с ход 0

        if (SolveKnightsTour(board, startX, startY, 1, n))
        {
            PrintBoard(board);
        }
        else
        {
            Console.WriteLine("Няма решение.");
        }
    }

    static bool SolveKnightsTour(int[,] board, int x, int y, int moveNumber, int n)
    {
        if (moveNumber == n * n) return true; // Ако всички полета са посетени, връщаме успех

        for (int i = 0; i < 8; i++)
        {
            int nextX = x + dx[i];
            int nextY = y + dy[i];

            if (IsSafeMove(board, nextX, nextY, n))
            {
                board[nextX, nextY] = moveNumber; // Регистрираме хода
                if (SolveKnightsTour(board, nextX, nextY, moveNumber + 1, n))
                {
                    return true;
                }
                board[nextX, nextY] = -1; // Връщане назад (backtracking)
            }
        }

        return false;
    }

    static bool IsSafeMove(int[,] board, int x, int y, int n)
    {
        return x >= 0 && y >= 0 && x < n && y < n && board[x, y] == -1;
    }

    static void PrintBoard(int[,] board)
    {
        int n = board.GetLength(0);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"{board[i, j],3} ");
            }
            Console.WriteLine();
        }
    }
}
