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

        public int Id_patient { get => id_patient; set => id_patient = value; }
        public string Nom_patient { get => nom_patient; set => nom_patient = value; }
        public string Prenom_patient { get => prenom_patient; set => prenom_patient = value; }
        public DateTime Date_naissance { get => date_naissance; set => date_naissance = value; }
        public string Sexe { get => sexe; set => sexe = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string Situation_familliale { get => situation_familliale; set => situation_familliale = value; }
        public string Assurance_medicale { get => assurance_medicale; set => assurance_medicale = value; }
        public string Code_assurance { get => code_assurance; set => code_assurance = value; }
        public string Tel { get => tel; set => tel = value; }
        public string Nom_pere { get => nom_pere; set => nom_pere = value; }
        public string Nom_mere { get => nom_mere; set => nom_mere = value; }
        public string NomP_a_prevenir { get => nomP_a_prevenir; set => nomP_a_prevenir = value; }
        public string TelP_a_prevenir { get => telP_a_prevenir; set => telP_a_prevenir = value; }
        public int Rdv_code { get => rdv_code; set => rdv_code = value; }
        public int Consultation_id { get => consultation_id; set => consultation_id = value; }
        public int Hospitalisation_id { get => hospitalisation_id; set => hospitalisation_id = value; }
        public int Traitement_id { get => traitement_id; set => traitement_id = value; }

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
