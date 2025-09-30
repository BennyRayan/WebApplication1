namespace WebApplication1.Domain.Events;

public record SessionScheduledEvent
{
     public DateTime TimeStemp { get; }
     public Guid AggregateID { get; }
     public Guid PatientId { get; }
     public Guid TherapistId { get; }
     public DateTime ScheduledAt { get; } 
     public SessionScheduledEvent(Guid aggregateId, Guid patientId, Guid therapistId, DateTime scheduledAt) 
     {
         TimeStemp = DateTime.UtcNow;
         AggregateID = aggregateId;
         PatientId = patientId;
         TherapistId = therapistId;
         ScheduledAt = scheduledAt; 
     }
 
}