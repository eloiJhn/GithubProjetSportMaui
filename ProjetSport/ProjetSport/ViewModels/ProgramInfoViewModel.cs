using ProjetSport.Models;
using ProjetSport.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSport.ViewModels
{
    public class ProgramInfoViewModel : INotifyPropertyChanged
    {
        private ProgramModel _program;

        public ProgramModel Program
        {
            get { return _program; }
            set { _program = value; }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        
        private ObservableCollection<ProgramToExerciceModel> _listExercice;
        public ObservableCollection<ProgramToExerciceModel> ListExercice
        {
            get { return _listExercice; }
            set {
                _listExercice = value;
                OnPropertyChanged();
            }
        }


        public ProgramInfoViewModel()
        {
        }
    }
}
