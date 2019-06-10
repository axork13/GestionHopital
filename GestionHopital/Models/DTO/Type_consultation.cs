using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHopital.Models.DTO
{
    public class Type_consultation : BaseDTO
    {
        private int id_type_consultation;
        private string type_consultation;
        private decimal prix_consultation;

        private int consultation_id;

        public Type_consultation()
        {
        }

        public Type_consultation(int id_type_consultation, string type_consultation, decimal prix_consultation, int consultation_id)
        {
            this.id_type_consultation = id_type_consultation;
            this.type_consultation = type_consultation;
            this.prix_consultation = prix_consultation;
            this.consultation_id = consultation_id;
        }

        public override bool CheckData()
        {
            return (type_consultation == "" || type_consultation == null || prix_consultation < 0) ? false : true; 
        }

        public override string ToString()
        {
            return "Type consultation (id:" + id_type_consultation + ", type:" + type_consultation + ", prix:" + prix_consultation + "€";
        }
    }
}
