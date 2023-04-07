namespace ProjetSport;

public partial class AppShell : Shell
{
	public readonly int userId;
	public AppShell(int? newUserId)
	{
		if(newUserId is not null)
		{
			userId = (int)newUserId;
		}
		InitializeComponent();
    }
}
