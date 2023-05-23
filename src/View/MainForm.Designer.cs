namespace Othello_for_three_players
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            Canvas = new PictureBox();
            Results = new GroupBox();
            Play = new Button();
            groupBox2 = new GroupBox();
            white = new Label();
            red = new Label();
            black = new Label();
            Reset = new Button();
            StartSimulation = new Button();
            BackWork = new System.ComponentModel.BackgroundWorker();
            BackgroundSimulation = new System.ComponentModel.BackgroundWorker();
            BackgroundGame = new System.ComponentModel.BackgroundWorker();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Canvas).BeginInit();
            Results.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(Results, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1182, 853);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(Canvas);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1026, 847);
            panel1.TabIndex = 0;
            // 
            // Canvas
            // 
            Canvas.BackColor = Color.Gray;
            Canvas.Dock = DockStyle.Fill;
            Canvas.Location = new Point(0, 0);
            Canvas.Name = "Canvas";
            Canvas.Size = new Size(1026, 847);
            Canvas.SizeMode = PictureBoxSizeMode.CenterImage;
            Canvas.TabIndex = 0;
            Canvas.TabStop = false;
            Canvas.MouseClick += Canvas_MouseClick;
            Canvas.MouseMove += Canvas_MouseMove;
            // 
            // Results
            // 
            Results.BackColor = Color.Silver;
            Results.Controls.Add(Play);
            Results.Controls.Add(groupBox2);
            Results.Controls.Add(Reset);
            Results.Controls.Add(StartSimulation);
            Results.Dock = DockStyle.Fill;
            Results.Location = new Point(1035, 3);
            Results.Name = "Results";
            Results.Size = new Size(144, 847);
            Results.TabIndex = 1;
            Results.TabStop = false;
            // 
            // Play
            // 
            Play.Location = new Point(6, 44);
            Play.Name = "Play";
            Play.Size = new Size(132, 29);
            Play.TabIndex = 6;
            Play.Text = "Play the game";
            Play.UseVisualStyleBackColor = true;
            Play.Click += Play_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(white);
            groupBox2.Controls.Add(red);
            groupBox2.Controls.Add(black);
            groupBox2.Location = new Point(3, 116);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(135, 125);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Disks on board";
            // 
            // white
            // 
            white.AutoSize = true;
            white.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            white.ForeColor = SystemColors.ButtonFace;
            white.Location = new Point(6, 53);
            white.Name = "white";
            white.Size = new Size(68, 20);
            white.TabIndex = 2;
            white.Text = "White: 3";
            // 
            // red
            // 
            red.AutoSize = true;
            red.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            red.ForeColor = Color.FromArgb(192, 0, 0);
            red.Location = new Point(6, 87);
            red.Name = "red";
            red.Size = new Size(53, 20);
            red.TabIndex = 1;
            red.Text = "Red: 3";
            // 
            // black
            // 
            black.AutoSize = true;
            black.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            black.Location = new Point(6, 23);
            black.Name = "black";
            black.Size = new Size(64, 20);
            black.TabIndex = 0;
            black.Text = "Black: 3";
            // 
            // Reset
            // 
            Reset.Enabled = false;
            Reset.Location = new Point(3, 81);
            Reset.Name = "Reset";
            Reset.Size = new Size(135, 29);
            Reset.TabIndex = 4;
            Reset.Text = "Reset board";
            Reset.UseVisualStyleBackColor = true;
            Reset.Click += Reset_Click;
            // 
            // StartSimulation
            // 
            StartSimulation.Location = new Point(3, 9);
            StartSimulation.Name = "StartSimulation";
            StartSimulation.Size = new Size(135, 29);
            StartSimulation.TabIndex = 3;
            StartSimulation.Text = "Start simulation";
            StartSimulation.UseVisualStyleBackColor = true;
            StartSimulation.Click += StartSimulation_Click;
            // 
            // BackWork
            // 
            BackWork.DoWork += BackWork_DoWork;
            // 
            // BackgroundSimulation
            // 
            BackgroundSimulation.DoWork += BackgroundSimulation_DoWork;
            BackgroundSimulation.RunWorkerCompleted += BackgroundSimulation_RunWorkerCompleted;
            // 
            // BackgroundGame
            // 
            BackgroundGame.DoWork += BackgroundGame_DoWork;
            BackgroundGame.RunWorkerCompleted += BackgroundGame_RunWorkerCompleted;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 853);
            Controls.Add(tableLayoutPanel1);
            Name = "MainForm";
            Text = "Othello";
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Canvas).EndInit();
            Results.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private PictureBox Canvas;
        private System.ComponentModel.BackgroundWorker BackWork;
        private GroupBox Results;
        private Button StartSimulation;
        private System.ComponentModel.BackgroundWorker BackgroundSimulation;
        private Button Reset;
        private GroupBox groupBox2;
        private Label white;
        private Label red;
        private Label black;
        private Button Play;
        private System.ComponentModel.BackgroundWorker BackgroundGame;
    }
}