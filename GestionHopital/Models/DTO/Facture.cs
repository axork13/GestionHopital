using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHopital.Models.DTO
{
    public class Facture : BaseDTO
    {
        private int id_facture;
        private DateTime date_facture;
        private decimal total;

        private int admission_id;
        private int traitement_id;

        public Facture()
        {
        }

        public Facture(int id_facture, DateTime date_facture, decimal total, int admission_id, int traitement_id)
        {
            this.id_facture = id_facture;
            this.date_facture = date_facture;
            this.total = total;
            this.admission_id = admission_id;
            this.traitement_id = traitement_id;
        }

        public int Id_facture { get => id_facture; set => id_facture = value; }
        public DateTime Date_facture { get => date_facture; set => date_facture = value; }
        public decimal Total { get => total; set => total = value; }
        public int Admission_id { get => admission_id; set => admission_id = value; }
        public int Traitement_id { get => traitement_id; set => traitement_id = value; }

        public override bool CheckData()
        {
            return date_facture == null ? false : true;
        }

        public override string ToString()
        {
            return "Facture (id :" + id_facture + ", date : " + date_facture + ", total : " + total + ")";
        }
    }
}
