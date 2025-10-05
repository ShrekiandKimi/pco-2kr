using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("*********************************************************");
        
        // Первый пример
        SimplifyFraction();
        
        Console.WriteLine("\n" + new string('-', 40) + "\n");
        
        // Второй пример
        SimplifyFraction();
        
        Console.WriteLine("\n" + new string('-', 40) + "\n");
        
        // Третий пример
        SimplifyFraction();
        
        Console.WriteLine("\n" + new string('-', 40) + "\n");
        
        // Четвертый пример
        SimplifyFraction();
        
        Console.WriteLine("*********************************************************");
    }
    
    static void SimplifyFraction()
    {
        try
        {
            Console.Write("Введите числитель: ");
            int numerator = int.Parse(Console.ReadLine() ?? "0");
            
            Console.Write("Введите знаменатель: ");
            int denominator = int.Parse(Console.ReadLine() ?? "1");
            
            if (denominator == 0)
            {
                Console.WriteLine("Ошибка: знаменатель не может быть равен 0!");
                return;
            }
            
            SimplifyAndPrint(numerator, denominator);
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: введите целые числа!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
    
    static void SimplifyAndPrint(int numerator, int denominator)
    {
        // Находим наибольший общий делитель (НОД)
        int gcd = FindGCD(Math.Abs(numerator), Math.Abs(denominator));
        
        // Сокращаем дробь
        int simplifiedNumerator = numerator / gcd;
        int simplifiedDenominator = denominator / gcd;
        
        // Обрабатываем случай, когда знаменатель становится отрицательным
        if (simplifiedDenominator < 0)
        {
            simplifiedNumerator = -simplifiedNumerator;
            simplifiedDenominator = -simplifiedDenominator;
        }
        
        // Выводим результат
        if (simplifiedDenominator == 1)
        {
            Console.WriteLine($"Результат: {simplifiedNumerator}");
        }
        else
        {
            Console.WriteLine($"Результат: {simplifiedNumerator} / {simplifiedDenominator}");
        }
    }
    
    // Функция для нахождения наибольшего общего делителя (НОД)
    // с помощью алгоритма Евклида
    static int FindGCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}