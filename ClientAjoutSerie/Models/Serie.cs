using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAjoutSerie.Models
{
    public class Serie
    {
        private int serieid;
        private string titre;
        private string resume;
        private int nbsaisons;
        private int nbepisodes;
        private int anneecreation;
        private string network;

        public Serie()
        {
        }

        public Serie(int serieid, string titre, string resume, int nbsaisons, int nbepisodes, int anneecreation, string network)
        {
            this.Serieid = serieid;
            this.Titre = titre;
            this.Resume = resume;
            this.Nbsaisons = nbsaisons;
            this.Nbepisodes = nbepisodes;
            this.Anneecreation = anneecreation;
            this.Network = network;
        }

        public int Serieid
        {
            get
            {
                return serieid;
            }

            set
            {
                serieid = value;
            }
        }

        public string Titre
        {
            get
            {
                return titre;
            }

            set
            {
                titre = value;
            }
        }

        public string Resume
        {
            get
            {
                return resume;
            }

            set
            {
                resume = value;
            }
        }

        public int Nbsaisons
        {
            get
            {
                return nbsaisons;
            }

            set
            {
                nbsaisons = value;
            }
        }

        public int Nbepisodes
        {
            get
            {
                return nbepisodes;
            }

            set
            {
                nbepisodes = value;
            }
        }

        public int Anneecreation
        {
            get
            {
                return anneecreation;
            }

            set
            {
                anneecreation = value;
            }
        }

        public string Network
        {
            get
            {
                return network;
            }

            set
            {
                network = value;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Serie serie &&
                   this.Serieid == serie.Serieid &&
                   this.Titre == serie.Titre &&
                   this.Resume == serie.Resume &&
                   this.Nbsaisons == serie.Nbsaisons &&
                   this.Nbepisodes == serie.Nbepisodes &&
                   this.Anneecreation == serie.Anneecreation &&
                   this.Network == serie.Network;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Serieid, this.Titre, this.Resume, this.Nbsaisons, this.Nbepisodes, this.Anneecreation, this.Network);
        }
    }
}
