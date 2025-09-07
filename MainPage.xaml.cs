using System.Diagnostics;

namespace MauiAppTicTacToe
{
    public partial class MainPage : ContentPage
    {
        private string currentPlayer = "X";
        private List<Button> buttons;

        public MainPage()
        {
            InitializeComponent();
            buttons = game.Children.OfType<Button>().ToList();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btn.Text = currentPlayer;
            btn.IsEnabled = false;

            if (CheckWinner())
            {
                DisplayAlert("Parabéns !!!", $"O jogador {currentPlayer} ganhou", "Zerar");
                ClearBoard();
                return;
            }

            if (buttons.All(b => !b.IsEnabled)) // empate
            {
                DisplayAlert("Empate!", "Ninguém ganhou", "Zerar");
                ClearBoard();
                return;
            }

            // Trocar jogador
            currentPlayer = currentPlayer == "X" ? "O" : "X";
            DisplayAlert("É a vez do: ", currentPlayer, "ok");

        }

        private bool CheckWinner()
        {
            int[][] winningCombinations =
            {
                [0, 1, 2], [3, 4, 5 ], [6, 7, 8 ], // linhas
                [0, 3, 6 ], [1, 4 , 7], [2, 5, 8 ], // colunas
                [0, 4, 8 ], [2, 4, 6 ] // diagonais
            };

            foreach(var combination in winningCombinations)
            {
                if (buttons[combination[0]].Text == currentPlayer &&
                    buttons[combination[1]].Text == currentPlayer &&
                    buttons[combination[2]].Text == currentPlayer)
                {
                    return true;
                }
            }
            return false;
        }

        private void ClearBoard()
        {
            foreach (var btn in buttons)
            {
                btn.Text = "";
                btn.IsEnabled = true;
            }

            currentPlayer = "X"; // Reiniciar para o jogador X
        }
    }

}
