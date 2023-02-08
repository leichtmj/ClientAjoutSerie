using ClientAjoutSerie.Models;
using ClientAjoutSerie.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientAjoutSerie.ViewModels
{
    public class SerieViewModel : ObservableObject, ISerieViewModel
    {

        private Serie serietoAdd;

        private WSService service;


        public SerieViewModel()
        {
            service = new WSService("https://apiseriesleichtmj.azurewebsites.net/api/");
            GetDataOnLoadAsync();
            BtnSetConversion = new RelayCommand(ActionSetConversion);
            SerietoAdd = new Serie();
        }

        public IRelayCommand BtnSetConversion { get; }


        public Serie SerietoAdd
        {
            get
            {
                return serietoAdd;
            }

            set
            {
                serietoAdd = value;
                OnPropertyChanged();
            }
        }

        public async void ActionSetConversion()
        {
            if (SerietoAdd.Nbsaisons==0 || SerietoAdd.Nbepisodes==0 || SerietoAdd.Network==null 
                || SerietoAdd.Anneecreation==0 || SerietoAdd.Titre==null || SerietoAdd.Resume==null)
                DisplayshowAsync("Erreur", "Veuillez remplir tout les champs");
            else
            {
                var verif = await service.PostSerieAsync(SerietoAdd);
                DisplayshowAsync("Information", "Série ajoutée avec succès !");
            }
        }


        public async void GetDataOnLoadAsync()
        {
            List<Serie> result = await service.GetSeriesAsync("series");
            if (result == null)
            {
                DisplayshowAsync("Erreur", "API non disponible");
            }
            else {
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
    }
}
