using SteamApp.Models;
using SteamApp.ViewModels;

namespace SteamApp;

public partial class GamesPage : ContentPage
{
    public GamesPage(GamesViewModel vm) 
    { 
        InitializeComponent();
        this.BindingContext = vm;
    }

  
}