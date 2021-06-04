using MazeBackend.Model;
using MazeFrontend.Model;
using System;

namespace MazeFrontend.Domain
{
    public class MazeOperations
    {
        private Maze maze;

        public MazeOperations(Maze maze)
        {
            this.maze = maze;
        }

        public void FillMap()
        {
            throw new NotImplementedException();
        }

        public void FillMazeMapWithTestData()
        {
            maze.Map[0, 0] = new Cell(true);
            maze.Map[1, 0] = new Cell(true);
            maze.Map[2, 0] = new Cell(true);
            maze.Map[3, 0] = new Cell(true);

            maze.Map[0, 1] = new Cell(true);
            maze.Map[1, 1] = new Cell(false);
            maze.Map[2, 1] = new Cell(true);
            maze.Map[3, 1] = new Cell(true);

            maze.Map[0, 2] = new Cell(true);
            maze.Map[1, 2] = new Cell(false);
            maze.Map[2, 2] = new Cell(false);
            maze.Map[3, 2] = new Cell(true);

            maze.Map[0, 3] = new Cell(true);
            maze.Map[1, 3] = new Cell(true);
            maze.Map[2, 3] = new Cell(true);
            maze.Map[3, 3] = new Cell(true);
        }


    }
}
