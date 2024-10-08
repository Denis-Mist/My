using System;

namespace CalendarProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер дня недели, с которого начинается месяц (1-пн ... 7-вс)");
            int startDayOfWeek = Convert.ToInt32(Console.ReadLine());

            if (startDayOfWeek < 1 || startDayOfWeek > 7)
            {
                Console.WriteLine("Ошибка выбора дня недели");
                return;
            }

            Console.WriteLine("Введите день месяца");
            int dayOfMonth = Convert.ToInt32(Console.ReadLine());

            if (dayOfMonth < 1 || dayOfMonth > 31)
            {
                Console.WriteLine("Ошибка выбора дня месяца");
                return;
            }
            if (dayOfMonth >=1 && dayOfMonth <=5 || dayOfMonth>=8 && dayOfMonth<=10){
                Console.WriteLine("Выходной день");
                return; 
            }

            int dayOfWeek = (startDayOfWeek + dayOfMonth - 1) % 7;
            if (dayOfWeek == 6 || dayOfWeek == 0) 
            {
                Console.WriteLine("Выходной день");
            }
            else
            {
                Console.WriteLine("Рабочий день");
            }
        }
    }
}
