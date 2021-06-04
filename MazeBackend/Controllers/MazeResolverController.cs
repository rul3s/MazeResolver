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
            Maze maze, resolvedMaze;

            Console.WriteLine("Received something via POST\n;");
            string body;

            using (StreamReader str = new StreamReader(Request.Body))
            {
                body = str.ReadToEnd();
            }

            if(Request.ContentType != "application/json")
            {
                Console.WriteLine("Received not a JSON content.");
                return "Please, provide JSON content.";
            }

            Console.WriteLine("Request content is advertised as JSON, now triing to deserialize it...;");
            try
            {
                maze = JsonConvert.DeserializeObject<Maze>(body);
                Console.WriteLine("Deserialized correctly into Maze Object");
            }
            catch(Exception e)
            {
                Console.WriteLine("Couldn't deserialize it correctly into Maze Object");
                return "Error deserializing json into Maze Object\n";
            }

            MazeResolver mazeResolver = new MazeResolver(maze);
            resolvedMaze = mazeResolver.ResolveMaze();

            return JsonConvert.SerializeObject(resolvedMaze);
        }
    }
}
