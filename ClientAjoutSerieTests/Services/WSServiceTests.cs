using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientAjoutSerie.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientAjoutSerie.Models;
using ClientAjoutSerie.ViewModels;

namespace ClientAjoutSerie.Services.Tests
{
    [TestClass()]
    public class WSServiceTests
    {

        private static WSService service;

        public WSServiceTests()
        {
            service = new WSService("https://apiseriesleichtmj.azurewebsites.net/api/");

        }

        [TestMethod()]
        public void WSServiceTest()
        {
        }

        [TestMethod()]
        public void GetSeriesAsyncTest()
        {


            List<Serie> listdevises = new List<Serie>();
            listdevises.AddRange(new List<Serie>
            {
                new Serie(1, "Scrubs"  ,  "J.D. est un jeune médecin qui débute sa carrière dans l'hôpital du Sacré-Coeur. Il vit avec son meilleur ami Turk, qui lui est chirurgien dans le même hôpital. Très vite, Turk tombe amoureux d'une infirmière Carla. Elliot entre dans la bande. C'est une étudiante en médecine quelque peu surprenante. Le service de médecine est dirigé par l'excentrique Docteur Cox alors que l'hôpital est géré par le diabolique Docteur Kelso. A cela viennent s'ajouter plein de personnages hors du commun : Todd le chirurgien obsédé, Ted l'avocat dépressif, le concierge qui trouve toujours un moyen d'embêter JD... Une belle galerie de personnage !",  9  , 184 ,2001  ,  "ABC (US)"),
                new Serie(2 ,"James May's 20th Century",  "The world in 1999 would have been unrecognisable to anyone from 1900. James May takes a look at some of the greatest developments of the 20th century, and reveals how they shaped the times we live in now." , 1 ,  6 ,  2007  ,  "BBC Two"),
                new Serie(3 ,"True Blood"  ,  "Ayant trouvé un substitut pour se nourrir sans tuer (du sang synthétique), les vampires vivent désormais parmi les humains. Sookie, une serveuse capable de lire dans les esprits, tombe sous le charme de Bill, un mystérieux vampire. Une rencontre qui bouleverse la vie de la jeune femme..." , 7  , 81 , 2008  ,  "HBO")
            });

            var getserie = service.GetSeriesAsync("series").Result;

            getserie = getserie.Where(s => s.Serieid <= 3).ToList();
            CollectionAssert.AreEqual(listdevises, getserie);

            Assert.IsNotNull(getserie);
        }

        [TestMethod()]
        public void GetSeriesByIdAsyncTest()
        {


            Serie serie = new Serie(1, "Scrubs", "J.D. est un jeune médecin qui débute sa carrière dans l'hôpital du Sacré-Coeur. Il vit avec son meilleur ami Turk, qui lui est chirurgien dans le même hôpital. Très vite, Turk tombe amoureux d'une infirmière Carla. Elliot entre dans la bande. C'est une étudiante en médecine quelque peu surprenante. Le service de médecine est dirigé par l'excentrique Docteur Cox alors que l'hôpital est géré par le diabolique Docteur Kelso. A cela viennent s'ajouter plein de personnages hors du commun : Todd le chirurgien obsédé, Ted l'avocat dépressif, le concierge qui trouve toujours un moyen d'embêter JD... Une belle galerie de personnage !", 9, 184, 2001, "ABC (US)");


            var getserie = service.GetSeriesByIdAsync(1).Result;

            Assert.AreEqual(serie, getserie);

            Assert.IsNotNull(getserie);
        }


        [TestMethod()]
        public void PostSeriesAsyncTest()
        {


            Serie serie = new Serie(1234, "Scrubs", "J.D. est un jeune médecin qui débute sa carrière dans l'hôpital du Sacré-Coeur. Il vit avec son meilleur ami Turk, qui lui est chirurgien dans le même hôpital. Très vite, Turk tombe amoureux d'une infirmière Carla. Elliot entre dans la bande. C'est une étudiante en médecine quelque peu surprenante. Le service de médecine est dirigé par l'excentrique Docteur Cox alors que l'hôpital est géré par le diabolique Docteur Kelso. A cela viennent s'ajouter plein de personnages hors du commun : Todd le chirurgien obsédé, Ted l'avocat dépressif, le concierge qui trouve toujours un moyen d'embêter JD... Une belle galerie de personnage !", 9, 184, 2001, "ABC (US)");


            var getserie = service.PostSerieAsync(serie).Result;

            Assert.IsTrue(getserie);
        }
    }
}