using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHopital.Models.DTO.Traitements
{
    public class Examen_biologique : Traitement
    {
        private string designation;
        private string resultat_examen;

        public Examen_biologique()
        {
        }

        public Examen_biologique(DateTime date_examen, decimal prix_examen, string designation, string resultat_examen)
        {
            Date_traitement = date_examen;
            Prix_traitement = prix_examen;
            this.designation = designation;
            this.resultat_examen = resultat_examen;
        }

        public string Designation { get => designation; set => designation = value; }
        public string Resultat_examen { get => resultat_examen; set => resultat_examen = value; }

        public override bool CheckData()
        {
            return (designation == null || designation == "" || date_traitement == null || prix_traitement < 0) ? false : true;
        }

        public override string ToString()
        {
            return base.ToString() + "\nExamen Biologique (designation:" + designation + "resultat examen:" + resultat_examen + ")";
        }
    }
}
