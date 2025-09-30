namespace WebApplication1.Domain.Entities;

public class Patient
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; private set; }
    public DateTime DateOfBirth { get; private set; }

    public Patient(string name, DateTime dateOfBirth)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException(nameof(name));
        Name = name;
        DateOfBirth = dateOfBirth;
    }

    public int GetAge()
    {
        var age = DateTime.Today.Year - DateOfBirth.Year;
        DateTime DateOfBirthNorm = new DateTime(2024, DateOfBirth.Month, DateOfBirth.Day);
        DateTime DateTodayNorm = new DateTime(2024, DateTime.Today.Month, DateTime.Today.Day);
        if (DateOfBirthNorm > DateTodayNorm) age--;
        return age;
    }

    public bool IsMinor()
    {
        return GetAge() < 18;
    }
}