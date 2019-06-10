using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHopital.Models.DTO.Traitements
{
    public class Chirurgie : Traitement
    {
        private string chirurgien;
        private string anesthesiste;

        public Chirurgie()
        {
        }

        public Chirurgie(DateTime date_chirurgien, decimal prix_chirurgie, string chirurgien, string anesthesiste)
        {
            Date_traitement = date_chirurgien;
            Prix_traitement = prix_chirurgie;
            this.chirurgien = chirurgien;
            this.anesthesiste = anesthesiste;
        }

        public string Chirurgien { get => chirurgien; set => chirurgien = value; }
        public string Anesthesiste { get => anesthesiste; set => anesthesiste = value; }

        public override bool CheckData()
        {
            return (chirurgien == null || chirurgien == "" || date_traitement == null || Prix_traitement < 0) ? false : true;
        }

        public override string ToString()
        {
            return base.ToString()+"\nChirurgie (chirurgien: " + chirurgien + ", anesthesiste: " + anesthesiste + ")";
        }
    }
}
