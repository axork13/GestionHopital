using GestionHopital.Models.DTO;
using GestionHopital.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHopital.Models.DAO
{
    public class PatientDAO : IDAO<Patient, int>
    {
        private DataContext data;

        public PatientDAO()
        {
            data = DataContext.Instance;
        }

        public bool Create(Patient t)
        {
            throw new NotImplementedException();
        }

        public Patient Retrieve(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Patient t, int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Patient> ListAll()
        {
            throw new NotImplementedException();
        }

    }
}
