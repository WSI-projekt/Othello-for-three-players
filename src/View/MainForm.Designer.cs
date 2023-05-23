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
            recurrencyDepthGroupBox = new GroupBox();
            player1RecurDepthLabel = new Label();
            player2RecurDepthLabel = new Label();
            player3RecurDepthLabel = new Label();
            player3RecDepthNumericUpDown = new NumericUpDown();
            player2RecDepthNumericUpDown = new NumericUpDown();
            player1RecDepthNumericUpDown = new NumericUpDown();
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
            recurrencyDepthGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)player3RecDepthNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)player2RecDepthNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)player1RecDepthNumericUpDown).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 131F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(Results, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            tableLayoutPanel1.Size = new Size(1034, 640);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(Canvas);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 2);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(897, 636);
            panel1.TabIndex = 0;
            // 
            // Canvas
            // 
            Canvas.BackColor = Color.Gray;
            Canvas.Dock = DockStyle.Fill;
            Canvas.Location = new Point(0, 0);
            Canvas.Margin = new Padding(3, 2, 3, 2);
            Canvas.Name = "Canvas";
            Canvas.Size = new Size(897, 636);
            Canvas.SizeMode = PictureBoxSizeMode.CenterImage;
            Canvas.TabIndex = 0;
            Canvas.TabStop = false;
            Canvas.MouseClick += Canvas_MouseClick;
            Canvas.MouseMove += Canvas_MouseMove;
            // 
            // Results
            // 
            Results.BackColor = Color.Silver;
            Results.Controls.Add(recurrencyDepthGroupBox);
            Results.Controls.Add(Play);
            Results.Controls.Add(groupBox2);
            Results.Controls.Add(Reset);
            Results.Controls.Add(StartSimulation);
            Results.Dock = DockStyle.Fill;
            Results.Location = new Point(906, 2);
            Results.Margin = new Padding(3, 2, 3, 2);
            Results.Name = "Results";
            Results.Padding = new Padding(3, 2, 3, 2);
            Results.Size = new Size(125, 636);
            Results.TabIndex = 1;
            Results.TabStop = false;
            // 
            // recurrencyDepthGroupBox
            // 
            recurrencyDepthGroupBox.Controls.Add(player1RecurDepthLabel);
            recurrencyDepthGroupBox.Controls.Add(player2RecurDepthLabel);
            recurrencyDepthGroupBox.Controls.Add(player3RecurDepthLabel);
            recurrencyDepthGroupBox.Controls.Add(player3RecDepthNumericUpDown);
            recurrencyDepthGroupBox.Controls.Add(player2RecDepthNumericUpDown);
            recurrencyDepthGroupBox.Controls.Add(player1RecDepthNumericUpDown);
            recurrencyDepthGroupBox.Location = new Point(3, 201);
            recurrencyDepthGroupBox.Name = "recurrencyDepthGroupBox";
            recurrencyDepthGroupBox.Size = new Size(118, 107);
            recurrencyDepthGroupBox.TabIndex = 7;
            recurrencyDepthGroupBox.TabStop = false;
            recurrencyDepthGroupBox.Text = "Recurrency depth";
            // 
            // player1RecurDepthLabel
            // 
            player1RecurDepthLabel.AutoSize = true;
            player1RecurDepthLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            player1RecurDepthLabel.Location = new Point(6, 19);
            player1RecurDepthLabel.Name = "player1RecurDepthLabel";
            player1RecurDepthLabel.Size = new Size(37, 15);
            player1RecurDepthLabel.TabIndex = 6;
            player1RecurDepthLabel.Text = "Black";
            // 
            // player2RecurDepthLabel
            // 
            player2RecurDepthLabel.AutoSize = true;
            player2RecurDepthLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            player2RecurDepthLabel.ForeColor = SystemColors.ButtonFace;
            player2RecurDepthLabel.Location = new Point(6, 48);
            player2RecurDepthLabel.Name = "player2RecurDepthLabel";
            player2RecurDepthLabel.Size = new Size(41, 15);
            player2RecurDepthLabel.TabIndex = 5;
            player2RecurDepthLabel.Text = "White";
            // 
            // player3RecurDepthLabel
            // 
            player3RecurDepthLabel.AutoSize = true;
            player3RecurDepthLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            player3RecurDepthLabel.ForeColor = Color.FromArgb(192, 0, 0);
            player3RecurDepthLabel.Location = new Point(6, 77);
            player3RecurDepthLabel.Name = "player3RecurDepthLabel";
            player3RecurDepthLabel.Size = new Size(29, 15);
            player3RecurDepthLabel.TabIndex = 4;
            player3RecurDepthLabel.Text = "Red";
            // 
            // player3RecDepthNumericUpDown
            // 
            player3RecDepthNumericUpDown.Location = new Point(51, 75);
            player3RecDepthNumericUpDown.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            player3RecDepthNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            player3RecDepthNumericUpDown.Name = "player3RecDepthNumericUpDown";
            player3RecDepthNumericUpDown.Size = new Size(58, 23);
            player3RecDepthNumericUpDown.TabIndex = 3;
            player3RecDepthNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // player2RecDepthNumericUpDown
            // 
            player2RecDepthNumericUpDown.Location = new Point(52, 46);
            player2RecDepthNumericUpDown.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            player2RecDepthNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            player2RecDepthNumericUpDown.Name = "player2RecDepthNumericUpDown";
            player2RecDepthNumericUpDown.Size = new Size(57, 23);
            player2RecDepthNumericUpDown.TabIndex = 2;
            player2RecDepthNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // player1RecDepthNumericUpDown
            // 
            player1RecDepthNumericUpDown.Location = new Point(52, 17);
            player1RecDepthNumericUpDown.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            player1RecDepthNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            player1RecDepthNumericUpDown.Name = "player1RecDepthNumericUpDown";
            player1RecDepthNumericUpDown.Size = new Size(57, 23);
            player1RecDepthNumericUpDown.TabIndex = 1;
            player1RecDepthNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // Play
            // 
            Play.Location = new Point(5, 33);
            Play.Margin = new Padding(3, 2, 3, 2);
            Play.Name = "Play";
            Play.Size = new Size(116, 22);
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
            groupBox2.Location = new Point(3, 87);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(118, 94);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Disks on board";
            // 
            // white
            // 
            white.AutoSize = true;
            white.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            white.ForeColor = SystemColors.ButtonFace;
            white.Location = new Point(5, 40);
            white.Name = "white";
            white.Size = new Size(54, 15);
            white.TabIndex = 2;
            white.Text = "White: 3";
            // 
            // red
            // 
            red.AutoSize = true;
            red.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            red.ForeColor = Color.FromArgb(192, 0, 0);
            red.Location = new Point(5, 65);
            red.Name = "red";
            red.Size = new Size(42, 15);
            red.TabIndex = 1;
            red.Text = "Red: 3";
            // 
            // black
            // 
            black.AutoSize = true;
            black.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            black.Location = new Point(5, 17);
            black.Name = "black";
            black.Size = new Size(50, 15);
            black.TabIndex = 0;
            black.Text = "Black: 3";
            // 
            // Reset
            // 
            Reset.Enabled = false;
            Reset.Location = new Point(3, 61);
            Reset.Margin = new Padding(3, 2, 3, 2);
            Reset.Name = "Reset";
            Reset.Size = new Size(118, 22);
            Reset.TabIndex = 4;
            Reset.Text = "Reset board";
            Reset.UseVisualStyleBackColor = true;
            Reset.Click += Reset_Click;
            // 
            // StartSimulation
            // 
            StartSimulation.Location = new Point(3, 7);
            StartSimulation.Margin = new Padding(3, 2, 3, 2);
            StartSimulation.Name = "StartSimulation";
            StartSimulation.Size = new Size(118, 22);
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
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1034, 640);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            Text = "Othello";
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Canvas).EndInit();
            Results.ResumeLayout(false);
            recurrencyDepthGroupBox.ResumeLayout(false);
            recurrencyDepthGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)player3RecDepthNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)player2RecDepthNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)player1RecDepthNumericUpDown).EndInit();
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
        private GroupBox recurrencyDepthGroupBox;
        private Label player1RecurDepthLabel;
        private Label player2RecurDepthLabel;
        private Label player3RecurDepthLabel;
        private NumericUpDown player3RecDepthNumericUpDown;
        private NumericUpDown player2RecDepthNumericUpDown;
        private NumericUpDown player1RecDepthNumericUpDown;
    }
}