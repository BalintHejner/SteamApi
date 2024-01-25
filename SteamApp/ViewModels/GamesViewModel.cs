using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamApp.Models;
using CommunityToolkit.Mvvm.Input;

namespace SteamApp.ViewModels
{
    [QueryProperty(nameof(ID), "id")]

    public partial class GamesViewModel : ObservableObject
    {
        [ObservableProperty] string iD;
        [ObservableProperty] private List<Game> games;
        [ObservableProperty] double sum_of_playtime;  /*=> games.Sum(x => x.playtime_forever_hours);*/
        [ObservableProperty] Game selectedGame;

        [RelayCommand]
        private async Task NavigateToDetails()
        {
            if (SelectedGame != null)
            {
                Dictionary<string, object> navParameter = new Dictionary<string, object>()
                {
                    {"SelectedGame", SelectedGame}
                };
                await Shell.Current.GoToAsync($"{nameof(GameDetailsPage)}", true, navParameter);
            } else
            {
                await Shell.Current.DisplayAlert("Hiba!", "A kiválasztott játékok adatai nem jeleníthetőek meg!", "OK");
            }
        }

        partial void OnIDChanged(string value)
        {
            Games = SteamData.GetUsersGames(ID).Result;
        }

        partial void OnGamesChanged(List<Game> value)
        {
            Sum_of_playtime = Games.Sum(x => x.playtime_forever_hours);
        }

        async partial void OnSelectedGameChanged(Game value)
        {
            await NavigateToDetails();
        }
    }
}
