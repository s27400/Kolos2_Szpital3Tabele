using _3TabeleSzpital.Entities;
using _3TabeleSzpital.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _3TabeleSzpital.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HospitalController : ControllerBase
{
    private readonly IHospitalRepo _hospitalRepo;

    public HospitalController(IHospitalRepo hospitalRepo)
    {
        _hospitalRepo = hospitalRepo;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id, CancellationToken token)
    {
        return Ok(await _hospitalRepo.GetInfoPatient(id, token));
    }
}