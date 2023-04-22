namespace ProjetSport.Views;

public partial class ExerciceActivitiesView : ContentPage
{
	public ExerciceActivitiesView()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        CollectionView.IsVisible = true;
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        CollectionView.IsVisible = false;
    }
}