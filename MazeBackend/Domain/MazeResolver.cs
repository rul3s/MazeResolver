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
        /// <summary>
        /// The maze to resolve
        /// </summary>
        private Maze maze;

        /// <summary>
        /// A list of active threads being used on the search
        /// </summary>
        private List<Thread> activeThreads;

        /// <summary>
        /// Resolve the given maze
        /// </summary>
        /// <param name="maze">The maze to resolve</param>
        /// <returns>A resolved maze</returns>
        public Maze ResolveMaze(Maze maze)
        {
            this.maze = maze;
            activeThreads = new List<Thread>();

            //We start creating a single search thread
            CreateNewThread(maze.Map[maze.StartPoint[0], maze.StartPoint[1]], 0);

            //After launching the initial search thread, we will log on console the actual threads 
            //state every 100ms until all threads have finished
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

            //If all threads are finished, we can return the resolved maze
            return maze;
        }

        /// <summary>
        /// Create a new searching thread
        /// </summary>
        /// <param name="cell">Starting cell position</param>
        /// <param name="actualPathSteps">Acumulated path steps</param>
        private void CreateNewThread(Cell cell, int actualPathSteps)
        {
            //Create thread params with actual params.
            ThreadParams threadParams = new ThreadParams();
            threadParams.cell = cell;
            threadParams.actualPathWeight = actualPathSteps;

            //Start the new thread
            Thread thread = new Thread(Work);
            thread.Start(threadParams);
            //Add the new thread to the threadList to keep up on it's status.
            activeThreads.Add(thread);
        }

        /// <summary>
        /// Do the search job. If only one more path it continues, if more thatn 1 available path, it creates another
        /// thread to search on it. If no more paths finishes the thread.
        /// </summary>
        /// <param name="obj">ThreadParams, with actualCell and actualPathWeight</param>
        private void Work(Object obj)
        {
            bool continueSearch;
            Cell actualCell = ((ThreadParams)obj).cell;
            int actualWeight = ((ThreadParams)obj).actualPathWeight;
            List<Cell> nextMoves;

            
            do
            {
                continueSearch = true;
                //Assing to the actual Cell the actual Weight and then we add+1 to the actual weight as next moves will have this weight
                actualCell.MinPathSteps = actualWeight;
                actualWeight++;

                //Get a list of all posible movements from the actual cell.
                nextMoves = maze.GetAllPosibleMovements(actualCell);
                //From this list, discard movements that doesnt give a better path weight
                nextMoves = GetCellsWithBetterPathing(nextMoves, actualWeight);

                ///Now we have 3 cases:
                ///Case1: No more posible moves -> Stop searching and thread finishes
                ///Case2: Only one move -> This thread moves to the new cell and continues the search
                ///Case3: More than 1 move -> Create X new threads to search on the new paths.
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

        /// <summary>
        /// From a list of posible cells to move, get a new list with only the ones we can move with a 
        /// better path-performance.
        /// </summary>
        /// <param name="posibleMoves">Cells available to move to</param>
        /// <param name="actualPathWeight">Actual pathWeight to compare with new cells to move</param>
        /// <returns></returns>
        private List<Cell> GetCellsWithBetterPathing(List<Cell> posibleMoves, int actualPathWeight)
        {
            List<Cell> betterWeightMoves = new List<Cell>();

            foreach(Cell cell in posibleMoves)
            {
                if (cell.MinPathSteps == -1 || cell.MinPathSteps>actualPathWeight)
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
