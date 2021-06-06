using MazeFrontend.Helpers;
using MazeFrontend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MazeFrontend.Helpers.CustomExceptions;

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

        public List<Cell> GetAllPosibleMovements(Cell actualCell)
        {
            List<Cell> posibleMovements = new List<Cell>();

            //move up y+1
            try
            {
                posibleMovements.Add(DoMove(actualCell, 0, 1));
            }
            catch (Exception) { }

            //move right x+1
            try
            {
                posibleMovements.Add(DoMove(actualCell, 1, 0));
            }
            catch (Exception) { }

            //move down y-1
            try
            {
                posibleMovements.Add(DoMove(actualCell, 0, -1));
            }
            catch (Exception) { }

            //move left x-1
            try
            {
                posibleMovements.Add(DoMove(actualCell, -1, 0));
            }
            catch (Exception) { }


            return posibleMovements;
        }

        private Cell DoMove(Cell actualCell, int xMovement, int yMovement)
        {
            int[] actualPosition, nextPosition;

            actualPosition = actualCell.Position;
            nextPosition = actualPosition;

            nextPosition[0] = nextPosition[0] + xMovement;
            nextPosition[1] = nextPosition[1] + yMovement;

            if (Map[nextPosition[0], nextPosition[1]].IsPath)
                return Map[nextPosition[0], nextPosition[1]];
            else
                throw new MoveNotAllowedException();
        }
    }
}
