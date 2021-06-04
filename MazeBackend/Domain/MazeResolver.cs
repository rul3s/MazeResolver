using MazeBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MazeBackend.Domain
{
    public class MazeResolver
    {
        Maze initialMaze;
        public MazeResolver(Maze maze)
        {
            initialMaze = maze;
        }

        public Maze ResolveMaze()
        {
            throw new NotImplementedException();
        }
    }
}
