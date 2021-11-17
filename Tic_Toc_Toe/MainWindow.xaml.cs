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

        }
    }
}
