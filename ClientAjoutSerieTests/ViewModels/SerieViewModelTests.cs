using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientAjoutSerie.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientAjoutSerie.Models;
using ClientAjoutSerie.Services;

namespace ClientAjoutSerie.ViewModels.Tests
{
    [TestClass()]
    public class SerieViewModelTests
    {
        private SerieViewModel SerieViewModel;
        private static WSService service;


        public SerieViewModelTests()
        {
            service = new WSService("https://apiseriesleichtmj.azurewebsites.net/api/");
            SerieViewModel = new SerieViewModel();
        }

        [TestMethod()]
        public void ActionSetConversionTest()
        {
            Serie serie = new Serie(1238, "Scrubs", "J.D. est un jeune médecin qui débute sa carrière dans l'hôpital du Sacré-Coeur. Il vit avec son meilleur ami Turk, qui lui est chirurgien dans le même hôpital. Très vite, Turk tombe amoureux d'une infirmière Carla. Elliot entre dans la bande. C'est une étudiante en médecine quelque peu surprenante. Le service de médecine est dirigé par l'excentrique Docteur Cox alors que l'hôpital est géré par le diabolique Docteur Kelso. A cela viennent s'ajouter plein de personnages hors du commun : Todd le chirurgien obsédé, Ted l'avocat dépressif, le concierge qui trouve toujours un moyen d'embêter JD... Une belle galerie de personnage !", 9, 184, 2001, "ABC (US)");

            SerieViewModel.SerietoAdd = serie;
            SerieViewModel.ActionSetConversion();
            Thread.Sleep(1000);

            Serie get = service.GetSeriesByIdAsync(serie.Serieid).Result;

            Assert.AreEqual(serie, get);

            _ = service.DeleteSerieAsync(serie);
        }

    }
}