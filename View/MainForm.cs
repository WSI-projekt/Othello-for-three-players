using Othello_for_three_players.Controller;
using Othello_for_three_players.Model;
using Othello_for_three_players.Model.Players;

namespace Othello_for_three_players
{
    public partial class MainForm : Form
    {
        private GameController gameController;

        public MainForm()
        {
            InitializeComponent();

            // TODO: initialize game controller
        }

        private Move MakeMove(Board board, PlayerID ID)
        {
            // TODO: Make move action on view

            throw new NotImplementedException();
        }

        private void GameEventhandler(GameEvent gameEvent)
        {
            throw new NotImplementedException();
        }
    }
}