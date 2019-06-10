using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHopital.Models.DTO.Traitements
{
    public class Examen_radiologique : Traitement
    {
        private string designation;
        private string resultat_examen;
        private string image;

        public Examen_radiologique()
        {
        }

        public Examen_radiologique(DateTime date_examen, decimal prix_examen, string designation, string resultat_examen, string image)
        {
            Date_traitement = date_examen;
            Prix_traitement = prix_examen;
            this.designation = designation;
            this.resultat_examen = resultat_examen;
            this.image = image;
        }

        public string Designation { get => designation; set => designation = value; }
        public string Resultat_examen { get => resultat_examen; set => resultat_examen = value; }
        public string Image { get => image; set => image = value; }


        public override bool CheckData()
        {
            return (image == null || image == "" || designation == null || designation == "" || Date_traitement == null || Prix_traitement < 0) ? false : true;
        }

        public override string ToString()
        {
            return base.ToString() + "\nExamen Radiologique (designation:" + designation + "resultat examen:" + resultat_examen + "image:" + image + ")";
        }
    }
}
