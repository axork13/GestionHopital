using GestionHopital.Models.DTO;
using GestionHopital.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHopital.Models.DAO
{
    public class PrescriptionDAO : IDAO<Prescription, int>
    {
        private DataContext data;

        public PrescriptionDAO()
        {
            data = DataContext.Instance;
        }

        public bool Create(Prescription prescription)
        {
            if (prescription == null)
                throw new ArgumentNullException(nameof(prescription));
            else
            {
                Task t = Task.Run(() =>
                {
                    lock (new object())
                    {
                        data.Prescriptions.Add(prescription);
                        data.SaveChanges();
                    }
                });

                t.Wait();
                return true;
            }
        }

        public Prescription Retrieve(int id)
        {
            Task<Prescription> t = Task.Run(() =>
            {
                lock (new object())
                {
                    return data.Prescriptions.Find(id);
                }
            });

            return t.Result;
        }

        public bool Update(Prescription prescription, int id)
        {
            if (prescription == null)
                throw new ArgumentNullException(nameof(prescription));
            else
            {

                Task t = Task.Run(() =>
                {
                    lock (new object())
                    {
                        Prescription currentPrescription = data.Prescriptions.Where(x => x.Id_prescription == id).FirstOrDefault();
                        if (currentPrescription == null)
                            throw new ArgumentNullException(nameof(currentPrescription));
                        else
                        {
                            currentPrescription.Date_prescription = prescription.Date_prescription;
                            currentPrescription.Nom_patient = prescription.Nom_patient;
                            currentPrescription.Prenom_patient = prescription.Prenom_patient;
                            currentPrescription.Note = prescription.Note;

                            currentPrescription.Consultation_id = prescription.Consultation_id;
                            currentPrescription.Medecin_id = prescription.Medecin_id;

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
                    Prescription currentPrescription = data.Prescriptions.Where(x => x.Id_prescription == id).FirstOrDefault();

                    if (currentPrescription == null)
                        throw new ArgumentNullException(nameof(currentPrescription));
                    else
                    {
                        data.Prescriptions.Remove(currentPrescription);
                    }
                }
            });

            return true;
        }

        public List<Prescription> ListAll()
        {
            Task<List<Prescription>> t = Task.Run(new Func<List<Prescription>>(() =>
            {
                List<Prescription> prescriptions;

                lock (new object())
                {
                    prescriptions = data.Prescriptions.ToList();
                    return prescriptions;
                }
            }));

            return t.Result;
        }
    }
}
