using System;

public class Booking
{
    public int ClientId { get; set; }
    public string ClientName { get; set; }
    public string ClientPhone { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public string Comment { get; set; }
    public Table AssignedTable { get; set; }

    public Booking(int clientId, string clientName, string clientPhone, string startTime, string endTime, string comment, Table assignedTable)
    {
        ClientId = clientId;
        ClientName = clientName;
        ClientPhone = clientPhone;
        StartTime = startTime;
        EndTime = endTime;
        Comment = comment;
        AssignedTable = assignedTable;
    }

    public void CreateBooking()
    {
        AssignedTable.UpdateSchedule(StartTime, $"{ClientName}, {ClientPhone}");
        AssignedTable.UpdateSchedule(EndTime, $"{ClientName}, {ClientPhone}");
    }

    public void ChangeBooking(string newStartTime, string newEndTime, string newComment)
    {
        CancelBooking();
        StartTime = newStartTime;
        EndTime = newEndTime;
        Comment = newComment;
        CreateBooking();
    }

    public void CancelBooking()
    {
        AssignedTable.UpdateSchedule(StartTime, "");
        AssignedTable.UpdateSchedule(EndTime, "");
    }
}