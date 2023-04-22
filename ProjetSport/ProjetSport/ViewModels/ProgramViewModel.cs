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
    public class ProgramViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public ICommand NavigateTo { get; set; }

        private ObservableCollection<ProgramModel> _listPrograms;
        public ObservableCollection<ProgramModel> ListPrograms
        {
            get { return _listPrograms; }
            set
            {
                _listPrograms = value;
                OnPropertyChanged();
            }
        }

        private ProgramModel _selectedProgram;

        public ProgramModel SelectedProgram
        {
            get { return _selectedProgram; }
            set { _selectedProgram = value; }
        }

        public ProgramViewModel()
        {
            _listPrograms = ProgramService.GetPrograms();

            NavigateTo = new Command(execute: () => {
                App.Current.MainPage.Navigation.PushAsync(new ProgramInfoView() { BindingContext = new ProgramInfoViewModel() { Program = SelectedProgram, ListExercice = ProgramService.GetExercicesIntoProgram(SelectedProgram.Id) } });
            });
        }


    }
}
