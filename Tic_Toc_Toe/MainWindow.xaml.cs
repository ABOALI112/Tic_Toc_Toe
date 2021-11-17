using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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
                button.Content = string.Empty;
            });
           

        }


    }
}
