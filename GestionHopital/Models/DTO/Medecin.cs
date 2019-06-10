using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHopital.Models.DTO
{
    public class Medecin : BaseDTO
    {
        private int id_medecin;
        private string nom_medecin;
        private string prenom_medecin;
        private string tel_medecin;

        private int consultation_id;
        private int prescription_id;

        public Medecin()
        {
        }

        public Medecin(int id_medecin, string nom_medecin, string prenom_medecin, string tel_medecin, int consultation_id, int prescription_id)
        {
            this.id_medecin = id_medecin;
            this.nom_medecin = nom_medecin;
            this.prenom_medecin = prenom_medecin;
            this.tel_medecin = tel_medecin;
            this.consultation_id = consultation_id;
            this.prescription_id = prescription_id;
        }

        public int Id_medecin { get => id_medecin; set => id_medecin = value; }
        public string Nom_medecin { get => nom_medecin; set => nom_medecin = value; }
        public string Prenom_medecin { get => prenom_medecin; set => prenom_medecin = value; }
        public string Tel_medecin { get => tel_medecin; set => tel_medecin = value; }
        public int Consultation_id { get => consultation_id; set => consultation_id = value; }
        public int Prescription_id { get => prescription_id; set => prescription_id = value; }

        public override bool CheckData()
        {
            return (nom_medecin == null || nom_medecin == "" || prenom_medecin == null || prenom_medecin == "") ? false : true;
        }

        public override string ToString()
        {
            return "Medecin (id :" + Id_medecin + "nom:" + Nom_medecin + " prenom:" + Prenom_medecin + " telephone:" + Tel_medecin + ")";
        }
    }
}
