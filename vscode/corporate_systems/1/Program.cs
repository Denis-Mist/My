using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double memory = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Калькулятор");
                Console.WriteLine("Функционал:");
                Console.WriteLine("Калькулятор поддерживает следующие операции: +, -, *, /, %, 1/x, x^2, sqrt(x), M+, M-, MR");
                Console.WriteLine();
                Console.WriteLine("Ограничения:");
                Console.WriteLine("Калькулятор не поддерживает комплексные числа.");
                Console.WriteLine();
                Console.WriteLine("Возможные ошибки:");
                Console.WriteLine("Деление на ноль, некорректный ввод, переполнение памяти при работе с большими числами.");
                Console.WriteLine();

                Console.Write("Введите операцию (+, -, *, /, %, 1/x, x^2, sqrt(x), M+, M-, MR): ");
                string operation = Console.ReadLine();

                if (operation == "M+")
                {
                    Console.Write("Введите число: ");
                    double number = Convert.ToDouble(Console.ReadLine());
                    memory += number;
                    Console.WriteLine("Memory: " + memory);
                }
                else if (operation == "M-")
                {
                    Console.Write("Введите число: ");
                    double number = Convert.ToDouble(Console.ReadLine());
                    memory -= number;
                    Console.WriteLine("Memory: " + memory);
                }
                else if (operation == "MR")
                {
                    Console.WriteLine("Memory: " + memory);
                }
                else
                {
                    Console.Write("Введите первое число: ");
                    double num1 = Convert.ToDouble(Console.ReadLine());

                    if (operation == "1/x")
                    {
                        if (num1 == 0)
                        {
                            Console.WriteLine("Ошибка: деление на ноль");
                        }
                        else
                        {
                            Console.WriteLine("Результат: " + (1 / num1));
                        }
                    }
                    else if (operation == "x^2")
                    {
                        Console.WriteLine("Результат: " + (num1 * num1));
                    }
                    else if (operation == "sqrt(x)")
                    {
                        if (num1 < 0)
                        {
                            Console.WriteLine("Ошибка: отрицательное число в квадратном корне");
                        }
                        else
                        {
                            Console.WriteLine("Результат: " + Math.Sqrt(num1));
                        }
                    }
                    else
                    {
                        Console.Write("Введите второе число: ");
                        double num2 = Convert.ToDouble(Console.ReadLine());

                        switch (operation)
                        {
                            case "+":
                                Console.WriteLine("Результат: " + (num1 + num2));
                                break;
                            case "-":
                                Console.WriteLine("Результат: " + (num1 - num2));
                                break;
                            case "*":
                                Console.WriteLine("Результат: " + (num1 * num2));
                                break;
                            case "/":
                                if (num2 == 0)
                                {
                                    Console.WriteLine("Ошибка: деление на ноль");
                                }
                                else
                                {
                                    Console.WriteLine("Результат: " + (num1 / num2));
                                }
                                break;
                            case "%":
                                Console.WriteLine("Результат: " + (num1 * (num2/100)));
                                break;
                            default:
                                Console.WriteLine("Недопустимая операция");
                                break;
                        }
                    }
                }

                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
            }
        }
    }
}
