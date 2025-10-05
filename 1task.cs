using System;

namespace TaylorSeries
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ВЫЧИСЛЕНИЕ РЯДА МАКЛОРЕНА ===");
            
            // Вычисление значения функции с заданной точностью
            CalculateWithPrecision();
            
            Console.WriteLine("\n" + new string('-', 40) + "\n");
            
            // Вычисление n-го члена ряда
            CalculateNthTerm();
        }
        
        // Функция для вычисления значения с заданной точностью
        static void CalculateWithPrecision()
        {
            Console.WriteLine("1. Вычисление значения функции с заданной точностью");
            
            try
            {
                Console.Write("Введите x (-1 < x < 1): ");
                double x = double.Parse(Console.ReadLine());
                
                if (x <= -1 || x >= 1)
                {
                    Console.WriteLine("Ошибка: x должен быть в интервале (-1;1)");
                    return;
                }
                
                Console.Write("Введите точность e (e < 0.01): ");
                double epsilon = double.Parse(Console.ReadLine());
                
                if (epsilon >= 0.01)
                {
                    Console.WriteLine("Ошибка: точность должна быть меньше 0.01");
                    return;
                }
                
                double result = 0;
                double term;
                int n = 0;
                
                Console.WriteLine("\nВычисление...");
                Console.WriteLine("n\tЧлен ряда\tТекущая сумма");
                Console.WriteLine(new string('-', 35));
                
                do
                {
                    term = CalculateTerm(x, n);
                    result += term;
                    
                    Console.WriteLine($"{n}\t{term:F8}\t{result:F8}");
                    
                    n++;
                }
                while (Math.Abs(term) > epsilon && n < 1000); // Защита от бесконечного цикла
                
                // Сравнение с точным значением (ln(1+x))
                double exactValue = Math.Log(1 + x);
                double error = Math.Abs(result - exactValue);
                
                Console.WriteLine("\nРезультаты:");
                Console.WriteLine($"Вычисленное значение: {result:F8}");
                Console.WriteLine($"Точное значение ln(1+{x}): {exactValue:F8}");
                Console.WriteLine($"Погрешность: {error:E4}");
                Console.WriteLine($"Количество итераций: {n}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: неверный формат ввода");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        
        // Функция для вычисления n-го члена ряда
        static void CalculateNthTerm()
        {
            Console.WriteLine("2. Вычисление n-го члена ряда");
            
            try
            {
                Console.Write("Введите x (-1 < x < 1): ");
                double x = double.Parse(Console.ReadLine());
                
                if (x <= -1 || x >= 1)
                {
                    Console.WriteLine("Ошибка: x должен быть в интервале (-1;1)");
                    return;
                }
                
                Console.Write("Введите номер члена n (n >= 0): ");
                int n = int.Parse(Console.ReadLine());
                
                if (n < 0)
                {
                    Console.WriteLine("Ошибка: n должен быть неотрицательным");
                    return;
                }
                
                double term = CalculateTerm(x, n);
                
                Console.WriteLine($"\n{n}-й член ряда: {term:F8}");
                Console.WriteLine($"Абсолютное значение: {Math.Abs(term):E4}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: неверный формат ввода");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        
        // Функция для вычисления n-го члена ряда Маклорена для ln(1+x)
        static double CalculateTerm(double x, int n)
        {
            if (n == 0)
                return x; // Первый член ряда
            
            // Ряд Маклорена для ln(1+x): x - x²/2 + x³/3 - x⁴/4 + ...
            // Общая формула: (-1)^(n) * x^(n+1) / (n+1)
            
            double sign = (n % 2 == 0) ? 1 : -1; // Чередование знаков
            double numerator = Math.Pow(x, n + 1);
            double denominator = n + 1;
            
            return sign * numerator / denominator;
        }
    }
}