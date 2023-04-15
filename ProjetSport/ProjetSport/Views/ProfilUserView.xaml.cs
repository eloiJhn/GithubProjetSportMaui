namespace ProjetSport.Views;

public partial class ProfilUserView : ContentPage
{
	public ProfilUserView()
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