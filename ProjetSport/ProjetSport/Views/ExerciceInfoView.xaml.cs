using ProjetSport.ViewModels;

namespace ProjetSport.Views;

public partial class ExerciceInfoView : ContentPage
{
    private ExerciceViewModels viewModel; // déclaration de la vue modèle





    public ExerciceInfoView()
    {
        InitializeComponent();
        viewModel = new ExerciceViewModels(); // initialisation de la vue modèle
        BindingContext = viewModel; // affectation de la vue modèle à la propriété BindingContext de la page
    }

    //protected override void OnAppearing()
    //{
    //    base.OnAppearing();

    //    viewModel.AllExercises = null; // réinitialiser la liste d'exercices
    //    viewModel.CurrentExerciseIndex = 0; // réinitialiser l'index de l'exercice en cours
    //    viewModel.Programs = null; // réinitialiser le programme en cours
    //    viewModel.Exercice = null; // réinitialiser l'exercice en cours
    //    viewModel.OriginalDurations = null; // réinitialiser les durées originales

    //    viewModel.StartTimer(viewModel.Exercice);
    //}
}
