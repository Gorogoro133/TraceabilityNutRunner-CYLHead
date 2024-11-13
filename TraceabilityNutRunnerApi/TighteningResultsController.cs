using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TraceabilityNutRunnerApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class TighteningResultController : ControllerBase
    {
        [HttpPost]
        public IActionResult PostTighteningResult([FromBody] TighteningResult tighteningResult)
        {
            if (tighteningResult == null)
            {
                return BadRequest("Invalid data.");
            }

            // Process the data here, like saving it to a database.
            // For now, we will just return the received data.
            return Ok(new { message = "Data received successfully", data = tighteningResult });
        }
    }
}
