using LayeredArchitecture.Services;
using Microsoft.AspNetCore.Mvc;

namespace LayeredArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IDataProcessorService _dataProcessorService;
        public DataController(IDataProcessorService dataProcessorService)
        {
            _dataProcessorService = dataProcessorService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dataProcessorService.ProcessData());
        }
    }
}