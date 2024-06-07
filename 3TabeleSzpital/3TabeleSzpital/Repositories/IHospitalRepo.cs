using _3TabeleSzpital.DTO;

namespace _3TabeleSzpital.Repositories;

public interface IHospitalRepo
{
    public Task<GetPatientInfoDTO> GetInfoPatient(int id, CancellationToken token);
}