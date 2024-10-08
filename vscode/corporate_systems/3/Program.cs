// using System;

// class Program
// {
//     static void Main(string[] args)
//     {
//         Console.Write("Введите число: ");
//         int n = Convert.ToInt32(Console.ReadLine());
//         int reversedNumber = ReverseNumber(n);
//         Console.WriteLine("Результат: " + reversedNumber);
//     }

//     public static int ReverseNumber(int n, int reversed = 0)
//     {
//         if (n < 10) return reversed * 10 + n; 

//         int lastDigit = n % 10; 
//         int remainingDigits = n / 10; 

//         return ReverseNumber(remainingDigits, reversed * 10 + lastDigit);
//     }
// }

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите число m: ");
        int m = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите число n: ");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Результат: " + Ackermann(m, n));
    }

    public static int Ackermann(int m, int n)
    {
        if (m <= 0)
        {
            return n + 1;
        }
        else if (m > 0 && n == 0)
        {
            return Ackermann(m - 1, 1);
        }
        else
        {
            return Ackermann(m - 1, Ackermann(m, n - 1));
        }
    }
}