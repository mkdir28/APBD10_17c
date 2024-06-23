
namespace APBD10_17c.data;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionController: ControllerBase
{
        
    private readonly DbConnection _dbService;
    public PrescriptionController(IDbConnection dbService)
    {
        _dbService = dbService;
    }
    
    public async Task<IActionResult> GetPatientinformation(int id)
    {
        var orders = await _dbService.GetPatientinformation(id);

}