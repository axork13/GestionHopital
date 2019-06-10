using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHopital.Models.DTO
{
    public enum ServiceEnum
    {
        Cardiologie,
        Neurologie,
        Hematologie,
        Pneumologie,
        Nephrologie,
        Maternite,
        Osteopathie,
        Oncologie
    }

    public class Rendez_vous : BaseDTO
    {
        private int code_rdv;
        private string medecin;
        private DateTime date;
        private ServiceEnum service;

        private int patient_id;
        private int consultation_id;

        public Rendez_vous()
        {
        }

        public Rendez_vous(int code_rdv, string medecin, DateTime date, ServiceEnum service, int patient_id, int consultation_id)
        {
            this.code_rdv = code_rdv;
            this.medecin = medecin;
            this.date = date;
            this.service = service;
            this.patient_id = patient_id;
            this.consultation_id = consultation_id;
        }

        public int Code_rdv { get => code_rdv; set => code_rdv = value; }
        public string Medecin { get => medecin; set => medecin = value; }
        public DateTime Date { get => date; set => date = value; }
        public ServiceEnum Service { get => service; set => service = value; }
        public int Patient_id { get => patient_id; set => patient_id = value; }
        public int Consultation_id { get => consultation_id; set => consultation_id = value; }

        public override bool CheckData()
        {
            return (Enum.IsDefined(typeof(ServiceEnum), service) || medecin == "" || medecin == null || patient_id < 0 || date == null) ? false : true;
        }

        public override string ToString()
        {
            return "Rendez_Vous (Code Rendez-Vous :" + code_rdv + "Nom du Medecin:" + medecin + " Date du Rdv:" + date + " Service :" + service + ")";
        }

       
    }
}
