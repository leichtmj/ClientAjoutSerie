using ClientAjoutSerie.Models;
using ClientAjoutSerie.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAjoutSerie.ViewModels
{
    public class SRUDViewModel : ObservableObject, ISRUDViewModel
    {

        private Serie serie;
        private int idsearch;

        private WSService service;

        public IRelayCommand BtnSetSearch { get; }

        public IRelayCommand BtnSetModif { get; }

        public IRelayCommand BtnSetDelete { get; }

        public SRUDViewModel()
        {
            service = new WSService("https://apiseriesleichtmj.azurewebsites.net/api/");
            GetDataOnLoadAsync();
            BtnSetSearch = new RelayCommand(ActionSetSearch);
            BtnSetModif = new RelayCommand(ActionSetModif);
            BtnSetDelete = new RelayCommand(ActionSetDelete);
            Serie = new Serie();
        }



        public Serie Serie
        {
            get
            {
                return serie;
            }

            set
            {
                serie = value;
                OnPropertyChanged();
            }
        }

        public int Idsearch
        {
            get
            {
                return idsearch;
            }

            set
            {
                idsearch = value;
                OnPropertyChanged();
            }
        }

        public async void ActionSetSearch()
        {
            Serie = await service.GetSeriesByIdAsync(Idsearch);
            DisplayshowAsync("Information", "Opération effectuée avec succès");
        }

        public async void ActionSetModif()
        {
            await service.PutSerieAsync(Serie);
            DisplayshowAsync("Information", "Opération effectuée avec succès");

        }

        public void ActionSetDelete()
        {
            SuppDialogAsync();
        }

        public async void GetDataOnLoadAsync()
        {
            List<Serie> result = await service.GetSeriesAsync("series");
            if (result == null)
            {
                DisplayshowAsync("Erreur", "API non disponible");
            }
            else
            {
                DisplayshowAsync("test", result[0].ToString());
            }

        }

        public async void DisplayshowAsync(string title, string desc)
        {
            ContentDialog contentDialog = new ContentDialog
            {
                Title = title,
                Content = desc,
                PrimaryButtonText = "Ok"
            };
            contentDialog.XamlRoot = App.MainRoot.XamlRoot;
            ContentDialogResult result = await contentDialog.ShowAsync();
        }


        public async void SuppDialogAsync()
        {
            ContentDialog contentDialog = new ContentDialog
            {
                Title = "Attention",
                Content = "Êtes-vous sûr de vouloir supprimer cette série ?",
                PrimaryButtonText = "Confirmer",
                CloseButtonText ="Annuler"
            };
            contentDialog.XamlRoot = App.MainRoot.XamlRoot;
            ContentDialogResult result = await contentDialog.ShowAsync();

            if(result == ContentDialogResult.Primary)
            {
                await service.DeleteSerieAsync(Serie);
            }
            else
            {

            }
        }
    }
}
