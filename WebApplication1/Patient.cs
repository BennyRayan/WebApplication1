namespace WebApplication1;

public class Patient
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; private set; }
    public DateTime DateOfBirth { get; private set; }

    public Patient(string name, DateTime dateOfBirth)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name));
        Name = name;
        DateOfBirth = dateOfBirth;
    }

    public int Age()
    {
        var age = DateTime.Today.Year - DateOfBirth.Year;
        if (DateOfBirth.Date > DateTime.Today.AddYears(-age)) age--;
        return age;
    }

    public bool IsMinor()
    {
        return Age() < 18;
    }
}