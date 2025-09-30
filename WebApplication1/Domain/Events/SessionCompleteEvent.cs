namespace WebApplication1.Domain.Events;

public record SessionCompleteEvent
{
    public DateTime TimeStamp { get; }
    public Guid AggregateId { get; }
    public Guid PatientId { get; }
    public Guid TherapistId { get; }
    public SessionCompleteEvent(Guid aggregateId, Guid patientId, Guid therapistId) 
    {
        TimeStamp = DateTime.Now;
        AggregateId = aggregateId;
        PatientId = patientId;
        TherapistId = therapistId;
    }
}