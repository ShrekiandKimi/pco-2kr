using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("*********************************************************");
        Console.WriteLine("                   КОФЕЙНЫЙ АППАРАТ");
        Console.WriteLine("*********************************************************");
        
        // Инициализация запасов
        int water = GetIngredient("Введите количество воды в мл: ");
        int milk = GetIngredient("Введите количество молока в мл: ");
        
        // Статистика
        int americanoCount = 0;
        int latteCount = 0;
        int totalRevenue = 0;
        
        // Цены и рецепты
        const int AmericanoPrice = 150;
        const int LattePrice = 170;
        const int AmericanoWater = 300;
        const int LatteWater = 30;
        const int LatteMilk = 270;
        
        Console.WriteLine("\nНачинаем обслуживание...");
        
        // Основной цикл обслуживания
        while (true)
        {
            Console.WriteLine("\n" + new string('-', 40));
            Console.WriteLine($"Остаток: вода {water} мл, молоко {milk} мл");
            Console.Write("Выберите напиток (1 — американо, 2 — латте): ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1": // Американо
                    if (water >= AmericanoWater)
                    {
                        water -= AmericanoWater;
                        americanoCount++;
                        totalRevenue += AmericanoPrice;
                        Console.WriteLine("Ваш напиток готов.");
                    }
                    else
                    {
                        Console.WriteLine("Не хватает воды.");
                    }
                    break;
                    
                case "2": // Латте
                    if (water >= LatteWater && milk >= LatteMilk)
                    {
                        water -= LatteWater;
                        milk -= LatteMilk;
                        latteCount++;
                        totalRevenue += LattePrice;
                        Console.WriteLine("Ваш напиток готов.");
                    }
                    else if (water < LatteWater)
                    {
                        Console.WriteLine("Не хватает воды.");
                    }
                    else
                    {
                        Console.WriteLine("Не хватает молока.");
                    }
                    break;
                    
                default:
                    Console.WriteLine("Неверный выбор. Введите 1 или 2.");
                    continue;
            }
            
            // Проверка, можно ли приготовить еще хотя бы один напиток
            bool canMakeAmericano = water >= AmericanoWater;
            bool canMakeLatte = water >= LatteWater && milk >= LatteMilk;
            
            if (!canMakeAmericano && !canMakeLatte)
            {
                Console.WriteLine("\n" + new string('*', 40));
                Console.WriteLine("Ингредиенты подошли к концу!");
                break;
            }
        }
        
        // Вывод отчета
        GenerateReport(water, milk, americanoCount, latteCount, totalRevenue);
        
        Console.WriteLine("*********************************************************");
    }
    
    static int GetIngredient(string message)
    {
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out int amount) && amount >= 0)
            {
                return amount;
            }
            Console.WriteLine("Ошибка: введите неотрицательное число!");
        }
    }
    
    static void GenerateReport(int water, int milk, int americanoCount, int latteCount, int totalRevenue)
    {
        Console.WriteLine("\n*ОТЧЁТ*");
        Console.WriteLine("Ингредиентов осталось:");
        Console.WriteLine($"Вода: {water} мл");
        Console.WriteLine($"Молоко: {milk} мл");
        Console.WriteLine($"Кружек американо приготовлено: {americanoCount}");
        Console.WriteLine($"Кружек латте приготовлено: {latteCount}");
        Console.WriteLine($"Итого: {totalRevenue} рублей.");
    }
}