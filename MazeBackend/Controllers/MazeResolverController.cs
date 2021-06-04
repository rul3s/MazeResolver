using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MazeBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MazeResolverController : ControllerBase
    {

        private readonly ILogger<MazeResolverController> _logger;

        public MazeResolverController(ILogger<MazeResolverController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "GET OK\n";
        }
    }
}
