using System.Data;
using APBD10_1_17c.dyp_s;
using Microsoft.AspNetCore.Mvc;

namespace APBD10_17c.controllers;

[ApiController]
[Microsoft.AspNetCore.Components.Route("/controller")]
public class PatientController: ControllerBase
{
    private readonly IDbConnection _dbService;
    public PatientController(IDbConnection dbService)
    {
        _dbService = dbService;
    }

    [HttpPost]
    public async Task<OkObjectResult> GetPatienInfo(int id)
    {
        var patienInfo = await _dbService.GetPatientDetails(id);

        if (patienInfo == null)
            throw new Exception("Patient with given ID - {id} doesn't exist");
        
        return Ok(patienInfo);
    }
}