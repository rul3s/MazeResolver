using MazeFrontend.Comm;
using MazeFrontend.Domain;
using MazeFrontend.Helpers;
using MazeFrontend.Model;
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
        MazeGUIHelper mazeGUIGenerator;

        public MainForm()
        {
            InitializeComponent();
            LoadMazeGUI();
        }

        public void LoadMazeGUI()
        {
            //maze = MazeHelper.GetSmallTestMaze();
            maze = MazeHelper.GetTestMaze();
            mazeGUIGenerator = new MazeGUIHelper(maze, this, 40, 2);
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
