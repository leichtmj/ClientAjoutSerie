using ClientAjoutSerie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ClientAjoutSerie.Services
{
    public class WSService
    {
        HttpClient client = new HttpClient();

        public WSService(string url)
        {
            //pour accéder à l'API REST
            client.BaseAddress = new Uri(url); //L’adresse à indiquer devra être celle de votre API, construite de la façon suivante: https://localhost:PORT/api/
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Serie>> GetSeriesAsync(string nomControleur)
        {
            try
            {
                return await client.GetFromJsonAsync<List<Serie>>(nomControleur);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Serie> GetSeriesByIdAsync(int id)
        {
            try
            {
                return await client.GetFromJsonAsync<Serie>(string.Concat(client.BaseAddress, $"series/{id}"));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> PostSerieAsync(Serie s)
        {
            try
            {
                var response = await client.PostAsJsonAsync("series", s);
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteSerieAsync(Serie s)
        {
            try
            {
                var response = await client.DeleteAsync(string.Concat(client.BaseAddress, $"/series/{s.Serieid}"));
                return response.EnsureSuccessStatusCode().IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public async Task<bool> PutSerieAsync(Serie s)
        {
            try
            {
                var response = await client.PutAsJsonAsync(string.Concat(client.BaseAddress, $"/series/{s.Serieid}"),s);
                return response.EnsureSuccessStatusCode().IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
