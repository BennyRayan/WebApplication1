namespace WebApplication1.Domain.Entities;


public class Therapist
{
    public Guid Id {  get; } = Guid.NewGuid();
    public string Name {  get; private set; }
    public string LicenseNumber {  get; private  set; }
    public List<DayOfWeek> FreeDays {  get; private  set; } = new List<DayOfWeek>();

    public Therapist(string name, string licenseNumber)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty", nameof(name));
        ChecksForLicenseNumber(licenseNumber);
        
        Name = name;
        LicenseNumber = licenseNumber;
    }
    
    public void AddAvailableDay(DayOfWeek day)
    {
        if (!FreeDays.Contains(day) && IsWeekday(day))
            FreeDays.Add(day);
    }
        
    public bool IsAvailableOn(DayOfWeek day) => FreeDays.Contains(day);
    
    private void ChecksForLicenseNumber(string licenseNumber)
    {
        if (string.IsNullOrWhiteSpace(licenseNumber))
            throw new ArgumentException("license number cannot be empty", nameof(licenseNumber));
        if (licenseNumber.Length!= 8)
            throw new ArgumentException("license number must be 8 digits long", nameof(licenseNumber));
        if (!licenseNumber.All(char.IsDigit))
            throw new ArgumentException("license number must only contain numbers", nameof(licenseNumber));
        
    }
    private bool IsWeekday(DayOfWeek day) => day != DayOfWeek.Saturday && day != DayOfWeek.Sunday;
}
