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
using System.Threading.Tasks;

namespace ClientAjoutSerie.ViewModels
{
    public class SerieViewModel : ObservableObject, ISerieViewModel
    {

        private Serie serietoAdd;

        public static WSService service = new WSService("https://apiseriesleichtmj.azurewebsites.net/api/");

        public SerieViewModel()
        {
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
            }
        }

        public virtual void ActionSetConversion()
        {
            DisplayshowAsync("Reussi", $"{SerietoAdd.Titre}");
        }


        public async void GetDataOnLoadAsync()
        {
            List<Serie> result = await service.GetSeriesAsync("series");
            if (result == null)
            {
                DisplayshowAsync("Erreur", "API non disponible");
            }
            else { }
                //LesDevises = new ObservableCollection<Serie>(result);
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
