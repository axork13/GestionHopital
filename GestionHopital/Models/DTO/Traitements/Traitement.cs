using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHopital.Models.DTO.Traitements
{
    public abstract class Traitement : BaseDTO
    {
        protected int id_traitement;
        protected DateTime date_traitement;
        protected decimal prix_traitement;
        
        protected int facture_id;
        protected int admission_id;
        protected int patient_id;

        public int Id_traitement { get => id_traitement; set => id_traitement = value; }
        public DateTime Date_traitement { get => date_traitement; set => date_traitement = value; }
        public decimal Prix_traitement { get => prix_traitement; set => prix_traitement = value; }
        public int Facture_id { get => facture_id; set => facture_id = value; }
        public int Admission_id { get => admission_id; set => admission_id = value; }
        public int Patient_id { get => patient_id; set => patient_id = value; }

        public override string ToString()
        {
            return "Traitement (id:" + id_traitement + ",date du traitement:" + date_traitement + ",prix du traitement:" + prix_traitement + "€)";
        }
    }
}
