namespace ProjetSport.Views;

public partial class ExerciceActivitiesView : ContentPage
{
	public ExerciceActivitiesView()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        CollectionView.IsVisible = true;
        await CollectionView.FadeTo(1, 1000, Easing.CubicIn);
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await CollectionView.FadeTo(0, 1000, Easing.CubicIn);
        CollectionView.IsVisible = false;
    }
}