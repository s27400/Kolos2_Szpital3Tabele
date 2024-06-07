namespace _3TabeleSzpital.Entities;

public class Prescription
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public int IdPatient { get; set; }
    public int IdDoctor { get; set; }
    public virtual Doctor NavigationDoctor { get; set; }
    public virtual Patient NavigationPatient { get; set; }
}