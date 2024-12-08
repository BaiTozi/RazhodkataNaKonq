using System;

class TowersOfHanoi
{
    static void Main()
    {
        int n = 3; // Брой дискове
        SolveHanoi(n, 1, 3, 2); // Преместване от стълб 1 на стълб 3, използвайки стълб 2 като помощен
    }

    static void SolveHanoi(int n, int from, int to, int aux)
    {
        if (n == 0) return; // Ако няма дискове, нищо не правим

        // Преместване на (n-1) диска от 'from' на 'aux', използвайки 'to' като помощен
        SolveHanoi(n - 1, from, aux, to);

        // Преместване на най-долния диск от 'from' на 'to'
        Console.WriteLine($"{from} --> {to}");

        // Преместване на (n-1) диска от 'aux' на 'to', използвайки 'from' като помощен
        SolveHanoi(n - 1, aux, to, from);
    }
}
