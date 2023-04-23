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
    class UserInfoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        public ICommand HistoriqueExerciceCommand { get; set; }

        private int _identifiant;

		public int Identifiant
		{
			get { return _identifiant; }
			set { _identifiant = value;
				OnPropertyChanged();
			}
		}

		private UserModel _user;

		public UserModel User
		{
			get { return _user; }
			set { _user = value;
				OnPropertyChanged();
			}
		}

		private List<ActiviteModel> _historique;

		public List<ActiviteModel> Historique
		{
			get { return _historique; }
			set { _historique = value;
				OnPropertyChanged();
			}
		}

		private ActiviteModel _selectedProgramActivity;

		public ActiviteModel SelectedProgramActivity
        {
			get { return _selectedProgramActivity; }
			set { _selectedProgramActivity = value; 
				OnPropertyChanged();
			}
		}

		public UserInfoViewModel()
		{
			HistoriqueExerciceCommand = new Command(() =>
            {
                App.Current.MainPage.Navigation.PushAsync(new ExerciceActivitiesView() { BindingContext = new ActiviteExerciceViewModel { SelectedProgramActivity = Services.ActiviteService.GetActivitesByUserByProgram(_identifiant, _selectedProgramActivity.Name, _selectedProgramActivity.Date), Avancee = Services.ActiviteService.AvanceProgram(_identifiant, _selectedProgramActivity.Name, _selectedProgramActivity.Date), NbCaloriePerdu = Services.ActiviteService.CaloriePerdu(_identifiant, _selectedProgramActivity.Name, _selectedProgramActivity.Date), NbCalorieAPerdre = Services.ActiviteService.CalorieAPerdre(_identifiant, _selectedProgramActivity.Name, _selectedProgramActivity.Date) } });
			});

        }
	}
}
