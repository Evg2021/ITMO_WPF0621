using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2_MVVM.Model;
using System.Windows;
using System.Windows.Input;


namespace Lab2_MVVM.ViewModel
{
    class MainViewModel
    {
        #region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
        public MainViewModel()
        {
            People = new PeopleModel
             {

                FirstName = "First name",
                LastName = "Last name"
             };
        }
        #endregion
        #region Properties
        /// <summary>
        /// Get or set people.
        /// </summary>
        public PeopleModel People { get; set; }
        #endregion
        #region Methods
        /// <summary>
        /// Click method.
        /// </summary>
        private void ClickMethod()
        {
            //MessageBox.Show("Сlick command");
            //ClickCommand = new Command(arg => ClickMethod());
            MessageBox.Show("Person - " + People.FirstName + " " + People.LastName);


        }
        #endregion
        #region Commands
        /// <summary>
        /// Get or set ClickCommand.
        /// </summary>
        public ICommand ClickCommand { get; set; }
        #endregion


    }
}
