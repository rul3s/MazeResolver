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
            maze.Map[0, 0] = new Cell(true, new int[] { 0, 0 });
            maze.Map[1, 0] = new Cell(true, new int[] { 1, 0 });
            maze.Map[2, 0] = new Cell(true, new int[] { 2, 0 });
            maze.Map[3, 0] = new Cell(true, new int[] { 3, 0 });

            maze.Map[0, 1] = new Cell(true, new int[] { 0, 1 });
            maze.Map[1, 1] = new Cell(false, new int[] { 1, 1 });
            maze.Map[2, 1] = new Cell(true, new int[] { 2, 1 });
            maze.Map[3, 1] = new Cell(true, new int[] { 3, 1 });

            maze.Map[0, 2] = new Cell(true, new int[] { 0, 2 });
            maze.Map[1, 2] = new Cell(false, new int[] { 1, 2 });
            maze.Map[2, 2] = new Cell(false, new int[] { 2, 2 });
            maze.Map[3, 2] = new Cell(true, new int[] { 3, 2 });

            maze.Map[0, 3] = new Cell(true, new int[] { 0, 3 });
            maze.Map[1, 3] = new Cell(true, new int[] { 1, 3 });
            maze.Map[2, 3] = new Cell(true, new int[] { 2, 3 });
            maze.Map[3, 3] = new Cell(true, new int[] { 3, 3 });
        }

        public void FillMazeMapWithTestData2()
        {
            maze.Map[0, 0] = new Cell(true, new int[] { 0, 0 });
            maze.Map[1, 0] = new Cell(true, new int[] { 1, 0 });
            maze.Map[2, 0] = new Cell(false, new int[] { 2, 0 });
            maze.Map[3, 0] = new Cell(true, new int[] { 3, 0 });
            maze.Map[4, 0] = new Cell(true, new int[] { 4, 0 });
            maze.Map[5, 0] = new Cell(true, new int[] { 5, 0 });
            maze.Map[6, 0] = new Cell(false, new int[] { 6, 0 });
            maze.Map[7, 0] = new Cell(true, new int[] { 7, 0 });

            maze.Map[0, 1] = new Cell(false, new int[] { 0, 1 });
            maze.Map[1, 1] = new Cell(true, new int[] { 1, 1 });
            maze.Map[2, 1] = new Cell(false, new int[] { 2, 1 });
            maze.Map[3, 1] = new Cell(true, new int[] { 3, 1 });
            maze.Map[4, 1] = new Cell(false, new int[] { 4, 1 });
            maze.Map[5, 1] = new Cell(true, new int[] { 5, 1 });
            maze.Map[6, 1] = new Cell(true, new int[] { 6, 1 });
            maze.Map[7, 1] = new Cell(true, new int[] { 7, 1 });

            maze.Map[0, 2] = new Cell(true, new int[] { 0, 2 });
            maze.Map[1, 2] = new Cell(true, new int[] { 1, 2 });
            maze.Map[2, 2] = new Cell(true, new int[] { 2, 2 });
            maze.Map[3, 2] = new Cell(true, new int[] { 3, 2 });
            maze.Map[4, 2] = new Cell(false, new int[] { 4, 2 });
            maze.Map[5, 2] = new Cell(false, new int[] { 5, 2 });
            maze.Map[6, 2] = new Cell(false, new int[] { 6, 2 });
            maze.Map[7, 2] = new Cell(true, new int[] { 7, 2 });

            maze.Map[0, 3] = new Cell(true, new int[] { 0, 3 });
            maze.Map[1, 3] = new Cell(false, new int[] { 1, 3 });
            maze.Map[2, 3] = new Cell(false, new int[] { 2, 3 });
            maze.Map[3, 3] = new Cell(true, new int[] { 3, 3 });
            maze.Map[4, 3] = new Cell(false, new int[] { 4, 3 });
            maze.Map[5, 3] = new Cell(false, new int[] { 5, 3 });
            maze.Map[6, 3] = new Cell(true, new int[] { 6, 3 });
            maze.Map[7, 3] = new Cell(true, new int[] { 7, 3 });

            maze.Map[0, 4] = new Cell(true, new int[] { 0, 4 });
            maze.Map[1, 4] = new Cell(true, new int[] { 1, 4 });
            maze.Map[2, 4] = new Cell(true, new int[] { 2, 4 });
            maze.Map[3, 4] = new Cell(true, new int[] { 3, 4 });
            maze.Map[4, 4] = new Cell(true, new int[] { 4, 4 });
            maze.Map[5, 4] = new Cell(true, new int[] { 5, 4 });
            maze.Map[6, 4] = new Cell(true, new int[] { 6, 4 });
            maze.Map[7, 4] = new Cell(false, new int[] { 7, 4 });

            maze.Map[0, 5] = new Cell(false, new int[] { 0, 5 });
            maze.Map[1, 5] = new Cell(false, new int[] { 1, 5 });
            maze.Map[2, 5] = new Cell(true, new int[] { 2, 5 });
            maze.Map[3, 5] = new Cell(false, new int[] { 3, 5 });
            maze.Map[4, 5] = new Cell(false, new int[] { 4, 5 });
            maze.Map[5, 5] = new Cell(false, new int[] { 5, 5 });
            maze.Map[6, 5] = new Cell(true, new int[] { 6, 5 });
            maze.Map[7, 5] = new Cell(true, new int[] { 7, 5 });

            maze.Map[0, 6] = new Cell(true, new int[] { 0, 6 });
            maze.Map[1, 6] = new Cell(false, new int[] { 1, 6 });
            maze.Map[2, 6] = new Cell(true, new int[] { 2, 6 });
            maze.Map[3, 6] = new Cell(false, new int[] { 3, 6 });
            maze.Map[4, 6] = new Cell(true, new int[] { 4, 6 });
            maze.Map[5, 6] = new Cell(false, new int[] { 5, 6 });
            maze.Map[6, 6] = new Cell(false, new int[] { 6, 6 });
            maze.Map[7, 6] = new Cell(true, new int[] { 7, 6 });

            maze.Map[0, 7] = new Cell(true, new int[] { 0, 7 });
            maze.Map[1, 7] = new Cell(true, new int[] { 1, 7 });
            maze.Map[2, 7] = new Cell(true, new int[] { 2, 7 });
            maze.Map[3, 7] = new Cell(true, new int[] { 3, 7 });
            maze.Map[4, 7] = new Cell(true, new int[] { 4, 7 });
            maze.Map[5, 7] = new Cell(true, new int[] { 5, 7 });
            maze.Map[6, 7] = new Cell(true, new int[] { 6, 7 });
            maze.Map[7, 7] = new Cell(true, new int[] { 7, 7 });
        }


    }
}
