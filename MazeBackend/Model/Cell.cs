using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeBackend.Model
{
    public class Cell
    {
        public int[] Position { get; set; }
        ///<value>As maze will be represented as an bidimensional array of cells, 
        ///this will represent if this cell is a path or wall.</value>
        public bool IsPath { get; set; }

        ///<value>Minimum lenght to reach this cell from start cell</value>
        public int MinimumPathWeight { get; set; }

        public Cell(bool isPath, int[] position)
        {
            IsPath = isPath;
            Position = position;
            MinimumPathWeight = -1;
        }
    }
}
