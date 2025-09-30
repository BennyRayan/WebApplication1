using WebApplication1.Domain.Events;

namespace WebApplication1.Domain.Entities;


public class MediationSession
{
    public enum Status
    {
        Scheduled, 
        InProgress, 
        Completed, 
        Canceled
    }
    public Guid Id { get; } = Guid.NewGuid();   
    public Guid PatientId { get; private set; }
    public Guid TherapistId { get; private set; }
    public DateTime ScheduledAt { get; private set; }
    private List<Object> Events = new List<Object>();
    
    public string Reason { get; private set; }

    public Status CurrentStatus { get; private set; }
    
    public MediationSession(Guid patientId, Guid therapistId, DateTime scheduledAt)
    {
        PatientId = patientId;
        TherapistId = therapistId;
        ScheduledAt = scheduledAt;
        CurrentStatus = Status.Scheduled;
    }

    public void Start()
    {
        DateTime now = DateTime.Now;
        if (CurrentStatus != Status.Scheduled)
            throw new InvalidOperationException
                ("Mediation session cannot be started if it is not scheduled");
        if ((now - ScheduledAt).TotalMinutes >= 15)
            throw new InvalidOperationException
                ("Mediation session cannot be started more than 15 minutes after scheduled time");
        if ((now - ScheduledAt).TotalMinutes <= -15)
            throw new InvalidOperationException
                ("Mediation session cannot be started more than 15 minutes before scheduled time");
        var evt = new SessionStartedEvent(Id , PatientId, TherapistId, ScheduledAt);
        Apply(evt);
        Events.Add(evt);
    }


    public void Complete()
    {
        if (CurrentStatus != Status.InProgress)
            throw new InvalidOperationException
                ("Mediation session cannot be completed if it is not in progress");
        var evt = new SessionCompleteEvent(Id, PatientId, TherapistId);
        Apply(evt);
        Events.Add(evt);
        

    }

    public void Cancel(string reason)
    {
        if (CurrentStatus!= Status.Scheduled)
            throw new InvalidOperationException
                ("Mediation session cannot be canceled if it is not scheduled");
        var evt = new SessionCancelEvent(Id, PatientId, TherapistId, reason);
        Apply(evt);
        Events.Add(evt);
    }
    private void Apply(object @event)
    {
        if (@event is SessionScheduledEvent)
            CurrentStatus = Status.Scheduled;
        if (@event is SessionStartedEvent )
            CurrentStatus = Status.InProgress;
        if (@event is SessionCompleteEvent)
            CurrentStatus = Status.Completed;
        if (@event is SessionCancelEvent)
        {
            CurrentStatus = Status.Canceled;
            Reason = ((SessionCancelEvent)@event).Reason;
        }
    }
    
    
    public IReadOnlyList<object> GetUncommittedEvents() => Events.AsReadOnly();
    
}