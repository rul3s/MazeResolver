using MazeFrontend.Model;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MazeFrontend.Comm
{
    class HttpOperations
    {
        static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Send Maze object throught HTTP post to the web service.
        /// </summary>
        /// <param name="maze">The maze object to send to the WS</param>
        /// <param name="url">URL where the WS is</param>
        /// <returns></returns>
        public async static Task<Maze> PostMazeToServiceAndResolve(Maze maze, string url)
        {
            Maze resolvedMaze;

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
