using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty] string steamUser;

        [RelayCommand]
        public async Task Login()
        {
            string id = await SteamData.GetSteamUser(SteamUser);
            if (id != null)
            {
                //SQLite
                await Shell.Current.GoToAsync($"GamesPage?id={id}");
            }
            else
            {
                await Shell.Current.DisplayAlert("Hiba!", "Nem található a megadott névvel felhasználó!", "Ok");
            }
        }
    }
}
