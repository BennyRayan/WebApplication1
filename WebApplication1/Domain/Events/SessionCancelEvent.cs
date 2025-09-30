namespace WebApplication1.Domain.Events;

public record SessionCancelEvent
{
 public DateTime TimeStamp { get; }
 public Guid AggregateId { get; }
 public Guid PatientId { get; }
 public Guid TherapistId { get; }
 public string Reason { get; private set; }
 public SessionCancelEvent(Guid aggregateId, Guid patientId, Guid therapistId, string reason) 
 {
     TimeStamp = DateTime.UtcNow;
     AggregateId = aggregateId;
     PatientId = patientId;
     TherapistId = therapistId;
     Reason = reason;
 }
}