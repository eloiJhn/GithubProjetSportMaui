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

        public ICommand PlayCommand { get; set; }

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
            set
            {
                _listExercice = value;
                OnPropertyChanged();
            }
        }

        private ProgramToExerciceModel _selectedExercice;

        public ProgramToExerciceModel SelectedExercice
        {
            get { return _selectedExercice; }
            set
            {
                _selectedExercice = value;
                OnPropertyChanged();
            }
        }

        public ProgramInfoViewModel()
        {
            ExoCommand = new Command(execute: () =>
            {
                App.Current.MainPage.Navigation.PushAsync(new ExerciceInfoView() { BindingContext = new ExerciceViewModels() { Exercice = SelectedExercice } });
            });

            PlayCommand = new Command(execute: async () => await StartProgramAsync());
        }

        private async Task StartProgramAsync()
        {
            // Récupérer l'idProgram
            int idProgram = Program.Id;

            // Ajouter l'activité et récupérer le premier exercice
            ProgramToExerciceModel firstExercise = ListExercice.FirstOrDefault();
            if (firstExercise != null)
            {
                await ActiviteService.AddActivityAsync(17, idProgram); // Remplacez "1" par l'UserId réel

                // Naviguer vers la première vue d'exercice avec le timer et le bouton pour terminer l'exercice
                var exerciseViewModel = new ExerciceViewModels()
                {
                    IdProgram = idProgram,
                    Exercice = firstExercise,
                    AllExercises = ListExercice,
                    CurrentExerciseIndex = 0,
                    IsNextButtonVisible = true
                };
                exerciseViewModel.StartTimer(firstExercise, idProgram);




                // Naviguer vers la première vue d'exercice avec le timer et le bouton pour terminer l'exercice
                await App.Current.MainPage.Navigation.PushAsync(new ExerciceInfoView() { BindingContext = exerciseViewModel });
            }
            else
            {
                // Gérer l'absence d'exercices dans la liste
                await App.Current.MainPage.DisplayAlert("Erreur", "Aucun exercice trouvé pour ce programme.", "OK");
            }
        }
    }
}
