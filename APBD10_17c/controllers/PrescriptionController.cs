
namespace APBD10_17c.data;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionController
{
        
    private readonly DbConnection _dbService;
    public PrescriptionController(IDbConnection dbService)
    {
        _dbService = dbService;
    }
}