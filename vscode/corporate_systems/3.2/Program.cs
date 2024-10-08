using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // создание столов
        List<Table> tables = new List<Table>();
        tables.Add(new Table(1, "у окна", 4));
        tables.Add(new Table(2, "у прохода", 4));
        tables.Add(new Table(3, "у выхода", 4));

        // создание бронирований
        List<Booking> bookings = new List<Booking>();
        bookings.Add(new Booking(1, "Макс", "88005553535", "12:00", "14:00", "Комментарий", tables[0]));
        bookings.Add(new Booking(2, "Анна", "5745552377", "16:00", "18:00", "Комментарий", tables[1]));

        // вывод информации о столах
        foreach (var table in tables)
        {
            table.PrintInfo();
        }

        // вывод информации о бронированиях
        foreach (var booking in bookings)
        {
            Console.WriteLine($"Клиент: {booking.ClientName}, Телефон: {booking.ClientPhone}, Время: {booking.StartTime} - {booking.EndTime}");
        }
    }
}