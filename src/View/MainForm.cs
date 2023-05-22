using Othello_for_three_players.Controller;
using Othello_for_three_players.Model;
using Othello_for_three_players.Model.Players;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Numerics;
using System.Security.Cryptography;

namespace Othello_for_three_players
{
    public partial class MainForm : Form
    {
        private GameController gameController;
        Bitmap gameBoard;
        List<LinearGradientBrush> BlackDisks1 = new List<LinearGradientBrush>();
        List<LinearGradientBrush> BlackDisks2 = new List<LinearGradientBrush>();
        List<LinearGradientBrush> RedDisks1 = new List<LinearGradientBrush>();
        List<LinearGradientBrush> RedDisks2 = new List<LinearGradientBrush>();
        List<LinearGradientBrush> WhiteDisks1 = new List<LinearGradientBrush>();
        List<LinearGradientBrush> WhiteDisks2 = new List<LinearGradientBrush>();
        Board board;
        PlayerID playerID;
        Move move;
        Queue<(int row, int col)> fieldsToFlip;
        public MainForm()
        {
            InitializeComponent();
            // I have no idea how to pass GameEventHandler
            BlackDisks1 = CreateBrushSet(new Point(75, 0), new Point(0, 75),
                Color.FromArgb(49, 49, 49), Color.FromArgb(59, 59, 59),
                Color.FromArgb(48, 48, 48), Color.FromArgb(8, 8, 8),
                Color.FromArgb(48, 48, 48), Color.FromArgb(50, 50, 50));
            BlackDisks2 = CreateBrushSet(new Point(150, 0), new Point(75, 75),
                Color.FromArgb(49, 49, 49), Color.FromArgb(59, 59, 59),
                Color.FromArgb(48, 48, 48), Color.FromArgb(8, 8, 8),
                Color.FromArgb(48, 48, 48), Color.FromArgb(50, 50, 50));
            RedDisks1 = CreateBrushSet(new Point(75, 0), new Point(0, 75),
                Color.FromArgb(159, 49, 49), Color.FromArgb(159, 59, 59),
                Color.FromArgb(159, 48, 48), Color.FromArgb(107, 8, 8),
                Color.FromArgb(159, 48, 48), Color.FromArgb(159, 50, 50));
            RedDisks2 = CreateBrushSet(new Point(150, 0), new Point(75, 75),
                Color.FromArgb(159, 49, 49), Color.FromArgb(159, 59, 59),
                Color.FromArgb(159, 48, 48), Color.FromArgb(107, 8, 8),
                Color.FromArgb(159, 48, 48), Color.FromArgb(159, 50, 50));
            WhiteDisks1 = CreateBrushSet(new Point(75, 0), new Point(0, 75),
                Color.FromArgb(210, 210, 210), Color.FromArgb(220, 220, 220),
                Color.FromArgb(210, 210, 210), Color.FromArgb(140, 140, 140),
                Color.FromArgb(210, 210, 210), Color.FromArgb(215, 215, 215));
            WhiteDisks2 = CreateBrushSet(new Point(150, 0), new Point(75, 75),
                Color.FromArgb(210, 210, 210), Color.FromArgb(220, 220, 220),
                Color.FromArgb(210, 210, 210), Color.FromArgb(140, 140, 140),
                Color.FromArgb(210, 210, 210), Color.FromArgb(215, 215, 215));
            NewDrawArea(681, 681);
            gameController = new GameController(new BotPlayer(PlayerID.Player1, 3, 10),
                new BotPlayer(PlayerID.Player2, 3, 10),
                new BotPlayer(PlayerID.Player3, 3, 10),
                null, this); // TODO - check if the upper sum in heuristics == 10??
            gameController.PrepareBoard();
           // timer1.Start();
        }
        public bool IsAnimationDone()
        {
            return BackWork.IsBusy;
        }
        public List<LinearGradientBrush> CreateBrushSet(Point begin, Point end, Color first, Color second, Color third, Color fourth, Color fifth, Color sixth)
        {
            //creates a set of gradient brushes for one player
            var brushes = new List<LinearGradientBrush>()
            {
                new LinearGradientBrush(
                    begin,
                        end,
                        first,
                        second),
                    new LinearGradientBrush(
                        begin,
                        end,
                        third,
                        fourth),
                    new LinearGradientBrush(
                        begin,
                        end,
                        fifth,
                        sixth)
                };
            return brushes;
        }
        public List<LinearGradientBrush> ChooseBrushes(int player, bool set)
        {
            //chooses a set of brushes to use based on player and diagonal
            //set=true - set1, set==false - set2
            switch (player, set)
            {
                case (1, true):
                    return BlackDisks1;
                case (1, false):
                    return BlackDisks2;
                case (3, true):
                    return RedDisks1;
                case (3, false):
                    return RedDisks2;
                case (2, true):
                    return WhiteDisks1;
                case (2, false):
                    return WhiteDisks2;
            }
            return new List<LinearGradientBrush>();
        }
        /*private Move MakeMove(Board board, PlayerID ID, Move move)
        {
            // TODO: Make move action on view
            throw new NotImplementedException();
        }*/
        public void MakeMove(Board board, Board beforemove, Move move)
        {
            // You call this function from controller to visualise the move that is made
            // board - the state of the board after the move was made
            // beforemove - the state of the board before the move was made
            // both boards are used to draw disks lying on the board and determine which ones are meant to be flipped
            // move - the move made
            if (BackWork.IsBusy != true)
            {
                // Start the asynchronous operation.
                this.board = board;
                this.playerID = move.Player;
                this.move = move;
                this.fieldsToFlip = new Queue<(int row, int col)>();
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (beforemove[i, j] != board[i, j] && (move.Row, move.Column) != (i, j))
                        {
                            fieldsToFlip.Enqueue((i, j));
                        }
                    }
                }
                BackWork.RunWorkerAsync();
            }

        }

        private void GameEventhandler(GameEvent gameEvent)
        {
            throw new NotImplementedException();
        }
        public void DrawDisksOnBoard_GameController(Board board, Queue<(int row, int col)> fieldsToChange)
        {
            // this function is called from PrepareBoard method in game controller
            // it draws starting position of the game
            DrawDisksOnBoard(Graphics.FromImage(gameBoard), board, fieldsToChange);
        }
        private void NewDrawArea(int w, int h)
        {
            //creates new bitmap, draws board and starting position
            //drawing starting position can be moved once the gamecontrollers is implemented
            gameBoard = new Bitmap(w, h);
            Canvas.Image = gameBoard;
            DrawBoard(Graphics.FromImage(gameBoard));
            // Board board = new Board();
            // board.StartingPosition();

        }
        private void DrawDisksOnBoard(Graphics g, Board board, Queue<(int row, int col)> fieldsToChange)
        {
            //draws disks on mode that will not be flipped during this move
            g.SmoothingMode = SmoothingMode.AntiAlias;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i, j] != 0 && !fieldsToChange.Contains((i, j)))
                    {
                        var brushSet = ChooseBrushes((int)board[i, j], i % 2 == j % 2);
                        DrawDisk(g, brushSet, i, j);
                    }
                }
            }
        }
        private void DrawBoard(Graphics g)
        {
            //draws board
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.Black);
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    DrawField(g, i, j);
                }
            }
        }
        private void DrawDisk(Graphics g, List<LinearGradientBrush> diskBrushes, int row, int col)
        {
            //draws one disk in a player's color, on a specified field 
            g.FillEllipse(diskBrushes[0], 5 + col * 75, 5 + row * 75, 70, 70);
            g.FillEllipse(diskBrushes[1], (float)(5 + 7.5 + col * 75), (float)(5 + 7.5 + row * 75), 55, 55);
            g.FillEllipse(diskBrushes[2], (float)(5 + 8.25 + col * 75), (float)(5 + 9.25 + row * 75), 52, 53);
        }
        private void DrawPlaceDisk(Graphics g, Move move, PlayerID playerID)
        {
            //animation of placing disk on the board
            g.SmoothingMode = SmoothingMode.AntiAlias;
            for (int i = 10; i >= 0; i--)
            {
                DrawScaleDisk(g, ChooseBrushes((int)playerID, move.Row % 2 == move.Column % 2), move.Row, move.Column, 1 + i * 0.1);
                //  Canvas.Refresh();
                Canvas.Invoke(new Action(Canvas.Refresh));
                Thread.Sleep(20);
            }
        }
        private void DrawScaleDisk(Graphics g, List<LinearGradientBrush> diskBrushes, int row, int col, double scale)
        {
            //draws scaled disk on a specified field; a step in PlaceDisk animation
            int s1 = (int)(70 / scale), s2 = (int)(55 / scale), s3 = (int)(52 / scale), s4 = (int)(53 / scale);
            int off1 = (70 - s1) / 2, off2 = (55 - s2) / 2, off3 = (52 - s3) / 2, off4 = (53 - s4) / 2;
            g.FillEllipse(diskBrushes[0], 5 + col * 75 + off1, 5 + row * 75 + off1, s1, s1);
            g.FillEllipse(diskBrushes[1], (float)(5 + 7.5 + col * 75 + off2), (float)(5 + 7.5 + row * 75 + off2), s2, s2);
            g.FillEllipse(diskBrushes[2], (float)(5 + 8.25 + col * 75 + off3), (float)(5 + 9.25 + row * 75 + off4), s3, s4);
        }
        private void DrawFlippedDisks(Graphics g, Queue<(int row, int col)> fieldsToChange, PlayerID playerID, Board board)
        {
            //animation of flipping all disks needed, specified by fieldsToChange queue
            int wid = 0;
            for (int i = 0; i < 12; i++)
            {
                wid = i % 2 == 1 ? wid + 1 : wid;
                double s = Math.Cos(i * Math.PI / 24);
                foreach (var field in fieldsToChange)
                {
                    DrawField(g, field.row, field.col);
                    DrawFlippedDiskOut(g, ChooseBrushes((int)board[field.row, field.col], field.row % 2 == field.col % 2), field.row, field.col, s, wid);
                }
                //  Canvas.Refresh();
                Canvas.Invoke(new Action(Canvas.Refresh));
                Thread.Sleep(25);
            }
            foreach (var field in fieldsToChange)
            {
                DrawField(g, field.row, field.col);
                g.FillRectangle(Brushes.DarkOrange, 5 + field.col * 75, 5 + field.row * 75 + 35 - wid + wid / 2, 70, wid);
            }
            // Canvas.Refresh();
            Canvas.Invoke(new Action(Canvas.Refresh));
            Thread.Sleep(5);
            for (int i = 11; i >= 0; i--)
            {
                wid = i % 2 == 1 ? wid - 1 : wid;
                double s = Math.Cos(i * Math.PI / 24);
                foreach (var field in fieldsToChange)
                {
                    DrawField(g, field.row, field.col);
                    DrawFlippedDiskIn(g, ChooseBrushes((int)playerID, field.row % 2 == field.col % 2), field.row, field.col, s, wid);
                }
                //   Canvas.Refresh();
                Canvas.Invoke(new Action(Canvas.Refresh));
                Thread.Sleep(25);
            }
        }
        public void DrawField(Graphics g, int row, int col)
        {
            g.SmoothingMode = SmoothingMode.Default;
            g.FillRectangle(Brushes.Green, 3 + col * 75, 3 + row * 75, 74, 74);
        }
        public void DrawFlippedDiskOut(Graphics g, List<LinearGradientBrush> diskBrushes, int row, int col, double scale, int width)
        {
            //a step in animation of flipping disk - this is the part for the disk that is on board
            int offw = width / 2;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int s1 = (int)(70 * scale), s2 = (int)(55 * scale), s4 = (int)(53 * scale);
            int off1 = (70 - s1) / 2, off2 = (55 - s2) / 2, off4 = (53 - s4) / 2;
            g.FillEllipse(Brushes.DarkOrange, 5 + col * 75, 5 + row * 75 + off1 - width + offw, 70, s1);
            g.FillRectangle(Brushes.DarkOrange, (5 + col * 75), (float)(5 + row * 75 + off1 - width) + s1 / 2 + offw, 70, width);
            g.FillEllipse(diskBrushes[0], 5 + col * 75, 5 + row * 75 + off1 + offw, 70, s1);
            g.FillEllipse(diskBrushes[1], (float)(5 + 7.5 + col * 75), (float)(5 + 7.5 + row * 75 + off2) + offw, 55, s2);
            g.FillEllipse(diskBrushes[2], (float)(5 + 8.25 + col * 75), (float)(5 + 9.25 + row * 75 + off4) + offw, 52, s4);
        }
        public void DrawFlippedDiskIn(Graphics g, List<LinearGradientBrush> diskBrushes, int row, int col, double s, int width)
        {
            //a step in animation of flipping disk - this is the part for the disk that is being placed on board
            int offw = width / 2;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int s1 = (int)(70 * s), s2 = (int)(55 * s), s4 = (int)(53 * s);
            int off1 = (70 - s1) / 2, off2 = (55 - s2) / 2, off4 = (53 - s4) / 2;
            g.FillEllipse(Brushes.DarkOrange, 5 + col * 75, 5 + row * 75 + off1 + width - offw, 70, s1);
            g.FillRectangle(Brushes.DarkOrange, (5 + col * 75), (float)(5 + row * 75 + off1) + s1 / 2 - offw, 70, width);
            g.FillEllipse(diskBrushes[0], 5 + col * 75, 5 + row * 75 + off1 - offw, 70, s1);
            g.FillEllipse(diskBrushes[1], (float)(5 + 7.5 + col * 75), (float)(5 + 7.5 + row * 75 + off2) - offw, 55, s2);
            g.FillEllipse(diskBrushes[2], (float)(5 + 8.25 + col * 75), (float)(5 + 9.25 + row * 75 + off4) - offw, 52, s4);
        }

        private void Test_Click(object sender, EventArgs e)
        {
            // this was used to test a single animation, it wont be needed anymore
        }

        private void BackWork_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            // the animations are run using BackgroundWorker
            // this method calls all function necessary to draw everything
            DrawBoard(Graphics.FromImage(gameBoard));
            DrawDisksOnBoard(Graphics.FromImage(gameBoard), board, new Queue<(int row, int col)>());
            DrawPlaceDisk(Graphics.FromImage(gameBoard), move, playerID);
            Thread.Sleep(200);
            DrawFlippedDisks(Graphics.FromImage(gameBoard), fieldsToFlip, playerID, board);
        }

        private void BackWork_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            // Test.Enabled = true;
        }

        private void StartSimulation_Click(object sender, EventArgs e)
        {
            //start game simulation on click
            // the game controller's simulation is run using Background worker as well (otherwise the animation didn't show)
            // method starts the work in the backgroungd - see BackgroundGame_DoWork

            Test.Enabled = false;
            StartSimulation.Enabled = false;
            BackgroundGame.RunWorkerAsync();

        }

        private void BackgroundGame_DoWork(object sender, DoWorkEventArgs e)
        {
            // start the simulation
            // TestThreeMoves was a method that initially made only three moves at a time
            // it is now a simulation of the game where the players place disks in the first place they find
            gameController.TestThreeMoves();
        }

        private void BackgroundGame_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            StartSimulation.Enabled = true;
        }

        private void BackWork_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Canvas.Refresh();
        }
    }
}