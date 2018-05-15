using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FanDuelTest.Core.ViewModels;
using FanDuelTest.Core.JSON;
using FanDuelTest.BusinessObjects;
using System.Collections.Generic;

namespace FanDuelTest.Tests
{
    [TestClass]
    public class TestClass
    {
        ViewModelLocator modelLocator;
        List<PlayerList> PlayerList;

        [TestInitialize]
        public void Setup()
        {
            PlayerList = new List<BusinessObjects.PlayerList>();
            modelLocator = new ViewModelLocator();
        }

        [TestMethod]
        public void Did_Scores_Reset()
        {
            modelLocator.ViewModel.ResetScoresAndGuesses();
            Assert.AreEqual(modelLocator.ViewModel.UserScore, 0);
            Assert.AreEqual(modelLocator.ViewModel.NoOfGuesses, 0);

        }

        [TestMethod]
        public  void Did_JSON_Download_Successfully()
        {
            string jsonString =  JSONHelper.DownloadJSON().Result;
            bool jsonReturned = !String.IsNullOrWhiteSpace(jsonString);
            Assert.IsTrue(jsonReturned);
        }

        [TestMethod]
        public void Did_JSON_Deserialize_Successfully()
        {
            string jsonString = JSONHelper.DownloadJSON().Result;
            modelLocator.ViewModel.AllPlayers = JSONHelper.DeserializeJSON(jsonString);
            Assert.IsNotNull(modelLocator.ViewModel.AllPlayers);
        }

        [TestMethod]
        public void Did_Two_Selectable_Players_Populate()
        {
            string jsonString = JSONHelper.DownloadJSON().Result;
            modelLocator.ViewModel.AllPlayers = JSONHelper.DeserializeJSON(jsonString);
            modelLocator.ViewModel.RandomizeSelectablePlayers();

            Assert.IsNotNull(modelLocator.ViewModel.SelectablePlayers);
        }

        [TestMethod]
        public void Did_Score_String_Display()
        {
            bool scoreDisplayed = !String.IsNullOrWhiteSpace(modelLocator.ViewModel.ScoreString);

            Assert.IsTrue(scoreDisplayed);
        }

        [TestMethod]
        public void Did_Score_Increment()
        {
            modelLocator.ViewModel.IncrementScore();
            Assert.AreEqual(modelLocator.ViewModel.UserScore, 1);
        }

        [TestMethod]
        public void Did_Number_Of_Guesses_Increment()
        {
            modelLocator.ViewModel.IncrementNoOfGuesses();
            Assert.AreEqual(modelLocator.ViewModel.NoOfGuesses, 1);

        }

        [TestMethod]
        public void Did_Score_Add_Up_To_10()
        {
            modelLocator.ViewModel.IncrementScore();
            Assert.AreEqual(modelLocator.ViewModel.UserScore, 1);

            modelLocator.ViewModel.IncrementScore();
            Assert.AreEqual(modelLocator.ViewModel.UserScore, 2);

            modelLocator.ViewModel.IncrementScore();
            Assert.AreEqual(modelLocator.ViewModel.UserScore, 3);

            modelLocator.ViewModel.IncrementScore();
            Assert.AreEqual(modelLocator.ViewModel.UserScore, 4);

            modelLocator.ViewModel.IncrementScore();
            Assert.AreEqual(modelLocator.ViewModel.UserScore, 5);

            modelLocator.ViewModel.IncrementScore();
            Assert.AreEqual(modelLocator.ViewModel.UserScore, 6);

            modelLocator.ViewModel.IncrementScore();
            Assert.AreEqual(modelLocator.ViewModel.UserScore, 7);

            modelLocator.ViewModel.IncrementScore();
            Assert.AreEqual(modelLocator.ViewModel.UserScore, 8);

            modelLocator.ViewModel.IncrementScore();
            Assert.AreEqual(modelLocator.ViewModel.UserScore, 9);

            modelLocator.ViewModel.IncrementScore();
            Assert.AreEqual(modelLocator.ViewModel.UserScore, 10);

        }

    }
}
