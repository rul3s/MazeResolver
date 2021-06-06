using MazeBackend.Model;
using MazeFrontend.Comm;
using MazeFrontend.Domain;
using MazeFrontend.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeFrontend
{
    public partial class MainForm : Form
    {
        Maze maze, resolvedMaze;
        MazeOperations mazeOperations;
        MazeGUIOperations mazeGUIGenerator;

        public MainForm()
        {
            InitializeComponent();

            LoadMazeGUI();
        }

        public void LoadMazeGUI()
        {
            maze = new Maze(8,8,new int[2] { 0, 0 });

            mazeOperations = new MazeOperations(maze);
            //mazeOperations.FillMazeMapWithTestData();
            mazeOperations.FillMazeMapWithTestData2();

            mazeGUIGenerator = new MazeGUIOperations(maze, this, 40, 2);
            mazeGUIGenerator.FillGUIWithMaze();

        }

        private void btnResolveMaze_Click(object sender, EventArgs e)
        {
            SendMazeForResolvingOnServer();
        }

        private void resolveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendMazeForResolvingOnServer();
        }

        private async void SendMazeForResolvingOnServer()
        {
            Task<Maze> mazeTask = HttpOperations.PostMazeToServiceAndResolve(maze, "http://localhost:58898/mazeresolver");
            resolvedMaze = await mazeTask;

            mazeGUIGenerator.UpdateGUIWithMazeData(resolvedMaze);
        }
    }
}
