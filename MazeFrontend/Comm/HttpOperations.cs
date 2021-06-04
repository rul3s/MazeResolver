using MazeBackend.Model;
using MazeFrontend.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MazeFrontend.Comm
{
    class HttpOperations
    {
        static readonly HttpClient client = new HttpClient();
        public HttpOperations()
        {

        }

        public async static Task<Maze> PostMazeToServiceAndResolve(Maze maze, string url)
        {
            Maze resolvedMaze;

            string result = "";
            WebRequest webRequest = WebRequest.Create(url);
            webRequest.Method = "post";
            webRequest.ContentType = "application/json";

            using (StreamWriter requestWritter = new StreamWriter(webRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(maze);

                requestWritter.Write(json);
                requestWritter.Flush();
                requestWritter.Close();
            }

            WebResponse webResponse = webRequest.GetResponse();
            using (StreamReader responseReader = new StreamReader(webResponse.GetResponseStream()))
            {
                resolvedMaze = JsonConvert.DeserializeObject<Maze>(responseReader.ReadToEnd().Trim());
            }

            return resolvedMaze;
        }
    }
}
