using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAjoutSerie.ViewModels
{
    public interface ISRUDViewModel
    {
        void ActionSetSearch();
        void GetDataOnLoadAsync();
        void DisplayshowAsync(string title, string desc);
    }
}
