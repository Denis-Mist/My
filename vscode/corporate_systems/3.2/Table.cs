using System;
using System.Collections.Generic;

public class Table
{
    public int Id { get; set; }
    public string Location { get; set; }
    public int Seats { get; set; }
    public Dictionary<string, string> Schedule { get; set; }

    public Table(int id, string location, int seats)
    {
        Id = id;
        Location = location;
        Seats = seats;
        Schedule = new Dictionary<string, string>();
        CreateSchedule();
    }

    public void ChangeInfo(int id, string location, int seats)
    {
        Id = id;
        Location = location;
        Seats = seats;
    }

    public void CreateSchedule()
    {
        for (int i = 9; i < 18; i++)
        {
            string time = $"{i}:00-{i + 1}:00";
            Schedule.Add(time, "");
        }
    }

    public void PrintInfo()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Расположение: {Location}");
        Console.WriteLine($"Количество мест: {Seats}");
        Console.WriteLine("Расписание:");
        foreach (var pair in Schedule)
        {
            Console.WriteLine($"{pair.Key} - {pair.Value}");
        }
    }

    public void UpdateSchedule(string time, string bookingInfo)
    {
        if (Schedule.ContainsKey(time))
        {
            Schedule[time] = bookingInfo;
        }
    }

    public bool IsAvailable(string time)
    {
        return Schedule[time] == "";
    }
}