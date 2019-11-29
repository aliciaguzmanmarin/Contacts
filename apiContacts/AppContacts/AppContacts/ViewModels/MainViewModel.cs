using AppContacts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppContacts.ViewModels
{
    public class MainViewModel
    {
        #region Properties
        public List<Contacts> listContacts { get; set; }
        #endregion

        #region Singleton 
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        { if (instance==null)
            {
                instance = new MainViewModel();
            } 
            return (instance);
        }
        #endregion

        #region Constructor
        public MainViewModel()
        {
                
        }
        #endregion

        #region ViewModels
        public ContactsViewModel contactsViewModel { get; set; }
        #endregion
    }
}
