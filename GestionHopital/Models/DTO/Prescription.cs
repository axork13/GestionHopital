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
