using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tic_Toc_Toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region private Members

        /// <summary>
        /// Holds the current results of cells in an active game
        /// </summary>
        private MarkType[] mResults;

        /// <summary>
        /// Turn if player's1 turn is (X) and player's2 is (O)
        /// </summary>
        private bool mplayer1Turn;

        
        /// <summary>
        /// True if  Game Ended 
        /// </summary>
        private bool mGameEnded;

        #endregion
        #region
        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            
            NewGame();

        }


        #endregion
        /// <summary>
        /// Starts a new game and clears all the values to start
        /// </summary>
        private void NewGame()
        {
            // Create a new blank array of free cells
            mResults = new MarkType[9];
            for (int i = 0; i < mResults.Length; i++)
            {
                mResults[i] = MarkType.Free;
            }

            //make sure game starts with player 1 turn
            mplayer1Turn = true;


            //Iterate every button on the grid
            container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                // Change  background,foreground to the default colors
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            });


            //make sure game hasn't end
            mGameEnded = false;
           

        }


        /// <summary>
        /// handles a  btn click event  
        /// </summary>
        /// <param name="sender">the btn that was clicked </param>
        /// <param name="e">the event that are clicked</param>
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            // start a new game on a the click after it finishes
            if (mGameEnded)
            {
                NewGame();
                return;
            }
            // cast the sender to btn
            var button = (Button)sender;

            //find position of the btn clicked in the array
            var column = Grid.GetColumn(button);
            var raw = Grid.GetRow(button);

            var index = column + (raw * 3);


            //dnt alter the clicked btn
            if (mResults[index]!=MarkType.Free)
            {
                return;
            }

            // set the cell value based on the player
            mResults[index] = mplayer1Turn ? MarkType.Cross : MarkType.Nought;

            //set btn text to the result
            button.Content = mplayer1Turn ? "X" : "O";

            if (!mplayer1Turn)
            {
                button.Foreground = Brushes.Red;
            }
            //toggle the players turn
            mplayer1Turn ^= true;

            CheckForWinner();

        }

        /// <summary>
        /// check a winner for a 3 line straight checks
        /// </summary>
        private void CheckForWinner()
        {
            var same = (mResults[0] & mResults[1] & mResults[2]) == mResults[0];
            //checks for horizontal
            if (mResults[0]!=MarkType.Free && same )
            {
                //Game ends
                mGameEnded = true;

                //hightlight winning boxes with green
                btn0_0.Background = btn1_0.Background = btn2_0.Background = Brushes.Green;
            }
        }
    }
}
