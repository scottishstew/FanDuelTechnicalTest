using FanDuelTest.BusinessObjects;
using FanDuelTest.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FanDuelTest
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GamePage : ContentPage
    {
        //viewmodel for our game page
        ViewModelLocator modelLocator;

        public GamePage()
        {
            InitializeComponent();
            this.Title = "Stewart Fullerton's FanDuel Game";
            modelLocator = new ViewModelLocator();

            //randomize selectable players for first guess
            RandomizeSelectablePlayers();

            lstAllPlayers.ItemsSource = modelLocator.ViewModel.SelectablePlayers;
            modelLocator.ViewModel.ResetScoresAndGuesses();
            lblScore.Text = modelLocator.ViewModel.ScoreString;
            lstAllPlayers.ItemSelected += LstAllPlayers_ItemSelected;
        }

        /// <summary>
        /// invoked when a player is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void LstAllPlayers_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var playerSelected = (Player)e.SelectedItem;

            if (playerSelected != null)
            {
                await RevealFPPGAnswerForPlayer(playerSelected);
            }
        
        lstAllPlayers.SelectedItem = null;
        }
    


        /// <summary>
        /// Randomizes selectable players for user to choose
        /// </summary>
        public void RandomizeSelectablePlayers()
        {
            modelLocator.ViewModel.RandomizeSelectablePlayers();
        }

     
        /// <summary>
        /// Displays dialog box showing FPPG and asks user if they guessed correctly.
        /// </summary>
        /// <param name="player"></param>
        public async Task RevealFPPGAnswerForPlayer(Player player)
        {
            string answer = string.Empty;

            //deal with nullable FPPG variable
            if (player.FPPG.HasValue)
            {
                answer = await DisplayActionSheet(String.Format("{0} has an FPPG of {1}.", player.FullName, player.FPPG.Value.ToString("N0")), null, null, "I guessed correctly", "I guessed incorrectly");
            }
            else
            {
                answer = await DisplayActionSheet(String.Format("{0} has no FPPG Score.", player.FullName), null, null, "I guessed correctly", "I guessed incorrectly");
            }

            await ProcessAnswer(answer);
        }

        /// <summary>
        /// Takes whether user has guessed correctly or not and adds to score if correctly answered
        /// </summary>
        /// <param name="answer"></param>
        /// <returns></returns>
        private async Task ProcessAnswer(string answer)
        {
            //increment score by 1 and randomize players
            if (answer == "I guessed correctly")
            {
                IncrementScore();
                IncrementNoOfGuesses();
                if (modelLocator.ViewModel.UserScore == 10)
                {
                    await DisplayActionSheet(String.Format("Congratulations, you have scored 10 points out of {0} guesses.", modelLocator.ViewModel.NoOfGuesses), null, null, "Finish Game");
                    await this.Navigation.PopAsync();

                }
                else
                {
                    RandomizeSelectablePlayers();
                    lstAllPlayers.ItemsSource = modelLocator.ViewModel.SelectablePlayers;
                }
            }

            //randomize players if guess is wrong
            if (answer == "I guessed incorrectly")
            {
                RandomizeSelectablePlayers();
                lstAllPlayers.ItemsSource = modelLocator.ViewModel.SelectablePlayers;
                IncrementNoOfGuesses();
            }
            lblScore.Text = modelLocator.ViewModel.ScoreString;
        }


        /// <summary>
        /// Increases users score by 1 point
        /// </summary>
        private void IncrementNoOfGuesses()
        {
            modelLocator.ViewModel.IncrementNoOfGuesses();
        }

        /// <summary>
        /// Increases users score by 1 point
        /// </summary>
        private void IncrementScore()
        {
            modelLocator.ViewModel.IncrementScore();
        }
    }
}