using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace RecinosGameOfLife
{

    /*
    
    Important Information: The mouse can be used to toggle cells on and off or create cells once you erase the universe by clicking clear. 
    Or you can just reset the grid  at your whim, and it will create a random universe. Reset the game to implement changes to the cell size.
    
    */




    public partial class Game : Form
    {
        Universegrid UniverseGrid;
        Boolean CellularAdvancement;

        public Game()
        {
            InitializeComponent();
        }

        private void Start_Game(object sender, EventArgs e)
        {
            InitializeUniverse(true);

        }

        private void InitializeUniverse(bool RandomCells)
        {
            Cell newCell;
            Random rando = new Random();

            // Initializing the number of rows and columns in Universe.
            int Rows = (int)(Universe.Height / CellSize.Value);
            int Columns = (int)(Universe.Width / CellSize.Value);

            // Creating a Universe Object
            UniverseGrid = new Universegrid(Rows, Columns);

            // Clearing The List of Cells
            Universegrid.UniverseCells.Clear();

            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Columns; x++)
                {
                    newCell = new Cell(x, y, (int)CellSize.Value);
                    if (RandomCells)
                        newCell.IsAlive = (rando.Next(100) < 15) ? true : false;
                    else
                        newCell.IsAlive = false;
                }
            }

            Universegrid.UniverseCells = Universegrid.UniverseCells.OrderBy(c => c.XPos).OrderBy(c => c.YPos).ToList();

            UpdateUniverse(UniverseGrid);

        }

        //Remaking the list of cells, randomly activating cells
        private void btnRandomReset_Click(object sender, EventArgs e)
        {
            InitializeUniverse(true);
        }

        private void GetNextGen()
        {


            // Game Rule Implementation starts here: 
            foreach (Cell cell in Universegrid.UniverseCells)
            {
                int Count = UniverseGrid.NeighbourCount(cell);

                if (cell.IsAlive)
                {
                    if ((Count < 2) || (Count > 3))
                    {
                        cell.NextGenStatus = false;

                    }

                    else
                    {
                        cell.NextGenStatus = true;

                    }

                }
                else
                {
                    if (Count == 3)
                        cell.NextGenStatus = true;
                }

            }

            // Update Cell state 
            foreach (Cell cell in Universegrid.UniverseCells)
            {
                cell.IsAlive = cell.NextGenStatus;
            }

            UpdateUniverse(UniverseGrid);


        }

        private void UpdateUniverse(Universegrid GridDisplay)
        {
            Random random = new Random();

            // Create new File
            using (Bitmap BTM = new Bitmap(Universe.Width, Universe.Height))

            using (Graphics GR = Graphics.FromImage(BTM))


            using (SolidBrush cellBrush = new SolidBrush(Color.LightGreen))
            {
                GR.Clear(Color.DarkViolet);

                foreach (Cell cell in Universegrid.UniverseCells)
                {
                    if (cell.IsAlive)
                    {
                        GR.FillRectangle(cellBrush, cell.CellDisplay);
                    }
                }

                if (Universe.Image != null)
                    Universe.Image.Dispose();  // Release previously saved Universe.

                Universe.Image = (Bitmap)BTM.Clone();
            }
        }

        private void BtnNextGen_Click(object sender, EventArgs e)
        {
            GetNextGen();
        }

        private void BtnBeginGame_Click(object sender, EventArgs e)
        {
            BeginGame();
        }

        private void BeginGame()
        {

            CellularAdvancement = !CellularAdvancement;

            // Edit the text in the button.
            btnPlay.Text = CellularAdvancement ? "Stop" : "Play";

            PlayToolStripMenuItem.Text = CellularAdvancement ? "Stop" : "Play";

            // While CellularAdvancement = true, continue to update the Universe.
            while (CellularAdvancement)
            {
                GetNextGen();
                Application.DoEvents();

                if (TimeDelay.Value > 0)
                {
                    Thread.Sleep((int)TimeDelay.Value);
                }
            }
        }

        private void GameMain_FormExit(object sender, FormClosingEventArgs e)
        {
            // Make sure the program ends when the form is closed.
            CellularAdvancement = false;
            Application.Exit();

        }

        private void Universe_MouseClick(object sender, MouseEventArgs e)
        {
            int CellIndex;
            // Get cell size from first cell ogrid.
            Size cellSize = Universegrid.UniverseCells[0].CellSize;

            // Determine cell index from cell location and cell size.
            int XLoc = e.X / cellSize.Width;
            int YLoc = e.Y / cellSize.Height;

            // Get cell list index from grid index.
            CellIndex = (YLoc * UniverseGrid.Columns) + XLoc;

            // Toggle cell status between dead and alive.
            Universegrid.UniverseCells[CellIndex].IsAlive = !Universegrid.UniverseCells[CellIndex].IsAlive;

            // Update grid.
            UpdateUniverse(UniverseGrid);
        }

        private void BtnEmptyUniverse_Click(object sender, EventArgs e)
        {
            InitializeUniverse(false);
        }

        private void RandomResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ranomize the Universe with a new formation when Restarting
            InitializeUniverse(true);

        }

        private void EmptyUniverseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Empty the universe
            InitializeUniverse(false);

        }

        private void NextGenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Move the simulation forward by one generation
            GetNextGen();
        }

        private void BeginGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginGame();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ImportUniverseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog FileOpen = new OpenFileDialog())
                {
                    FileOpen.Title = "Select location of file.";
                    FileOpen.Filter = "gam files (*.gam)|*.gam|All files (*.*)|*.*";

                    if (FileOpen.ShowDialog() == DialogResult.OK)
                    {
                        UniverseGrid.LoadSavedUniverse(FileOpen.FileName, Universe.Size);
                    }
                }

                UpdateUniverse(UniverseGrid);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem loading the specified Universe file.\n" + ex.Message);
            }

        }

        private void SaveUniverseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                using (SaveFileDialog FileSave = new SaveFileDialog())
                {
                    FileSave.Title = "Select location for Universe save file.";
                    FileSave.Filter = "game files (*.game)|*.game|All files (*.*)|*.*";

                    if (FileSave.ShowDialog() == DialogResult.OK)
                    {
                        UniverseGrid.SaveUniverse(FileSave.FileName);
                    }
                    MessageBox.Show("File saved.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem saving the specified Universe's file.\n" + ex.Message);
            }

        }
    }

    public class Universegrid
    {
        public static List<Cell> UniverseCells = new List<Cell>();

        private int CellRows;
        private int CellColumns;

        public Universegrid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
        }

        public int Rows
        {
            get { return CellRows; }
            set { CellRows = value; }
        }

        public int Columns
        {
            get { return CellColumns; }
            set { CellColumns = value; }
        }

        public int NeighbourCount(Cell cell)
        {
            // Function to return number of active neighboring cells.
            // Use cell index numbers to search range of cells for active neighbors.

            int neighbourCount = 0;

            // Get range of cells to be examined for active neighbors.
            int cellIndex = (cell.YPos * Columns) + cell.XPos;
            int startIndex = cellIndex - Columns - 2;
            int endIndex = cellIndex + Columns + 2;


            startIndex = (startIndex < 0) ? 0 : startIndex;
            endIndex = (endIndex > (Universegrid.UniverseCells.Count - 1)) ? Universegrid.UniverseCells.Count - 1 : endIndex;

            // Search through the defined range and look for active neighbors.
            for (int x = startIndex; x < endIndex; x++)
            {
                if (Math.Abs(cell.XPos - UniverseCells[x].XPos) < 2 && Math.Abs(cell.YPos - UniverseCells[x].YPos) < 2)
                {
                    if (Universegrid.UniverseCells[x].Location != cell.Location)
                    {
                        if (UniverseCells[x].IsAlive)
                        {
                            neighbourCount++;
                        }
                    }
                }
            }

            return neighbourCount;
        }

        public void LoadSavedUniverse(string filePath, Size displaySize)
        {
            string? FileText;
            string startText = "", UniverseString = "";
            int cellSize = 10, rows, cols, MaximumSize, cellCount;
            Cell newCell;

            try
            {
                // Empty the list of cells.
                UniverseCells.Clear();

                // Read file.
                using (StreamReader loadFile = new StreamReader(filePath))
                {
                    while (!loadFile.EndOfStream)
                    {
                        // Get line from file.
                        FileText = loadFile.ReadLine();

                        if (FileText != null)
                        {

                            startText = FileText.Substring(0, 1);

                            if (FileText.Substring(0, 4) == "Cell")
                            {
                                // If the line starts with "Cell", it's the cell size.
                                int.TryParse(FileText.Substring(FileText.IndexOf(":") + 1), out int result);
                                cellSize = result;
                            }
                            else if (startText == "0" || startText == "1")
                            {
                                // If the line starts with 0 or 1, treat it as part of the grid.
                                UniverseString += FileText;
                            }
                        }
                    }
                }

                // Determine maximum cell dimensions supported by number of cells and the display size.

                MaximumSize = (int)Math.Sqrt((displaySize.Width * displaySize.Height) / UniverseString.Length);
                MaximumSize = MaximumSize > 25 ? 25 : MaximumSize;
                cellSize = (MaximumSize < cellSize) ? MaximumSize : cellSize;

                // Determine the number of rows and columns in the universal grid.
                rows = displaySize.Height / cellSize;
                cols = displaySize.Width / cellSize;

                Rows = rows;
                Columns = cols;

                // Create the cells in the List<Cell> type.  
                cellCount = 0;
                for (int y = 0; y < rows; y++)
                {
                    for (int x = 0; x < cols; x++)
                    {
                        // Create new cell and toggle it on or off as specified.


                        // If the number of cells needed exceeds the number of cells specified in the file, set all the ones after to IsAlive = False.
                        // The game cannot go on at this point.
                        newCell = new Cell(x, y, cellSize);

                        if (cellCount < UniverseString.Length)
                            newCell.IsAlive = (UniverseString[cellCount]) == '1' ? true : false;
                        else
                            newCell.IsAlive = false;

                        cellCount++;
                    }
                }


                Universegrid.UniverseCells = Universegrid.UniverseCells.OrderBy(c => c.XPos).OrderBy(c => c.YPos).ToList();
            }
            catch (Exception)
            {
                throw;
            }


        }

        public void SaveUniverse(string filePath)
        {
            string rowString = "";
            int cellIndex = 0;

            try
            {
                using (StreamWriter saveFile = new StreamWriter(filePath))
                {
                    saveFile.WriteLine($"Cell size: {UniverseCells[0].CellSize.Width.ToString()} ");
                    saveFile.WriteLine("-- BEGIN Universe --");
                    // Save the current universe to a text file
                    for (int y = 0; y < Rows; y++)
                    {
                        for (int x = 0; x < Columns; x++)
                        {
                            rowString += UniverseCells[cellIndex].IsAlive ? "1" : "0";
                            cellIndex++;
                        }
                        saveFile.WriteLine(rowString);
                        rowString = "";
                    }
                    saveFile.WriteLine("-- END Universe --");
                    saveFile.Flush();
                    saveFile.Close();

                }
            }
            catch (Exception)
            {
                throw;
            }

        }

    }


    public class Cell
    {
        private Point cellLocation;
        private Rectangle cCellDisplay;
        private Size cCellSize;
        private int cellXPos;
        private int cellYPos;
        private Boolean cellIsAlive;
        private Boolean NextCell;

        public Cell(int CellSize)
        {
            Universegrid.UniverseCells.Add(this);
            this.CellSize = new Size(CellSize, CellSize);
        }
        public Cell(Point location, int X, int Y)
        {
            int cellSize;
            Location = location;
            YPos = Y;
            XPos = X;
            Universegrid.UniverseCells.Add(this);

            cellSize = (X == 0) ? 0 : location.X / X;
        }

        public Cell(int X, int Y, int CellSize)
        {
            Location = new Point(X * CellSize, Y * CellSize);
            XPos = X;
            YPos = Y;
            this.CellSize = new Size(CellSize, CellSize);
            Universegrid.UniverseCells.Add(this);
        }

        public Rectangle CellDisplay
        {
            //  For displaying cell when needed.
            get { return cCellDisplay; }
            set { cCellDisplay = value; }
        }

        public Size CellSize
        {
            // Calculated cell size.
            get { return cCellSize; }
            set
            {
                cCellSize = value;
                // Update the display  at the same time.
                CellDisplay = new Rectangle(Location, new Size(value.Width - 1, value.Height - 1));
            }
        }

        public Point Location
        {
            // X,Y Point that specifies cell location on axes.
            get { return cellLocation; }
            set { cellLocation = value; }
        }

        public int XPos
        {
            // Cell position on X-axis
            get { return cellXPos; }
            set { cellXPos = value; }
        }

        public int YPos
        {
            // Cell position on Y-axis
            get { return cellYPos; }
            set { cellYPos = value; }
        }

        public Boolean IsAlive
        {

            get { return cellIsAlive; }
            set { cellIsAlive = value; }
        }

        public Boolean NextGenStatus
        {
            get { return NextCell; }
            set { NextCell = value; }
        }

        public override string ToString()
        {

            return $"UniverseX:{XPos}  UniverseY:{YPos}  Alive:{IsAlive}  Next:{NextGenStatus}";
        }

    }
}
