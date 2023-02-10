using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientAjoutSerie.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientAjoutSerie.Services;
using ClientAjoutSerie.Models;

namespace ClientAjoutSerie.ViewModels.Tests
{
    [TestClass()]
    public class SRUDViewModelTests
    {
        private SRUDViewModel SRUDViewModel;
        private static WSService service;

        public SRUDViewModelTests()
        {
            service = new WSService("https://apiseriesleichtmj.azurewebsites.net/api/");
            SRUDViewModel = new SRUDViewModel();
        }

        [TestMethod()]
        public void SRUDViewModelTest()
        {

        }

        [TestMethod()]
        public void ActionSetSearchTest()
        {

            Serie serie = new Serie(1236, "Scrubs", "J.D. est un jeune médecin qui débute sa carrière dans l'hôpital du Sacré-Coeur. Il vit avec son meilleur ami Turk, qui lui est chirurgien dans le même hôpital. Très vite, Turk tombe amoureux d'une infirmière Carla. Elliot entre dans la bande. C'est une étudiante en médecine quelque peu surprenante. Le service de médecine est dirigé par l'excentrique Docteur Cox alors que l'hôpital est géré par le diabolique Docteur Kelso. A cela viennent s'ajouter plein de personnages hors du commun : Todd le chirurgien obsédé, Ted l'avocat dépressif, le concierge qui trouve toujours un moyen d'embêter JD... Une belle galerie de personnage !", 9, 184, 2001, "ABC (US)");
            _ = service.PostSerieAsync(serie);
            Thread.Sleep(1000);


            SRUDViewModel.Idsearch = serie.Serieid;
            SRUDViewModel.ActionSetSearch();
            Serie get = SRUDViewModel.Serie;

            Assert.AreEqual(serie, get);

            _ = service.DeleteSerieAsync(serie);
        }

        [TestMethod()]
        public void ActionSetModifTest()
        {

        }

        [TestMethod()]
        public void ActionSetDeleteTest()
        {

        }

        [TestMethod()]
        public void GetDataOnLoadAsyncTest()
        {
        }

    }
}