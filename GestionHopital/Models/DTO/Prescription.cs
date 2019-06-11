using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHopital.Models.DTO
{
    public class Prescription : BaseDTO
    {
        private int id_prescription;
        private DateTime date_prescription;
        private string nom_patient;
        private string prenom_patient;
        private string note;

        private int consultation_id;
        private int medecin_id;

        public Prescription()
        {
        }

        public Prescription(int id_prescription, DateTime date_prescription, string nom_patient, string prenom_patient, string note, int consultation_id, int medecin_id)
        {
            this.id_prescription = id_prescription;
            this.date_prescription = date_prescription;
            this.nom_patient = nom_patient;
            this.prenom_patient = prenom_patient;
            this.note = note;
            this.consultation_id = consultation_id;
            this.medecin_id = medecin_id;
        }

        public int Id_prescription { get => id_prescription; set => id_prescription = value; }
        public DateTime Date_prescription { get => date_prescription; set => date_prescription = value; }
        public string Nom_patient { get => nom_patient; set => nom_patient = value; }
        public string Prenom_patient { get => prenom_patient; set => prenom_patient = value; }
        public string Note { get => note; set => note = value; }
        public int Consultation_id { get => consultation_id; set => consultation_id = value; }
        public int Medecin_id { get => medecin_id; set => medecin_id = value; }

        public override bool CheckData()
        {
            return (date_prescription == null || nom_patient == "" || nom_patient == null || prenom_patient == "" || prenom_patient == null) ? false : true;
        }

        public override string ToString()
        {
            return "Prescription (id :" + id_prescription + " date de prescription: " + date_prescription +
                "\n nom du patient: " + nom_patient + "prenom du patient:" + prenom_patient + " Note: " + note + ")";
        }
    }
}
