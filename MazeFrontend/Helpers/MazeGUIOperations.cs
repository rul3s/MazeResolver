using MazeBackend.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeFrontend.Helpers
{
    public class MazeGUIOperations
    {
        private Button[,] ButtonMap;
        private Maze maze;
        private System.Windows.Forms.Form window;
        private int CellSize;
        private int CellDist;

        public MazeGUIOperations(Maze maze, System.Windows.Forms.Form window, int cellSizeInPx, int cellDistanceInPx)
        {
            this.maze = maze;
            this.window = window;
            this.CellSize = cellSizeInPx;
            this.CellDist = cellDistanceInPx;
            ButtonMap = new Button[maze.SizeX,maze.SizeY];
        }

        public void FillGUIWithMaze()
        {
            int x = 0, y = 0;
            Button btn;

            for(int row=0; row < maze.SizeY; row++)
            {
                for (int col=0; col < maze.SizeX; col++)
                {
                    btn = new Button();
                    btn.Location = new Point(x, y);
                    btn.Size = new Size(CellSize, CellSize);
                    btn.Enabled = false;
                    ButtonMap[col, row] = btn;
                    window.Controls.Add(btn);
                    x += CellSize + CellDist;
                }
                x = 0;
                y += CellSize + CellDist;
            }
        }
    }
}
