using ProjetSport.Models;
using ProjetSport.Services;
using ProjetSport.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjetSport.ViewModels
{
    public class ProgramInfoViewModel : INotifyPropertyChanged
    {
        public ICommand ExoCommand { get; set; }

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

        private ProgramToExerciceModel _selectedExercice;

        public ProgramToExerciceModel SelectedExercice
        {
            get { return _selectedExercice; }
            set { _selectedExercice = value;
                OnPropertyChanged();
            }
        }


        public ProgramInfoViewModel()
        {
            ExoCommand = new Command(execute: () =>
            {
                App.Current.MainPage.Navigation.PushAsync(new ExerciceInfoView() { BindingContext = new ExerciceViewModel { Exercice = SelectedExercice } });
            });
        }
    }
}
