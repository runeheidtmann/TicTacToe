using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KrydsOgBolle
{
	public partial class MainPage : ContentPage
	{
        int plays = 2;
        bool playerX = true;
        int[,] board = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

        public MainPage()
		{
			InitializeComponent();

		}
        async private void checkIfDone()
        {
            /* Mulig forbedring:
             * Det er kun muligt at vinde, hvis man kan få tre på stribe.
             * Derfor er spillet slut, hvis alle rækker har BÅDE X og O i sig.
             * Lav en algoritme der går ind og tjekker det, hver gang.
             */
            bool weiter = false;
            foreach (int numb in board)
                if (numb == 0)
                {
                    //hvis INGEN er 0, så er der ikke flere ledige pladser og variablen weiter forbliver false.
                    weiter = true;
                    break;
                }
                

            if (!weiter)
            {
                await DisplayAlert("Too bad!", "No one won!", "Play again!");

                resetGame();
            }
                    
                
        }
        void resetGame()
        {
            a1.Text = "";
            a2.Text = "";
            a3.Text = "";

            b1.Text = "";
            b2.Text = "";
            b3.Text = "";

            c1.Text = "";
            c2.Text = "";
            c3.Text = "";
            plays = 2;
            //reset board-array
            for (int y = 0; y < board.GetLength(0); y++)
            {
                for (int x = 0; x < board.GetLength(1); x++)
                {
                    board[y, x] = 0;
                }
            }
            whosNext();
        }

        async private void checkForWin()
        {
            // Winning combinations:
            // a1, b1, c1
            // a2, b2, c2
            // a3, b3, c3

            // a1, a2, a3
            // b1, b2, b3
            // c1, c2, c3

            //a1, b2, c3
            //c1, b2, a3

            //If sum of combinations is 51(3*17) X has won.
            //if Sum of combinations is 21(3*7) O has won.

            int[] winArray = new int[] {
             board[0,0] + board[0, 1] + board[0, 2],
             board[1, 0] + board[1, 1] + board[1, 2],
             board[2, 0] + board[2, 1] + board[2, 2],
             board[0, 0] + board[1, 0] + board[2, 0],
             board[0, 1] + board[1, 1] + board[2, 1],
             board[0, 2] + board[1, 2] + board[2, 2],
             board[0, 0] + board[1, 1] + board[2, 2],
             board[2, 0] + board[1, 1] + board[0, 2]  };

            bool someWon = false;

            foreach (int xo in winArray)
            {
                if (xo == 51 || xo == 21)
                {
                    if (plays % 2 == 0)
                    {
                        await DisplayAlert("X won!!!", "Play again?", "Play!");
                        someWon = true;
                    }
                    else
                    {
                        await DisplayAlert("O won!!!", "Play again?", "Play!");
                        someWon = true;
                    }

                    //Time to start game over:
                    resetGame();
                    break;
                }
            }
            if (!someWon)
                checkIfDone(); //Hvis ingen vandt kan vi se, om der er flere mulige træk. Hvis ikke stopper spillet.

        }
        private void whosNext()
        {
            //Method for controlling the player-labels, that shows whos turn it is.

            if (plays % 2 == 0)
            {
                lblX.BackgroundColor = Color.FromHex("#0be881");
                lblO.BackgroundColor = Color.FromHex("#1e272e");
                lblX.Text = "X to play!";
                lblO.Text = "";
            }
            else
            {
                lblX.BackgroundColor = Color.FromHex("#1e272e");
                lblO.BackgroundColor = Color.FromHex("#ef5777");
                lblX.Text = "";
                lblO.Text = "O to play!";

            }
        }
        private void a1_Clicked(object sender, EventArgs e)
        {
            
            //If board-field is equal to zero, it is free. If not, dont do anything.
            if (board[0,0] == 0 )
            {
                if (plays % 2 == 0)
                {
                    board[0, 0] = 17;
                    a1.Text = "X";
                }
                else
                {
                    board[0, 0] = 7;
                    a1.Text = "O";
                }
                
                checkForWin(); //Game stops if win
                plays++; //Number of plays incrementet
                whosNext(); 
               
            }

        }
        private void a2_Clicked(object sender, EventArgs e)
        {
            if (board[0, 1] == 0)
            {
                if (plays % 2 == 0)
                {
                    board[0, 1] = 17;
                    a2.Text = "X";
                }
                else
                {
                    board[0, 1] = 7;
                    a2.Text = "O";
                }

                checkForWin(); 
                plays++; 
                whosNext();
               
            }
        }

        private void a3_Clicked(object sender, EventArgs e)
        {
            if (board[0, 2] == 0)
            {
                if (plays % 2 == 0)
                {
                    board[0, 2] = 17;
                    a3.Text = "X";
                }
                else
                {
                    board[0, 2] = 7;
                    a3.Text = "O";
                }

                checkForWin(); 
                plays++; 
                whosNext();
                
            }


        }

        private void b1_Clicked(object sender, EventArgs e)
        {
            if (board[1, 0] == 0)
            {
                if (plays % 2 == 0)
                {
                    board[1, 0] = 17;
                    b1.Text = "X";
                }
                else
                {
                    board[1, 0] = 7;
                    b1.Text = "O";
                }

                checkForWin();
                plays++;
                whosNext();
               
            }
        }

        private void b2_Clicked(object sender, EventArgs e)
        {
            if (board[1, 1] == 0)
            {
                if (plays % 2 == 0)
                {
                    board[1, 1] = 17;
                    b2.Text = "X";
                }
                else
                {
                    board[1, 1] = 7;
                    b2.Text = "O";
                }

                checkForWin();
                plays++;
                whosNext();
               
            }

        }

        private void b3_Clicked(object sender, EventArgs e)
        {
            if (board[1, 2] == 0)
            {
                if (plays % 2 == 0)
                {
                    board[1, 2] = 17;
                    b3.Text = "X";
                }
                else
                {
                    board[1, 2] = 7;
                    b3.Text = "O";
                }

                checkForWin();
                plays++;
                whosNext();
                
            }
        }

        private void c1_Clicked(object sender, EventArgs e)
        {
            if (board[2, 0] == 0)
            {
                if (plays % 2 == 0)
                {
                    board[2, 0] = 17;
                    c1.Text = "X";
                }
                else
                {
                    board[2, 0] = 7;
                    c1.Text = "O";
                }

                checkForWin();
                plays++;
                whosNext();
                
            }

        }

        private void c2_Clicked(object sender, EventArgs e)
        {
            if (board[2, 1] == 0)
            {
                if (plays % 2 == 0)
                {
                    board[2, 1] = 17;
                    c2.Text = "X";
                }
                else
                {
                    board[2, 1] = 7;
                    c2.Text = "O";
                }

                checkForWin();
                plays++;
                whosNext();
               
            }

        }

        private void c3_Clicked(object sender, EventArgs e)
        {
            if (board[2, 2] == 0)
            {
                if (plays % 2 == 0)
                {
                    board[2, 2] = 17;
                    c3.Text = "X";
                }
                else
                {
                    board[2, 2] = 7;
                    c3.Text = "O";
                }

                checkForWin();
                plays++;
                whosNext();
               
            }

        }
    }
}
