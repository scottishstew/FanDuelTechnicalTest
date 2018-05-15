using FanDuelTest.BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Linq;
using System.Collections.ObjectModel;

namespace FanDuelTest.Core.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string ScoreString
        {
            get
            {
                return String.Format("Your current Score is {0} point(s) out of {1} guesses.", UserScore, NoOfGuesses);
            }
        }

        public void ResetScoresAndGuesses()
        {
            NoOfGuesses = 0;
            UserScore = 0;
        }

        /// <summary>
        /// Picks 2 selectable players at random
        /// </summary>
        public void RandomizeSelectablePlayers()
        {
            if (AllPlayers != null)
            {
                SelectablePlayers = new ObservableCollection<Player>();

                Random rdm = new Random();

                var firstPlayerElement = rdm.Next(0, AllPlayers.Players.Count);
                var secondPlayerElement = rdm.Next(0, AllPlayers.Players.Count);

                var firstPlayer = AllPlayers.Players.ElementAt(firstPlayerElement);
                var secondPlayer = AllPlayers.Players.ElementAt(secondPlayerElement);


                //add randomly selected players to the selectable players list
                SelectablePlayers.Add(firstPlayer);

                SelectablePlayers.Add(secondPlayer);

            }
        }

        /// <summary>
        /// Users score, increment by 1 if they guess the FPPG correctly
        /// </summary>
        private int _userScore;
        public int UserScore
        {
            get
            {
                return _userScore;
            }

            set
            {
                _userScore = value;
                NotifyPropertyChanged();
            }

        }

        /// <summary>
        /// Number of Guesses, increment by 1 if user either guesses right or wrong
        /// </summary>
        private int _noOfGuesses;
        public int NoOfGuesses
        {
            get
            {
                return _noOfGuesses;
            }

            set
            {
                _noOfGuesses = value;
                NotifyPropertyChanged();
            }

        }

        /// <summary>
        /// All available players
        /// </summary>
        private PlayerList _allPlayers;
        public PlayerList AllPlayers {
            get
            {
                return _allPlayers;
            }

            set
            {
                _allPlayers = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Increments user score by 1
        /// </summary>
        public void IncrementScore()
        {
            UserScore = UserScore + 1;
        }


       /// <summary>
       /// 2 Selectable Players that are presented on the screen
       /// </summary>
        public ObservableCollection<Player> _selectablePlayers;
        public ObservableCollection<Player> SelectablePlayers
        {
            get
            {
                return _selectablePlayers;
            }

            set
            {
                _selectablePlayers = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Increments Number of Guesses by 1
        /// </summary>
        public void IncrementNoOfGuesses()
        {
            NoOfGuesses = NoOfGuesses + 1;
        }
    }
}
