namespace ProjetSport;

public partial class AppShell : Shell
{
    public static int UserId { get; set; } // Propriété statique pour stocker l'ID de l'utilisateur

    public AppShell()
    {
        InitializeComponent();
    }
}
