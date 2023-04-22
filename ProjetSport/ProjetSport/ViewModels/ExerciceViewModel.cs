using Microsoft.Maui.Controls.PlatformConfiguration;
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
using System.Timers;
using System.Windows.Input;
using TimersTimer = System.Timers.Timer;
namespace ProjetSport.ViewModels
{
    public class ExerciceViewModels : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        public IList<ProgramToExerciceModel> AllExercises { get; set; }
        public int CurrentExerciseIndex { get; set; }

        private TimersTimer _timer;

        private TimeSpan _timeElapsed;
        public TimeSpan TimeElapsed
        {
            get { return _timeElapsed; }
            set
            {
                _timeElapsed = value;
                OnPropertyChanged();
            }
        }
        private ProgramToExerciceModel _programs;

        public ProgramToExerciceModel Programs
        {
            get { return _programs; }
            set
            {
                _programs = value;
                OnPropertyChanged();
            }
        }

        private ProgramToExerciceModel _exercice;

        public ProgramToExerciceModel Exercice
        {
            get { return _exercice; }
            set
            {
                _exercice = value;
                OnPropertyChanged();
            }
        }



        private bool _isNextButtonVisible;
        public bool IsNextButtonVisible
        {
            get { return _isNextButtonVisible; }
            set
            {
                _isNextButtonVisible = value;
                OnPropertyChanged(nameof(IsNextButtonVisible));
            }
        }

        private int _userId;

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        private int _idProgram;

        public int IdProgram
        {
            get { return _idProgram; }
            set { _idProgram = value; }
        }

        private int _idExercice;

        public int IdExercice
        {
            get { return _idExercice; }
            set { _idExercice = value; }
        }


        public ICommand NextExerciseCommand { get; }

        public ICommand StopProgram { get; }


        public Dictionary<int, TimeSpan> OriginalDurations { get; set; }

        public int ProgramId { get; set; }


        public ExerciceViewModels()
        {
            NextExerciseCommand = new Command(ExecuteNextExerciseCommand);
            StopProgram = new Command(ExecuteStopProgram);


            OriginalDurations = new Dictionary<int, TimeSpan>();


            _timer = new TimersTimer();
            _timer.Interval = 1000;
            _timer.Elapsed += Timer_Elapsed;

            
            IsNextButtonEnabled = true;
        


            LoadExercises();
        }

        private async void ExecuteStopProgram()
        {
            // Arrêter le timer
            _timer.Stop();

            // Réinitialiser les durées originales des exercices
            OriginalDurations.Clear();

            // Retirer la page actuelle de la pile de navigation
            await App.Current.MainPage.Navigation.PushAsync(new ProgramView());


            // Recharger les exercices
            LoadExercises();

            // Réinitialiser les boutons
            IsNextButtonVisible = false;
            IsNextButtonEnabled = true;

            _timer.Start();

        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
        _timer.Start();
          
                TimeElapsed = TimeElapsed.Add(TimeSpan.FromSeconds(1));
                OnPropertyChanged(nameof(TimeElapsed));

        }
        public void StartTimer(ProgramToExerciceModel program, int idProgram)
        {
       
            //UserId = userId;
            IdProgram = idProgram;
            Programs = program;

            if (CurrentExerciseIndex == 0)
            {
                Exercice = Programs;
                _timer.Enabled = true;


            }
        }


        private void LoadExercises()
        {
            AllExercises = new List<ProgramToExerciceModel>();

            for (int i = 0; i < AllExercises.Count; i++)
            {
                OriginalDurations.Add(i, AllExercises[i].TimeExercice);
            }
        }

        private bool _isNextButtonEnabled;
        public bool IsNextButtonEnabled
        {
            get { return _isNextButtonEnabled; }
            set
            {
                _isNextButtonEnabled = value;
                OnPropertyChanged(nameof(IsNextButtonEnabled));
            }
        }




        private async  void ExecuteNextExerciseCommand()
        {
            IsNextButtonEnabled = false;

            await Task.Delay(TimeSpan.FromSeconds(2)); // Attente de 2 secondes avant de réactiver le bouton

            _timer.Stop();

            //TimeSpan timeSpent = TimeElapsed;



            IdExercice = Exercice.IdExercice; // mettre à jour l'id de l'exercice en cours
            

            Services.ActiviteService.PostUserActivite(IdProgram, IdExercice, TimeElapsed);

            TimeElapsed = TimeSpan.Zero;


            if (CurrentExerciseIndex < AllExercises.Count - 1)
            {
                CurrentExerciseIndex++;
                Exercice = AllExercises[CurrentExerciseIndex];





                _timer.Start();
            }
            else
            {
               await App.Current.MainPage.DisplayAlert("Fin des exercices", "Vous avez terminé tous les exercices !", "OK");
                await App.Current.MainPage.Navigation.PushAsync(new ProgramView());


                _timer.Stop();
            }

            IsNextButtonEnabled = true;

        }



    }
}