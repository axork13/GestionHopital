using GestionHopital.Models.DTO;
using GestionHopital.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHopital.Models.DAO
{
    public class ConsultationDAO : IDAO<Consultation, int>
    {
        private DataContext data;

        public ConsultationDAO()
        {
            data = DataContext.Instance;
        }

        public bool Create(Consultation consultation)
        {
            if (consultation == null)
                throw new ArgumentNullException(nameof(consultation));
            else
            {
                Task t = Task.Run(() =>
                {
                    lock (new object())
                    {
                        data.Consultations.Add(consultation);
                        data.SaveChanges();
                    }
                });

                t.Wait();
                return true;
            }
        }

        public Consultation Retrieve(int id)
        {
            Task<Consultation> t = Task.Run(() =>
            {
                lock (new object())
                {
                    return data.Consultations.Find(id);
                }
            });

            return t.Result;
        }

        public bool Update(Consultation consultation, int id)
        {
            if (consultation == null)
                throw new ArgumentNullException(nameof(consultation));
            else
            {

                Task t = Task.Run(() =>
                {
                    lock (new object())
                    {
                        Consultation currentConsultation = data.Consultations.Where(x => x.Id_consultation == id).FirstOrDefault();
                        if (currentConsultation == null)
                            throw new ArgumentNullException(nameof(currentConsultation));
                        else
                        {
                            currentConsultation.Date_consultation = consultation.Date_consultation;
                            currentConsultation.Synthese = consultation.Synthese;

                            currentConsultation.Type_consultation_id = consultation.Type_consultation_id;
                            currentConsultation.Rdv_code = consultation.Rdv_code;
                            currentConsultation.Prescription_id = consultation.Prescription_id;
                            currentConsultation.Medecin_id = consultation.Medecin_id;

                            data.SaveChanges();                            
                        }
                    }
                });

                return true;
            }
        }

        public bool Delete(int id)
        {
            Task.Run(() =>
            {
                lock (new object())
                {
                    Consultation currentConsultation = data.Consultations.Where(x => x.Id_consultation == id).FirstOrDefault();

                    if(currentConsultation == null)
                        throw new ArgumentNullException(nameof(currentConsultation));
                    else
                    {
                        data.Consultations.Remove(currentConsultation);
                    }
                }
            });

            return true;
        }

        public List<Consultation> ListAll()
        {
            Task<List<Consultation>> t = Task.Run(new Func<List<Consultation>>(() =>
            {
                List<Consultation> consultations;

                lock (new object())
                {
                    consultations = data.Consultations.ToList();
                    return consultations;
                }
            }));

            return t.Result;
        }
    }
}
