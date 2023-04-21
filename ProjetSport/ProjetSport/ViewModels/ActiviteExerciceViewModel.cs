using ProjetSport.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSport.ViewModels
{
    class ActiviteExerciceViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private List<ActiviteModel> _selectedProgramActivity;

		public List<ActiviteModel> SelectedProgramActivity
        {
			get { return _selectedProgramActivity; }
			set { _selectedProgramActivity = value;
				OnPropertyChanged();
			}
		}

		private int _avancee;

		public int Avancee
        {
			get { return _avancee; }
			set { _avancee = value;
				OnPropertyChanged();
			}
		}

		private int _nbCaloriePerdu;

		public int NbCaloriePerdu
        {
			get { return _nbCaloriePerdu; }
			set { _nbCaloriePerdu = value;
				OnPropertyChanged();
			}
		}

		private int _nbCalorieAPerdre;

		public int NbCalorieAPerdre
        {
			get { return _nbCalorieAPerdre; }
			set { _nbCalorieAPerdre = value; }
		}




	}
}
