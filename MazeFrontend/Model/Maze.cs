using MazeFrontend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MazeBackend.Model
{
    public class Maze
    {
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public int[] StartPoint { get; set; }

        ///<value>Map is bidimensional array of cells. Position 0,0 will be lower left side of a rectangular maze</value>
        public Cell[,] Map { get; set; }

        public Maze(int sizeX, int sizeY, int[] startPoint)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            StartPoint = startPoint;
            Map = new Cell[sizeX,sizeY];
        }
    }
}
