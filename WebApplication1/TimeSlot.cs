namespace WebApplication1;


public record TimeSlot
{
    public DateTime StartTime { get; init; }
    public DateTime EndTime { get; init; }

    public TimeSlot(DateTime startTime, DateTime endTime)
    {
        if (endTime <= startTime)
            throw new ArgumentException("End date must be greater than start date");
        
        StartTime = startTime;
        EndTime = endTime;
    }

    public int GetDuration()
    {
        return (int)(EndTime - StartTime).TotalMinutes;
    }
    
}
