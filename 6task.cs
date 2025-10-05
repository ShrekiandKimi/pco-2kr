using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("*********************************************************");
        
        // Ввод данных
        Console.Write("Введите количество бактерий: ");
        int bacteria = int.Parse(Console.ReadLine() ?? "0");
        
        Console.Write("Введите количество антибиотика: ");
        int antibiotic = int.Parse(Console.ReadLine() ?? "0");
        
        Console.WriteLine();
        
        // Моделирование процесса
        SimulateGrowth(bacteria, antibiotic);
        
        Console.WriteLine("*********************************************************");
    }
    
    static void SimulateGrowth(int initialBacteria, int antibioticDrops)
    {
        int bacteria = initialBacteria;
        int hour = 1;
        
        while (bacteria > 0 && antibioticDrops > 0 && hour <= 100) // Защита от бесконечного цикла
        {
            // 1. Бактерии размножаются (удваиваются)
            bacteria *= 2;
            
            // 2. Действие антибиотика
            int killPower = 11 - hour; // В 1-й час убивает 10, во 2-й - 9, и т.д.
            if (killPower > 0)
            {
                int killed = Math.Min(bacteria, killPower * antibioticDrops);
                bacteria -= killed;
            }
            else
            {
                // Антибиотик перестал действовать
                antibioticDrops = 0;
            }
            
            // Выводим результат текущего часа
            Console.WriteLine($"После {hour} часа бактерий осталось {bacteria}");
            
            // Проверяем условия завершения
            if (bacteria <= 0)
            {
                Console.WriteLine("Все бактерии уничтожены!");
                break;
            }
            
            if (killPower <= 0)
            {
                Console.WriteLine("Антибиотик перестал действовать!");
                break;
            }
            
            hour++;
        }
        
        // Если бактерии остались после завершения действия антибиотика
        if (bacteria > 0 && antibioticDrops == 0)
        {
            Console.WriteLine($"\nБактерии продолжают расти! Осталось: {bacteria}");
        }
    }
}