using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("*********************************************************");
        Console.WriteLine("               КОЛОНИЗАЦИЯ МАРСА");
        Console.WriteLine("*********************************************************");
        
        // Ввод данных
        Console.Write("Введите n: ");
        int n = int.Parse(Console.ReadLine() ?? "0");
        
        Console.Write("Введите a: ");
        int a = int.Parse(Console.ReadLine() ?? "0");
        
        Console.Write("Введите b: ");
        int b = int.Parse(Console.ReadLine() ?? "0");
        
        Console.Write("Введите w: ");
        int w = int.Parse(Console.ReadLine() ?? "0");
        
        Console.Write("Введите h: ");
        int h = int.Parse(Console.ReadLine() ?? "0");
        
        // Поиск максимальной толщины защиты
        int maxD = FindMaxProtectionThickness(n, a, b, w, h);
        
        Console.WriteLine($"Ответ d = {maxD}");
        Console.WriteLine("*********************************************************");
    }
    
    static int FindMaxProtectionThickness(int n, int a, int b, int w, int h)
    {
        int maxD = 0;
        
        // Перебираем возможные значения d
        for (int d = 0; d <= Math.Min(w, h); d++)
        {
            // Размер модуля с защитой
            int moduleWidth = a + 2 * d;
            int moduleHeight = b + 2 * d;
            
            // Проверяем, помещается ли модуль в поле
            if (moduleWidth > w || moduleHeight > h)
                break;
            
            // Максимальное количество модулей по горизонтали и вертикали
            int maxHorizontal = w / moduleWidth;
            int maxVertical = h / moduleHeight;
            
            // Общее количество модулей, которые можно разместить
            int totalModules = maxHorizontal * maxVertical;
            
            // Если можем разместить все n модулей
            if (totalModules >= n)
            {
                maxD = d;
            }
            else
            {
                break; // Большие значения d не подойдут
            }
        }
        
        return maxD;
    }
}