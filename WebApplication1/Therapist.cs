using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace WebApplication1;



public class Therapist
{
    public Guid Id {  get; } = Guid.NewGuid();
    public string Name {  get; private set; }
    public string LicenseNumber {  get; private  set; }
    public List<DayOfWeek> FreeDays {  get; private  set; } = new List<DayOfWeek>();

    public Therapist(string name, string lLicenseNumber)
    {

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty", nameof(name));
        if (string.IsNullOrWhiteSpace(lLicenseNumber))
            throw new ArgumentException("Licence number cannot be empty", nameof(lLicenseNumber));
        if (lLicenseNumber.Length!= 8)
            throw new ArgumentException("Licence number must be 8 digits long", nameof(lLicenseNumber));
        if (!lLicenseNumber.All(char.IsDigit))
            throw new ArgumentException("Licence number must only contain numbers", nameof(lLicenseNumber));
        
        Name = name;
        LicenseNumber = lLicenseNumber;
    }
    
    public void AddAvailableDay(DayOfWeek day)
    {
        if (!FreeDays.Contains(day))
            FreeDays.Add(day);
    }
        
    public bool IsAvailableOn(DayOfWeek day) => FreeDays.Contains(day);
}

s