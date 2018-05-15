using FanDuelTest.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FanDuelTest
{
	public partial class App : Application
	{
        ViewModelLocator modelLocator;

		public  App()
		{
			InitializeComponent();
            GetPlayerData();
            modelLocator = new ViewModelLocator();
            MainPage = new NavigationPage(new FanDuelTest.MainPage());

        }

        protected override void OnStart ()
		{
        }


        public async Task GetPlayerData()
        {
            try
            {
                //download player JSON Data
                string jsonData = await FanDuelTest.Core.JSON.JSONHelper.DownloadJSON();

                if (!String.IsNullOrWhiteSpace(jsonData))
                {
                    //deserialize json to objects and store in viewmodel
                    modelLocator.ViewModel.AllPlayers = FanDuelTest.Core.JSON.JSONHelper.DeserializeJSON(jsonData);
                }
            }
            catch
            {
                //display an alert if a problem has occured

            }

        }

        protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
