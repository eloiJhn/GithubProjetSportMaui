using ProjetSport.ViewModels;

namespace ProjetSport.Views;

public partial class ExerciceInfoView : ContentPage
{
    private ExerciceViewModels viewModel; // d�claration de la vue mod�le





    public ExerciceInfoView()
    {
        InitializeComponent();
        viewModel = new ExerciceViewModels(); // initialisation de la vue mod�le
        BindingContext = viewModel; // affectation de la vue mod�le � la propri�t� BindingContext de la page
    }

    //protected override void OnAppearing()
    //{
    //    base.OnAppearing();

    //    viewModel.AllExercises = null; // r�initialiser la liste d'exercices
    //    viewModel.CurrentExerciseIndex = 0; // r�initialiser l'index de l'exercice en cours
    //    viewModel.Programs = null; // r�initialiser le programme en cours
    //    viewModel.Exercice = null; // r�initialiser l'exercice en cours
    //    viewModel.OriginalDurations = null; // r�initialiser les dur�es originales

    //    viewModel.StartTimer(viewModel.Exercice);
    //}
}
