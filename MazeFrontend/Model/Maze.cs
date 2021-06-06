using System;
using System.Collections.Generic;

namespace MazeFrontend.Model
{
    public class Maze
    {
        /// <summary>
        /// Width in cells
        /// </summary>
        public int SizeX { get; set; }

        /// <summary>
        /// Height in cells
        /// </summary>
        public int SizeY { get; set; }

        /// <summary>
        /// Where the startpoint is, lowerleft is 0,0.
        /// </summary>
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

        /// <summary>
        /// From a given cell it will return all the posible LINEAR movements (not diagonal) in a List of cells.
        /// </summary>
        /// <param name="actualCell">Actual cell to search from</param>
        /// <returns></returns>
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

        /// <summary>
        /// Try to do a move specified on X,Y from the given cell. If it's possible it will return
        /// the next cell, if not, will throw a MoveNotAllowedException
        /// </summary>
        /// <param name="actualCell">The actual cell to move from</param>
        /// <param name="xMovement">X diference to move from actual cell</param>
        /// <param name="yMovement">Y diference to move from actual cell</param>
        /// <returns>The next cell if move is posible, MoveNotAllowedException if there is no cell to move to.</returns>
        private Cell DoMove(Cell actualCell, int xMovement, int yMovement)
        {
            int[] nextPosition = new int[2];

            nextPosition[0] = actualCell.Position[0] + xMovement;
            nextPosition[1] = actualCell.Position[1] + yMovement;

            if (Map[nextPosition[0], nextPosition[1]].IsPath)
                return Map[nextPosition[0], nextPosition[1]];
            else
                throw new MoveNotAllowedException();
        }

        public class MoveNotAllowedException : Exception
        {
            public MoveNotAllowedException()
            {
            }
        }
    }
}
