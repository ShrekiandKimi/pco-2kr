using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== УГАДАЙ ЧИСЛО ===");
        Console.WriteLine("Загадайте число от 0 до 63.");
        Console.WriteLine("Отвечайте на вопросы: 1 - да, 0 - нет");
        Console.WriteLine("Нажмите Enter, когда будете готовы...");
        Console.ReadLine();
        
        GuessNumber();
    }
    
    static void GuessNumber()
    {
        int low = 0;
        int high = 63;
        int questionsCount = 0;
        int maxQuestions = 7;
        
        while (low <= high && questionsCount < maxQuestions)
        {
            int mid = (low + high) / 2;
            
            // Если остался один элемент - это наше число
            if (low == high)
            {
                Console.WriteLine($"\nВаше число: {low}!");
                return;
            }
            
            // Если осталось два элемента - задаем вопрос про первый
            if (high - low == 1)
            {
                questionsCount++;
                Console.Write($"\nВопрос {questionsCount}: Ваше число равно {low}? (1-да/0-нет): ");
                if (GetUserAnswer())
                {
                    Console.WriteLine($"\nВаше число: {low}!");
                    return;
                }
                else
                {
                    Console.WriteLine($"\nВаше число: {high}!");
                    return;
                }
            }
            
            questionsCount++;
            Console.Write($"\nВопрос {questionsCount}: Ваше число больше {mid}? (1-да/0-нет): ");
            
            if (GetUserAnswer())
            {
                low = mid + 1;
            }
            else
            {
                high = mid;
            }
        }
        
        // Если вышли из цикла - выводим оставшийся диапазон
        if (low == high)
        {
            Console.WriteLine($"\nВаше число: {low}!");
        }
        else
        {
            Console.WriteLine($"\nВаше число в диапазоне от {low} до {high}!");
        }
        
        Console.WriteLine($"Угадано за {questionsCount} вопросов!");
    }
    
    static bool GetUserAnswer()
    {
        while (true)
        {
            string input = Console.ReadLine();
            
            if (input == "1")
                return true;
            else if (input == "0")
                return false;
            else
                Console.Write("Пожалуйста, введите 1 (да) или 0 (нет): ");
        }
    }
}