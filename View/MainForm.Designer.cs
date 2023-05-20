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
            groupBox1 = new GroupBox();
            StartSimulation = new Button();
            Test = new Button();
            BackWork = new System.ComponentModel.BackgroundWorker();
            BackgroundGame = new System.ComponentModel.BackgroundWorker();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Canvas).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(groupBox1, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1182, 753);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(Canvas);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1026, 747);
            panel1.TabIndex = 0;
            // 
            // Canvas
            // 
            Canvas.BackColor = Color.Gray;
            Canvas.Dock = DockStyle.Fill;
            Canvas.Location = new Point(0, 0);
            Canvas.Name = "Canvas";
            Canvas.Size = new Size(1026, 747);
            Canvas.SizeMode = PictureBoxSizeMode.CenterImage;
            Canvas.TabIndex = 0;
            Canvas.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(StartSimulation);
            groupBox1.Controls.Add(Test);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(1035, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(144, 747);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // StartSimulation
            // 
            StartSimulation.Location = new Point(3, 44);
            StartSimulation.Name = "StartSimulation";
            StartSimulation.Size = new Size(135, 29);
            StartSimulation.TabIndex = 3;
            StartSimulation.Text = "Start simulation";
            StartSimulation.UseVisualStyleBackColor = true;
            StartSimulation.Click += StartSimulation_Click;
            // 
            // Test
            // 
            Test.Location = new Point(3, 9);
            Test.Name = "Test";
            Test.Size = new Size(135, 29);
            Test.TabIndex = 2;
            Test.Text = "AnimationTest";
            Test.UseVisualStyleBackColor = true;
            Test.Click += Test_Click;
            // 
            // BackWork
            // 
            BackWork.DoWork += BackWork_DoWork;
            BackWork.ProgressChanged += BackWork_ProgressChanged;
            BackWork.RunWorkerCompleted += BackWork_RunWorkerCompleted;
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
            ClientSize = new Size(1182, 753);
            Controls.Add(tableLayoutPanel1);
            Name = "MainForm";
            Text = "Othello";
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Canvas).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private PictureBox Canvas;
        private System.ComponentModel.BackgroundWorker BackWork;
        private GroupBox groupBox1;
        private Button Test;
        private Button StartSimulation;
        private System.ComponentModel.BackgroundWorker BackgroundGame;
    }
}