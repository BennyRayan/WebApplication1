namespace WebApplication1.Domain.Events;

public record SessionStartedEvent
{
    public Guid AggregateID { get; }
    public Guid PatientId { get; }
    public Guid TherapistId { get; }
    public DateTime StartedAt { get; } 
    public DateTime TimeStamp { get; } = DateTime.UtcNow;
    public SessionStartedEvent(Guid aggregateId, Guid patientId, Guid therapistId, DateTime startedAt) 
    {
        AggregateID = aggregateId;
        PatientId = patientId;
        TherapistId = therapistId;
        StartedAt = startedAt;
        TimeStamp = DateTime.UtcNow;
    }
}