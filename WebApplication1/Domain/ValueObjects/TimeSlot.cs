namespace WebApplication1.Domain.ValueObjects;


public record TimeSlot
{
    public DateTime StartTime { get; init; }
    public DateTime EndTime { get; init; }

    public TimeSlot(DateTime startTime, DateTime endTime)
    {
        if ((endTime- startTime).TotalMinutes < 15)
            throw new ArgumentException("End date must be greater than 15 minutes after start date");
        
        StartTime = startTime;
        EndTime = endTime;
    }

    public int GetDuration()
    {
        return (int)(EndTime - StartTime).TotalMinutes;
    }
    
}
