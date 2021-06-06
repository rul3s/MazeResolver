using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeFrontend.Model
{
    public class Cell
    {
        /// <summary>
        /// Position X,Y where the cell is on the maze. 0,0 is represented on the lower-left side.
        /// </summary>
        public int[] Position { get; set; }

        /// <summary>
        /// To know if this cell is a valid path to go or a wall
        /// </summary>
        public bool IsPath { get; set; }

        /// <summary>
        /// Minimum number of steps to arribe to that cell
        /// </summary>
        public int MinPathSteps { get; set; }

        public Cell(bool isPath, int[] position)
        {
            IsPath = isPath;
            Position = position;
            MinPathSteps = -1;
        }
    }
}
