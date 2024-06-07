namespace _3TabeleSzpital.DTO;

public class GetPatientInfoDTO
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public IEnumerable<PrescriptionDTO> Prescriptions { get; set; }
}