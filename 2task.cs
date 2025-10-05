using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("*********************************************************");
        
        // Первый пример
        Console.Write("Введите номер билета: ");
        string input1 = Console.ReadLine();
        if (!string.IsNullOrEmpty(input1) && int.TryParse(input1, out int ticket1))
        {
            bool result1 = IsLuckyTicket(ticket1);
            Console.WriteLine(result1);
        }
        else
        {
            Console.WriteLine("Ошибка: введите корректный номер билета!");
        }
        
        // Второй пример
        Console.Write("Введите номер билета: ");
        string input2 = Console.ReadLine();
        if (!string.IsNullOrEmpty(input2) && int.TryParse(input2, out int ticket2))
        {
            bool result2 = IsLuckyTicket(ticket2);
            Console.WriteLine(result2);
        }
        else
        {
            Console.WriteLine("Ошибка: введите корректный номер билета!");
        }
        
        Console.WriteLine("*********************************************************");
    }
    
    static bool IsLuckyTicket(int ticket)
    {
        if (ticket < 100000 || ticket > 999999)
        {
            Console.WriteLine("Ошибка: номер билета должен быть шестизначным!");
            return false;
        }
        
        // Получаем отдельные цифры билета
        int digit1 = ticket / 100000;
        int digit2 = (ticket / 10000) % 10;
        int digit3 = (ticket / 1000) % 10;
        int digit4 = (ticket / 100) % 10;
        int digit5 = (ticket / 10) % 10;
        int digit6 = ticket % 10;
        
        int sumFirstThree = digit1 + digit2 + digit3;
        int sumLastThree = digit4 + digit5 + digit6;
        
        return sumFirstThree == sumLastThree;
    }
}