using MazeFrontend.Model;
using System.Drawing;
using System.Windows.Forms;

namespace MazeFrontend.Helpers
{
    public class MazeGUIHelper
    {
        /// <summary>
        /// Cell size in pixels, as square.
        /// </summary>
        private int CellSize;

        /// <summary>
        /// Distance between cells, in pixels.
        /// </summary>
        private int CellDist;

        /// <summary>
        /// Bidimensional array containing all the GUI buttons
        /// that represents the maze
        /// </summary>
        private Button[,] ButtonMap;

        /// <summary>
        /// Maze object to work with
        /// </summary>
        private Maze maze;

        /// <summary>
        /// Windows forms where the maze will be showed
        /// </summary>
        private System.Windows.Forms.Form form;
        

        public MazeGUIHelper(Maze maze, System.Windows.Forms.Form window, int cellSizeInPx, int cellDistanceInPx)
        {
            this.maze = maze;
            this.form = window;
            this.CellSize = cellSizeInPx;
            this.CellDist = cellDistanceInPx;
            ButtonMap = new Button[maze.SizeX,maze.SizeY];
        }

        /// <summary>
        /// Will the Windows Form with the maze and sizes given in constructor.
        /// </summary>
        public void FillGUIWithMaze()
        {
            int x, y, startX, startY, mazeSize, border;
            Button btn;

            mazeSize = (CellSize * maze.SizeY) + ((maze.SizeY - 1) * CellDist);
            border = CellSize / 2;

            startX = form.Location.X + CellDist;
            startY = form.Location.Y + mazeSize;

            y = startY;
            x = startX;

            for (int row=0; row < maze.SizeY; row++)
            {
                x = startX;
                for (int col=0; col < maze.SizeX; col++)
                {
                    btn = new Button();
                    btn.Location = new Point(x, y);
                    btn.Size = new Size(CellSize, CellSize);
                    btn.Enabled = false;
                    ButtonMap[col, row] = btn;
                    if (!maze.Map[col, row].IsPath)
                        btn.BackColor = System.Drawing.Color.Black;
                    form.Controls.Add(btn);
                    x += CellSize + CellDist;
                }
                y -= CellSize + CellDist;
            }
        }

        /// <summary>
        /// Update the MazeGUI with the resolved maze with weights
        /// </summary>
        /// <param name="resolvedMaze"></param>
        public void UpdateGUIWithMazeData(Maze resolvedMaze)
        {
            for (int row = 0; row < resolvedMaze.SizeY; row++)
            {
                for (int col = 0; col < resolvedMaze.SizeX; col++)
                {
                    ButtonMap[col, row].Text = resolvedMaze.Map[col, row].MinPathSteps.ToString();
                }
            }
        }
    }
}
