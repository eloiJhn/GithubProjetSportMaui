using ProjetSport.Models;
using ProjetSport.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjetSport.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public ICommand connectionCommand { get; set; }
        public ICommand authentCommand { get; set; }

        private string _identifiant;

        public string Identifiant
        {
            get { return _identifiant; }
            set { _identifiant = value;
                OnPropertyChanged();
            }
        }

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value;
                OnPropertyChanged();
            }
        }


        public UserViewModel()
        {
            connectionCommand = new Command(() => {
                bool isOk = Services.UserService.VerifConnection(_identifiant, _password);

                if (isOk == true)
                {
                    App.Current.MainPage = new ProgramView();
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Erreur", "Mauvais Login", "X");
                }
            });

            authentCommand = new Command(() =>
            {
                Services.UserService.PostEleveAuth(_firstName, _lastName, _password, _identifiant);
            });
        }
    }
}
