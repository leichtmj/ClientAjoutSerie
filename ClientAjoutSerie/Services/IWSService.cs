using ClientAjoutSerie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAjoutSerie.Services
{
    public interface IWSService
    {
        Task<List<Serie>> GetDevisesAsync(string nomControleur);
    }
}
