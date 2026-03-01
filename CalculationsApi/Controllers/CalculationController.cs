using Calculations.Services;
using Microsoft.AspNetCore.Mvc;


namespace Calculations.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculationController(ICalculationService calculationService) : ControllerBase
    {
        [HttpGet("operations")]
        public IActionResult GetOperations()
        {
            var operations = calculationService.GetOperations();
            return Ok(operations);
        }

        [HttpPost]
        public IActionResult Calculate([FromBody] CalculationRequest request)
        {
            var result = calculationService.Calculate(request.A, request.B, request.Operation);
            return Ok(result);
        }

        [HttpPost("with-history")]
        public async Task<IActionResult> CalculateWithHistory([FromBody] CalculationRequest request)
        {
            var result = await calculationService.CalculateWithHistoryAsync(request.A, request.B, request.Operation);
            return Ok(result);
        }
    }
}
