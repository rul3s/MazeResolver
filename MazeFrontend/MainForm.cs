using MazeBackend.Model;
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
        Maze maze;
        MazeOperations mazeOperations;
        MazeGUIOperations mazeGUIGenerator;

        public MainForm()
        {
            InitializeComponent();

            LoadMazeGUI();
        }

        public void LoadMazeGUI()
        {
            maze = new Maze(4,4,new int[2] { 0, 0 });

            mazeOperations = new MazeOperations(maze);
            mazeOperations.FillMazeMapWithTestData();

            mazeGUIGenerator = new MazeGUIOperations(maze, this, 20, 0);
            mazeGUIGenerator.FillGUIWithMaze();

        }
    }
}
