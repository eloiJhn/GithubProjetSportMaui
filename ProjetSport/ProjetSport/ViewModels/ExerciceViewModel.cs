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
    public class ExerciceViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));


        private ProgramToExerciceModel _exercice;

		public ProgramToExerciceModel Exercice
		{
			get { return _exercice; }
			set { _exercice = value;
                OnPropertyChanged();
            }
		}

    }
}
