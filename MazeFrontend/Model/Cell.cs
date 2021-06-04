using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeFrontend.Model
{
    public class Cell
    {
        ///<value>As maze will be represented as an bidimensional array of cells, 
        ///this will represent if this cell is a path or wall.</value>
        public bool IsPath { get; set; }

        ///<value>Minimum lenght to reach this cell from start cell</value>
        public int MinimumLengthFromStartCell { get; set; }

        public Cell(bool isPath)
        {
            IsPath = isPath;
            MinimumLengthFromStartCell = -1;
        }
    }
}
