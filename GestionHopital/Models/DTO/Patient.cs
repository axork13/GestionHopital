using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHopital.Models.DTO
{
    public class Patient : BaseDTO
    {
        private int id_patient;
        private string nom_patient;
        private string prenom_patient;
        private DateTime date_naissance;
        private string sexe;
        private string adresse;
        private string situation_familliale;
        private string assurance_medicale;
        private string code_assurance;
        private string tel;
        private string nom_pere;
        private string nom_mere;
        private string nomP_a_prevenir;
        private string telP_a_prevenir;

        private int rdv_code;
        private int consultation_id;
        private int hospitalisation_id;
        private int traitement_id;

        public Patient()
        {
        }

        public Patient(int id_patient, string nom_patient, string prenom_patient, DateTime date_naissance, string sexe, string adresse, string situation_familliale, string assurance_medicale, string code_assurance, string tel, string nom_pere, string nom_mere, string nomP_a_prevenir, string telP_a_prevenir, int rdv_code, int consultation_id, int hospitalisation_id, int traitement_id)
        {
            this.id_patient = id_patient;
            this.nom_patient = nom_patient;
            this.prenom_patient = prenom_patient;
            this.date_naissance = date_naissance;
            this.sexe = sexe;
            this.adresse = adresse;
            this.situation_familliale = situation_familliale;
            this.assurance_medicale = assurance_medicale;
            this.code_assurance = code_assurance;
            this.tel = tel;
            this.nom_pere = nom_pere;
            this.nom_mere = nom_mere;
            this.nomP_a_prevenir = nomP_a_prevenir;
            this.telP_a_prevenir = telP_a_prevenir;
            this.rdv_code = rdv_code;
            this.consultation_id = consultation_id;
            this.hospitalisation_id = hospitalisation_id;
            this.traitement_id = traitement_id;
        }

        public override bool CheckData()
        {
            return (nom_patient == null || nom_patient == "" || prenom_patient == null || prenom_patient == "" || date_naissance == null) ? false : true;
        }

        public override string ToString()
        {
            return "Patient (id :" + id_patient + " nom:" + nom_patient + " prenom: " + prenom_patient + " date de naissance: " + date_naissance +
                "\n sexe: " + sexe + "adresse:" + adresse + " situation familiale: " + situation_familliale + " assurance: " + assurance_medicale +
                "\nCode assurance: " + code_assurance + "téléphone: " + tel + "nom du père: " + nom_pere + "nom de la mère:" + nom_mere +
                "\nNom personne à prévenir: " + nomP_a_prevenir + "Tel personne à prévenir:" + telP_a_prevenir + ")";
        }
    }
}
