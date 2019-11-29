using AppContacts.Models;
using AppContacts.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace AppContacts.ViewModels
{
    public class ContactsViewModel : BaseViewModel
    {
        #region Attributes
        private ApiService apiService;
        private ObservableCollection<Contacts> contacts;
        #endregion

        #region Properties 
        public ObservableCollection<Contacts> Contacts
        {
            get { return this.Contacts; }
            set { SetValue(ref this.contacts, value); }

        }
        #endregion

        #region Constructor
        public ContactsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadContacts();
        }
        #endregion

        #region Methods
        private async void LoadContacts()
        {
            var connection = await apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Internet Error ",
                    connection.Message,
                    "Accept"
                    );
                return;
            }

            var response = await apiService.GetList<Contacts>(
                "http://localhost:49259",
                "api/",
                "Contacts"
                );

            if (!response.IsSucces)
            {
                await Application.Current.MainPage.DisplayAlert(
                  "Contact service error",
                  response.Message,
                  "Accept"
                  );
                return;
            }

            MainViewModel main = MainViewModel.GetInstance();
            main.listContacts = (List<Contacts>)response.Result;
            this.Contacts = new ObservableCollection<Contacts>(ToContactsCollect());



        }

        private IEnumerable<Contacts> ToContactsCollect()
        {
            ObservableCollection<Contacts> collection = new ObservableCollection<Contacts>;
            MainViewModel main = MainViewModel.GetInstance();
            foreach(var lista in main.listContacts)
            {
                Contacts contact = new Contacts();
                contact.ID = lista.ID;
                contact.Name = lista.Name;
                contact.Bussines = lista.Bussines;
                contact.Phone = lista.Phone;
                collection.Add(contact);
            }
            return (collection);
        }
        #endregion


    }
}