using ProjetSport.Views;

namespace ProjetSport;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AccueilConnectionView();
	}
}
