// // 1  8 в списке

// using System;

// class Row
// {
//     static void Main(string[] args)
//     {
//         Console.Write("Введите e (точность): ");
//         double e = Convert.ToDouble(Console.ReadLine());

//         Console.Write("Введите x: ");
//         double x = Convert.ToDouble(Console.ReadLine());

//         double result = CalculateMaclaurinSeries(x, e);
//         Console.WriteLine("Ответ: " + result);

//         Console.Write("Введите n: ");
//         int n = Convert.ToInt32(Console.ReadLine());
//         if (n < 1){
//             Console.WriteLine("n не может быть меньше 1");
//             return ;
//         }

//         result = CalculateNthMember(x, n);
//         Console.WriteLine("Ответ: " + result);
//     }

//     static double CalculateMaclaurinSeries(double x, double e)
//     {
//         double result = 0;
//         int n = 1;
//         double term;

//         do
//         {
//             term = Math.Pow(x, 2 * n) / Factorial(2 * n);
//             result += term;
//             n++;
//         } while (Math.Abs(term) > e);

//         return result + 1;
//     }

//     static double CalculateNthMember(double x, int n)
//     {
//         if (n == 1){
//             return 1;
//         }
//         n--;
//         return Math.Pow(x, 2 * n) / Factorial(2 * n);
//     }

//     static double Factorial(int n)
//     {
//         double result = 1;
//         for (int i = 2; i <= n; i++)
//         {
//             result *= i;
//         }
//         return result;
//     }
// }

// //2

// using System;

// class HappyTicket
// {
//     static void Main(string[] args)
//     {
//         Console.Write("Введите номер билета: ");
//         int ticketNumber = Convert.ToInt32(Console.ReadLine());

//         bool isHappyTicket = IsHappyTicket(ticketNumber);

//         Console.WriteLine(isHappyTicket);
//     }

//     static bool IsHappyTicket(int ticketNumber)
//     {
//         int firstThreeDigitsSum = (ticketNumber / 100000) + ((ticketNumber / 10000) % 10) + ((ticketNumber / 1000) % 10);
//         int lastThreeDigitsSum = (ticketNumber % 10) + ((ticketNumber / 10) % 10) + ((ticketNumber / 100) % 10);

//         return firstThreeDigitsSum == lastThreeDigitsSum;
//     }
// }

// //3

// using System;

// class FractionReducer
// {
//     static void Main(string[] args)
//     {
//         Console.Write("Введите числитель: ");
//         int numerator = Convert.ToInt32(Console.ReadLine());

//         Console.Write("Введите знаменатель: ");
//         int denominator = Convert.ToInt32(Console.ReadLine());

//         if (denominator == 0)
//         {
//             Console.WriteLine("Знаменатель не может быть равен 0.");
//             return;
//         }
//         bool nuzen = false;
//         if (numerator > 0 && denominator < 0 || numerator < 0 && denominator > 0){
//             nuzen = true;
//         }

//         int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
//         int reducedNumerator = numerator / gcd;
//         int reducedDenominator = denominator / gcd;

//         Console.WriteLine("Результат: " + (nuzen ? "-" : "") + Math.Abs(reducedNumerator) + " / " + Math.Abs(reducedDenominator));
//     }

//     static int GCD(int a, int b)
//     {
//         while (b != 0)
//         {
//             int temp = b;
//             b = a % b;
//             a = temp;
//         }
//         return a;
//     }
// }

// //4

// using System;

// class GuessingGame
// {
//     static void Main(string[] args)
//     {
//         int min = 0;
//         int max = 63;
//         int attempts = 0;

//         Console.WriteLine("Think of a number between 0 and 63.");

//         while (attempts < 7)
//         {
//             int mid = (min + max) / 2;
//             Console.WriteLine($"Is your number greater than {mid}? (1 for yes, 0 for no)");
//             int response = Convert.ToInt32(Console.ReadLine());

//             if (response == 1)
//             {
//                 min = mid + 1;
//             }
//             else
//             {
//                 max = mid;
//             }

//             attempts++;
//         }

//         Console.WriteLine($"I think your number is {min}.");
//     }
// }

// //5

// using System;

