using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace TouristAppBackend.Controllers
{
    [Route("api/coordinate")]
    [ApiController]
    [EnableCors("My CORS policy")]
    public class CoordinateController : ControllerBase
    {
    }
}
