using ProjetSport.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TimersTimer = System.Timers.Timer;
using System.Windows.Input;
using System.Timers;

namespace ProjetSport.ViewModels
{
    public class ExerciceViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public IList<ProgramToExerciceModel> AllExercises { get; set; }
        public int CurrentExerciseIndex { get; set; }

        private TimersTimer _timer;
        private TimeSpan _remainingTime;

        public TimeSpan RemainingTime
        {
            get { return _remainingTime;}
            set
            {
                _remainingTime = value;
                OnPropertyChanged();
            }
        }

        private ProgramToExerciceModel _exercice;

		public ProgramToExerciceModel Exercice
		{
			get { return _exercice; }
			set { _exercice = value;
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

        public ICommand NextExerciseCommand { get; }

        public ExerciceViewModel()
        {
            NextExerciseCommand = new Command(ExecuteNextExerciseCommand);

            _timer = new TimersTimer();
            _timer.Interval = 1000;
            _timer.Elapsed += Timer_Elapsed;
        }
        
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (RemainingTime > TimeSpan.Zero)
            {
                RemainingTime = RemainingTime.Subtract(TimeSpan.FromSeconds(1));
            }
            else
            {
                _timer.Stop();
                // Logique à exécuter lorsque le timer arrive à zéro (par exemple, passer automatiquement à l'exercice suivant)
            }
        }


        private void ExecuteNextExerciseCommand()
        {
            if (CurrentExerciseIndex < AllExercises.Count - 1)
            {
                CurrentExerciseIndex++;
                Exercice = AllExercises[CurrentExerciseIndex];
            }
            else
            {
              
              App.Current.MainPage.DisplayAlert("Erreur", "Pas d'exercice suivant", "OK");

            }
        }

    }
}
