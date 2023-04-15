using ProjetSport.Models;
using ProjetSport.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
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

        public ICommand navigateToProfil { get; set; }

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
            set { _firstName = value;
                OnPropertyChanged();
            }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value;
                OnPropertyChanged();
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set{ _password = value;
                OnPropertyChanged();
            }
        }

        public static byte[] HashPassword(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            return SHA256.HashData(passwordBytes);
        }

        public UserViewModel()
        {
            connectionCommand = new Command(() =>
            {
                if (_identifiant is null || _password is null)
                {
                    App.Current.MainPage.DisplayAlert("Erreur", "Veuillez remplir les 2 champs", "X");
                }
                else
                {
                    if (Services.UserService.VerifConnection(_identifiant, _password))
                    {
                        int userId = Services.UserService.GetStudentId(_identifiant);
                        
                        App.Current.MainPage = new AppShell(userId);
                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("Erreur", "Mauvais Login", "X");
                    }
                }
            });

            authentCommand = new Command(() =>
            {
                if (_firstName is null || _lastName is null || _password is null || _identifiant is null)
                {
                    App.Current.MainPage.DisplayAlert("Erreur", "Remplir l'ensemble des critères", "X");
                }
                else
                {
                    Services.UserService.PostEleveAuth(_firstName, _lastName, _password, _identifiant);
                }
            });

            navigateToProfil = new Command(() =>
            {
                int userId = Services.UserService.GetStudentId(_identifiant);
                App.Current.MainPage.Navigation.PushAsync(new ProfilUserView() { BindingContext = new UserInfoViewModel { Identifiant = userId }});
            });
        }
    }
}
