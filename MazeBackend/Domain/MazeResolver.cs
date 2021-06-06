using MazeBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MazeBackend.Domain
{
    public class MazeResolver
    {
        Maze maze;
        List<Thread> activeThreads;

        public MazeResolver(Maze maze)
        {
            this.maze = maze;
            activeThreads = new List<Thread>();
        }

        public Maze ResolveMaze()
        {
            CreateNewThread(maze.Map[maze.StartPoint[0], maze.StartPoint[1]], 0);

            while (activeThreads.Count > 0)
            {
                Console.WriteLine($"There are actually {activeThreads.Count} threads in execution. Checking them:");
                for(int x=0; x<activeThreads.Count; x++)
                {
                    if (!activeThreads[x].IsAlive)
                    {
                        Console.WriteLine("Thread has finished, removing");
                        activeThreads.RemoveAt(x);
                    }  
                    else
                        Console.WriteLine("Thread is alive");
                }
                System.Threading.Thread.Sleep(100);
            }

            return maze;
        }

        private void CreateNewThread(Cell cell, int actualPathWeight)
        {
            ThreadParams threadParams = new ThreadParams();
            threadParams.cell = cell;
            threadParams.actualPathWeight = actualPathWeight;

            Thread thread = new Thread(Work);
            thread.Start(threadParams);
            activeThreads.Add(thread);
        }

        private void Work(Object obj)
        {
            bool continueSearch;
            Cell actualCell = ((ThreadParams)obj).cell;
            int actualWeight = ((ThreadParams)obj).actualPathWeight;
            List<Cell> nextMoves;

            do
            {
                continueSearch = true;
                actualCell.MinimumPathWeight = actualWeight;
                actualWeight++;

                nextMoves = maze.GetAllPosibleMovements(actualCell);
                nextMoves = GetCellsWithBetterPathing(nextMoves, actualWeight);

                if (nextMoves.Count == 0)
                    continueSearch = false;
                else if (nextMoves.Count == 1)
                {
                    actualCell = nextMoves[0];
                }
                else if (nextMoves.Count > 1)
                {
                    actualCell = nextMoves[0];
                    nextMoves.RemoveAt(0);

                    foreach (Cell cell in nextMoves)
                        CreateNewThread(cell, actualWeight);
                }

            } while (continueSearch);          

        }

        private List<Cell> GetCellsWithBetterPathing(List<Cell> posibleMoves, int actualPathWeight)
        {
            List<Cell> betterWeightMoves = new List<Cell>();

            foreach(Cell cell in posibleMoves)
            {
                if (cell.MinimumPathWeight == -1 || cell.MinimumPathWeight>actualPathWeight)
                    betterWeightMoves.Add(cell);
            }

            return betterWeightMoves;
        }

        private class ThreadParams
        {
            public Cell cell { get; set; }
            public int actualPathWeight { get; set; }
        }
    }
}
