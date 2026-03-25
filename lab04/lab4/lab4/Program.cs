using System;
using System.Linq;

// Линейный конгруэнтный генератор (LCG)
class LCG
{
    private long _state;
    private const long M = 4294967296L; // 2^32
    private const long A = 1664525L;
    private const long C = 1L;

    public LCG(long seed = 42)
    {
        _state = seed;
    }

    public double Next()
    {
        _state = (A * _state + C) % M;
        return (double)_state / M;
    }
}

class Program
{
    // Вычисление среднего и дисперсии
    static (double mean, double variance) GetStats(double[] sample)
    {
        double mean = sample.Average();
        double variance = sample.Average(x => (x - mean) * (x - mean));
        return (mean, variance);
    }

    static void Main()
    {
        const int N = 100_000;

        // --- Собственный LCG-генератор ---
        var lcg = new LCG(seed: 52);
        double[] customSample = new double[N];
        for (int i = 0; i < N; i++)
            customSample[i] = lcg.Next();

        // --- Встроенный генератор C# ---
        var rng = new Random();
        double[] builtinSample = new double[N];
        for (int i = 0; i < N; i++)
            builtinSample[i] = rng.NextDouble();

        // --- Статистики ---
        var (meanCustom, varCustom) = GetStats(customSample);
        var (meanBuiltin, varBuiltin) = GetStats(builtinSample);

        // Теоретические значения для равномерного U[0, 1]
        double theoreticalMean = 0.5;
        double theoreticalVar = 1.0 / 12.0;

        // --- Вывод таблицы ---
        Console.WriteLine($"{"Параметр",-20} | {"Теория",-10} | {"Собственный БД",-15} | {"Встроенный БД"}");
        Console.WriteLine(new string('-', 70));
        Console.WriteLine($"{"Среднее (Mean)",-20} | {theoreticalMean,-10:F5} | {meanCustom,-15:F5} | {meanBuiltin:F5}");
        Console.WriteLine($"{"Дисперсия (Var)",-20} | {theoreticalVar,-10:F5} | {varCustom,-15:F5} | {varBuiltin:F5}");
    }
}