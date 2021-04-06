using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace NRDCL_API.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "this", "is", "hard", "coded" };
        }

    }
}