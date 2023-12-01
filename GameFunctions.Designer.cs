namespace RecinosGameOfLife
{
    partial class Game
    {


        /*

        Important Information: The mouse can be used to toggle cells on and off or create cells once you erase the universe by clicking clear. 
        Or the grid may be reset at your whim, randomly of course. must reset the game to implement changes to cell size

        */


        private System.ComponentModel.IContainer components = null;



        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code


        private void InitializeComponent()
        {
            this.Universe = new System.Windows.Forms.PictureBox();
            this.CellSize = new System.Windows.Forms.NumericUpDown();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnNextGen = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnEmpty = new System.Windows.Forms.Button();
            this.Main = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportUniverseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveUniverseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripdimensions2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RandomResetUniverseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EmptyUniverseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripdimensions1 = new System.Windows.Forms.ToolStripSeparator();
            this.NextGenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeDelay = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.FileSave = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.Universe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CellSize)).BeginInit();
            this.Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeDelay)).BeginInit();
            this.SuspendLayout();

            // Universe

            this.Universe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Universe.Location = new System.Drawing.Point(19, 42);
            this.Universe.Name = "Universe";
            this.Universe.Size = new System.Drawing.Size(913, 450);
            this.Universe.TabIndex = 0;
            this.Universe.TabStop = false;
            this.Universe.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Universe_MouseClick);

            // CellSize

            this.CellSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CellSize.Location = new System.Drawing.Point(872, 514);
            this.CellSize.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.CellSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.CellSize.Name = "CellSize";
            this.CellSize.Size = new System.Drawing.Size(60, 23);
            this.CellSize.TabIndex = 1;
            this.CellSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});

            // label1

            this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(813, 518);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(53, 15);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Cell Size:";

            // btnReset

            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReset.Location = new System.Drawing.Point(233, 508);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(116, 25);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "RandomReset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnRandomReset_Click);

            // btnNextGen

            this.btnNextGen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextGen.Location = new System.Drawing.Point(446, 527);
            this.btnNextGen.Name = "btnNextGen";
            this.btnNextGen.Size = new System.Drawing.Size(75, 23);
            this.btnNextGen.TabIndex = 4;
            this.btnNextGen.Text = "NextGen";
            this.btnNextGen.UseVisualStyleBackColor = true;
            this.btnNextGen.Click += new System.EventHandler(this.BtnNextGen_Click);

            // btnPlay

            this.btnPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlay.Location = new System.Drawing.Point(50, 508);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(82, 23);
            this.btnPlay.TabIndex = 5;
            this.btnPlay.Text = "BeginGame";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.BtnBeginGame_Click);

            // btnEmpty

            this.btnEmpty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEmpty.Location = new System.Drawing.Point(247, 546);
            this.btnEmpty.Name = "btnEmpty";
            this.btnEmpty.Size = new System.Drawing.Size(75, 23);
            this.btnEmpty.TabIndex = 6;
            this.btnEmpty.Text = "Empty";
            this.btnEmpty.UseVisualStyleBackColor = true;
            this.btnEmpty.Click += new System.EventHandler(this.BtnEmptyUniverse_Click);

            // mMain

            this.Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.gameToolStripMenuItem});
            this.Main.Location = new System.Drawing.Point(0, 0);
            this.Main.Name = "Main";
            this.Main.Size = new System.Drawing.Size(944, 24);
            this.Main.TabIndex = 7;
            this.Main.Text = "menuStrip1";

            // fileToolStripMenuItem

            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImportUniverseToolStripMenuItem,
            this.SaveUniverseToolStripMenuItem,
            this.toolStripdimensions2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";

            // Import Universe ToolStripMenuItem

            this.ImportUniverseToolStripMenuItem.Name = "ImportUniverseToolStripMenuItem";
            this.ImportUniverseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ImportUniverseToolStripMenuItem.Text = "Import Universe";
            this.ImportUniverseToolStripMenuItem.Click += new System.EventHandler(this.ImportUniverseToolStripMenuItem_Click);

            // SaveUniverseToolStripMenuItem

            this.SaveUniverseToolStripMenuItem.Name = "SaveUniverseToolStripMenuItem";
            this.SaveUniverseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.SaveUniverseToolStripMenuItem.Text = "Save Universe";
            this.SaveUniverseToolStripMenuItem.Click += new System.EventHandler(this.SaveUniverseToolStripMenuItem_Click);

            // toolStripdimensions2

            this.toolStripdimensions2.Name = "toolStripdimensions2";
            this.toolStripdimensions2.Size = new System.Drawing.Size(177, 6);

            // exitToolStripMenuItem

            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);

            // gameToolStripMenuItem

            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RandomResetUniverseToolStripMenuItem,
            this.EmptyUniverseToolStripMenuItem,
            this.toolStripdimensions1,
            this.NextGenToolStripMenuItem,
            this.PlayToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "&Game";

            // RandomResetUniverseToolStripMenuItem

            this.RandomResetUniverseToolStripMenuItem.Name = "RandomlyResetUniverseToolStripMenuItem";
            this.RandomResetUniverseToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.RandomResetUniverseToolStripMenuItem.Text = "&RandomlyResetUniverse";
            this.RandomResetUniverseToolStripMenuItem.Click += new System.EventHandler(this.RandomResetToolStripMenuItem_Click);

            // ToolStripMenuItem

            this.EmptyUniverseToolStripMenuItem.Name = "EmptyUniverseToolStripMenuItem";
            this.EmptyUniverseToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.EmptyUniverseToolStripMenuItem.Text = "Empty ";
            this.EmptyUniverseToolStripMenuItem.Click += new System.EventHandler(this.EmptyUniverseToolStripMenuItem_Click);

            // ToolStripdimensions1

            this.toolStripdimensions1.Name = "toolStripdimensions1";
            this.toolStripdimensions1.Size = new System.Drawing.Size(130, 6);

            this.NextGenToolStripMenuItem.Name = "NextGenStripMenuItem";
            this.NextGenToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.NextGenToolStripMenuItem.Text = "NextGen";
            this.NextGenToolStripMenuItem.Click += new System.EventHandler(this.NextGenToolStripMenuItem_Click);

            this.PlayToolStripMenuItem.Name = "PlayToolStripMenuItem";
            this.PlayToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.PlayToolStripMenuItem.Text = "Play";
            this.PlayToolStripMenuItem.Click += new System.EventHandler(this.BeginGameToolStripMenuItem_Click);

            // TimeDelay

            this.TimeDelay.Location = new System.Drawing.Point(700, 514);
            this.TimeDelay.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.TimeDelay.Name = "TimeDelay";
            this.TimeDelay.Size = new System.Drawing.Size(63, 23);
            this.TimeDelay.TabIndex = 8;

            // label2

            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(615, 516);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "TimeLag(ms):";

            // Game

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 581);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TimeDelay);
            this.Controls.Add(this.btnEmpty);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnNextGen);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.CellSize);
            this.Controls.Add(this.Universe);
            this.Controls.Add(this.Main);
            this.MainMenuStrip = this.Main;
            this.MinimumSize = new System.Drawing.Size(960, 620);
            this.Name = "Game";
            this.Text = "Recino\'s Game of Life";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameMain_FormExit);
            this.Load += new System.EventHandler(this.Start_Game);
            ((System.ComponentModel.ISupportInitialize)(this.Universe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CellSize)).EndInit();
            this.Main.ResumeLayout(false);
            this.Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Universe;
        private System.Windows.Forms.NumericUpDown CellSize;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnNextGen;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnEmpty;
        private System.Windows.Forms.MenuStrip Main;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RandomResetUniverseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EmptyUniverseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripdimensions1;
        private System.Windows.Forms.ToolStripMenuItem NextGenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PlayToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown TimeDelay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SaveFileDialog FileSave;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImportUniverseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveUniverseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripdimensions2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}
