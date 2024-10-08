using System;
using System.Collections.Generic;

namespace CalendarProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите сумму: ");
            int sum = Convert.ToInt32(Console.ReadLine());

            if (sum <= 0 || sum>150000 || sum%100!=0)
            {
                Console.WriteLine("Ошибка");
                return;
            }

            int[] denominations = { 5000, 2000, 1000, 500, 200, 100 };
            int[] counts = new int[denominations.Length];

            for (int i = 0; i < denominations.Length; i++)
            {
                while (sum - denominations[i] >= 0)
                {
                    sum -= denominations[i];
                    counts[i]++;
                }
            }

            Console.WriteLine("Количество купюр:");
            for (int i = 0; i < denominations.Length; i++)
            {
                Console.WriteLine($"{denominations[i]}: {counts[i]}");
            }
        }
    }
}