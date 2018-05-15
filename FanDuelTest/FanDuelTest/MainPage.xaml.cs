using FanDuelTest.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FanDuelTest
{
	public partial class MainPage : ContentPage
	{
        ViewModelLocator modelLocator;

        public  MainPage()
		{
			InitializeComponent();
            this.Title = "Stewart Fullerton's FanDuel Game";
            modelLocator = new ViewModelLocator();

        }


        /// <summary>
        /// Start the game after button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Clicked(object sender, EventArgs e)
        {
            if (modelLocator.ViewModel.AllPlayers == null)
            {
                DisplayAlert("Failed to Download Player data.", "Downloading of Player data failed, please ensure that you are connected to the internet and restart the app.", "OK");
            }
            else
            {
                this.Navigation.PushAsync(new GamePage());
            }
        }
    }
}
