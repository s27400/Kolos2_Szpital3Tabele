using _3TabeleSzpital.DTO;
using _3TabeleSzpital.Entities;
using Microsoft.EntityFrameworkCore;

namespace _3TabeleSzpital.Repositories;

public class HospitalRepo : IHospitalRepo
{
    private readonly HospitalDbContext _context;

    public HospitalRepo(HospitalDbContext context)
    {
        _context = context;
    }

    public async Task<GetPatientInfoDTO> GetInfoPatient(int id, CancellationToken token)
    {
        var all = _context.Patients
            .Where(x => x.IdPatient == id)
            .Include(x => x.Prescriptions)
            .ThenInclude(x => x.NavigationDoctor);

        var temp = await all
            .Select(x => new GetPatientInfoDTO()
            {
                IdPatient = x.IdPatient,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Prescriptions = x.Prescriptions.Select(p => new PrescriptionDTO()
                {
                    IdPrescription = p.IdPrescription,
                    Date = p.Date,
                    DueDate = p.DueDate,
                    Doctor = new DoctorDTO()
                    {
                        IdDoctor = p.NavigationDoctor.IdDoctor,
                        FirstName = p.NavigationDoctor.FirstName,
                        LastName = p.NavigationDoctor.LastName,
                    }
                }).ToList()
            }).ToListAsync(token);

        return temp[0];

    }

}