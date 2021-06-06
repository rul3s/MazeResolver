using MazeBackend.Domain;
using MazeBackend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
            return "Send me a Maze object json-serialized and I'll resolve it for you!\n";
        }

        [HttpPost]
        public string Post()
        {
            Maze receivedMaze, resolvedMaze;
            string body;

            Console.WriteLine("Received something via POST\n;");
            using (StreamReader str = new StreamReader(Request.Body))
            {
                body = str.ReadToEnd();
            }

            if(Request.ContentType != "application/json")
            {
                Console.WriteLine("Received content is not JSON formatted.");
                return "Please, provide JSON formatted content.";
            }

            Console.WriteLine("Request content JSON formatted, now triing to deserialize it...;");
            try
            {
                receivedMaze = JsonConvert.DeserializeObject<Maze>(body);
                Console.WriteLine("Deserialized correctly into Maze Object");
            }
            catch(Exception)
            {
                Console.WriteLine("Couldn't deserialize it correctly into Maze Object");
                return "Error deserializing json into Maze Object\n";
            }

            MazeResolver mazeResolver = new MazeResolver();
            resolvedMaze = mazeResolver.ResolveMaze(receivedMaze);

            return JsonConvert.SerializeObject(resolvedMaze);
        }
    }
}