// namespace CoffeeMachine
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             static void report(int waterAmount,int milkAmount,int americanoCount,int latteCount,int totalEarnings){
//                 Console.WriteLine("*Отчёт*");
//                 Console.WriteLine($"Ингредиентов осталось:");
//                 Console.WriteLine($"Вода: {waterAmount} мл");
//                 Console.WriteLine($"Молоко: {milkAmount} мл");
//                 Console.WriteLine($"Кружек американо приготовлено: {americanoCount}");
//                 Console.WriteLine($"Кружек латте приготовлено: {latteCount}");
//                 Console.WriteLine($"Итого: {totalEarnings} рублей.");
//             }
//             Console.Write("Введите количество воды в мл: ");
//             int waterAmount = Convert.ToInt32(Console.ReadLine());

//             Console.Write("Введите количество молока в мл: ");
//             int milkAmount = Convert.ToInt32(Console.ReadLine());

//             int americanoCount = 0;
//             int latteCount = 0;
//             int totalEarnings = 0;

//             while (true)
//             {
//                 if (waterAmount < 35 || (milkAmount < 270 && waterAmount<300)){
//                     report(waterAmount, milkAmount, americanoCount, latteCount, totalEarnings);
//                     return ;
//                 }
//                 Console.Write("Выберите напиток (1 — американо, 2 — латте): ");
//                 int choice = Convert.ToInt32(Console.ReadLine());

//                 if (choice == 1) // Американо :)
//                 {
//                     if (waterAmount >= 300)
//                     {
//                         waterAmount -= 300;
//                         americanoCount++;
//                         totalEarnings += 150;
//                         Console.WriteLine("Ваш напиток готов.");
//                     }
//                     else
//                     {
//                         Console.WriteLine("Не хватает воды");
//                     }
//                 }
//                 else if (choice == 2) // латэ :)
//                 {
//                     if (waterAmount >= 30 && milkAmount >= 270)
//                     {
//                         waterAmount -= 30;
//                         milkAmount -= 270;
//                         latteCount++;
//                         totalEarnings += 170;
//                         Console.WriteLine("Ваш напиток готов.");
//                     }
//                     else if (waterAmount < 30)
//                     {
//                         Console.WriteLine("Не хватает воды");
//                         report(waterAmount, milkAmount, americanoCount, latteCount, totalEarnings);
//                         return ;
//                     }
//                     else
//                     {
//                         Console.WriteLine("Не хватает молока");
//                     }
//                 }

//                 if (waterAmount < 30 && milkAmount < 270)
//                 {
//                     break;
//                 }
//             }

//             report(waterAmount, milkAmount, americanoCount, latteCount, totalEarnings);
//         }
//     }
// }


//// 6 

using System;

namespace BacteriaAntibiotic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество бактерий:");
            int bacteriaCount = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество антибиотика:");
            int antibioticDrops = int.Parse(Console.ReadLine());

            int hour = 1;
            while (bacteriaCount > 0 && antibioticDrops > 0)
            {
                // Увеличение количества бактерий
                bacteriaCount *= 2;

                // Действие антибиотика
                if (hour <= 10) // Антибиотик действует первые 10 часов
                {
                    int bacteriaKilled = antibioticDrops * (10 - (hour - 1));
                    bacteriaCount = Math.Max(0, bacteriaCount - bacteriaKilled);
                }

                Console.WriteLine($"После {hour} часа бактерий осталось {bacteriaCount}");
                hour++;

                // Проверка, не закончился ли антибиотик
                if (hour > 10)
                {
                    antibioticDrops = 0;
                }
            }

            if (bacteriaCount <= 0)
            {
                Console.WriteLine("Все бактерии погибли.");
            }
            else
            {
                Console.WriteLine("Антибиотик перестал действовать.");
            }

            Console.ReadKey();
        }
    }
}


// // 7

// using System;

// class MarsBase
// {
//     static void Main(string[] args)
//     {
//         Console.Write("Enter n: ");
//         int n = Convert.ToInt32(Console.ReadLine());

//         Console.Write("Enter a: ");
//         int a = Convert.ToInt32(Console.ReadLine());

//         Console.Write("Enter b: ");
//         int b = Convert.ToInt32(Console.ReadLine());

//         Console.Write("Enter w: ");
//         int w = Convert.ToInt32(Console.ReadLine());

//         Console.Write("Enter h: ");
//         int h = Convert.ToInt32(Console.ReadLine());

//         int d = 0;
//         while (true)
//         {
//             int moduleArea = (a + 2 * d) * (b + 2 * d);
//             int totalAreaRequired = n * moduleArea;
//             if (totalAreaRequired > w * h)
//             {
//                 break;
//             }
//             d++;
//         }

//         Console.WriteLine("Answer: d = " + (d - 1));
//     }
// }