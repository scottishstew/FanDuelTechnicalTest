using System;
using System.Collections.Generic;
using System.Text;

namespace FanDuelTest.Core.ViewModels
{
    public class ViewModelLocator
    {
        private static MainViewModel _main;

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            if (_main == null)
            {
                _main = new MainViewModel();
            }
        }

        /// <summary>
        /// Gets the Main property which defines the main viewmodel.
        /// </summary>
        public MainViewModel ViewModel
        {
            get
            {
                return _main;
            }
        }
    }
}
