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

        public bool Create(Patient patient)
        {
            if (patient == null)
                throw new ArgumentNullException(nameof(patient));
            else
            {
                Task t = Task.Run(() =>
                {
                    lock (new object())
                    {
                        data.Patients.Add(patient);
                        data.SaveChanges();
                    }
                });

                t.Wait();
                return true;
            }
        }

        public Patient Retrieve(int id)
        {
            Task<Patient> t = Task.Run(() =>
            {
                lock (new object())
                {
                    return data.Patients.Find(id);
                }
            });

            return t.Result;
        }

        public bool Update(Patient patient, int id)
        {
            if (patient == null)
                throw new ArgumentNullException(nameof(patient));
            else
            {

                Task t = Task.Run(() =>
                {
                    lock (new object())
                    {
                        Patient currentPatient = data.Patients.Where(x => x.Id_patient == id).FirstOrDefault();
                        if (currentPatient == null)
                            throw new ArgumentNullException(nameof(currentPatient));
                        else
                        {
                            currentPatient.Nom_patient = patient.Nom_patient;
                            currentPatient.Prenom_patient = patient.Prenom_patient;
                            currentPatient.Date_naissance = patient.Date_naissance;
                            currentPatient.Sexe = patient.Sexe;
                            currentPatient.Adresse = patient.Adresse;
                            currentPatient.Situation_familliale = patient.Situation_familliale;
                            currentPatient.Assurance_medicale = patient.Assurance_medicale;
                            currentPatient.Code_assurance = patient.Code_assurance;
                            currentPatient.Tel = patient.Tel;
                            currentPatient.Nom_pere = patient.Nom_pere;
                            currentPatient.Nom_mere = patient.Nom_mere;
                            currentPatient.NomP_a_prevenir = patient.NomP_a_prevenir;
                            currentPatient.TelP_a_prevenir = patient.TelP_a_prevenir;

                            currentPatient.Rdv_code = patient.Rdv_code;
                            currentPatient.Consultation_id = patient.Consultation_id;
                            currentPatient.Hospitalisation_id = patient.Hospitalisation_id;
                            currentPatient.Traitement_id = patient.Traitement_id;

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
                    Patient currentPatient = data.Patients.Where(x => x.Id_patient == id).FirstOrDefault();

                    if (currentPatient == null)
                        throw new ArgumentNullException(nameof(currentPatient));
                    else
                    {
                        data.Patients.Remove(currentPatient);
                    }
                }
            });

            return true;
        }

        public List<Patient> ListAll()
        {
            Task<List<Patient>> t = Task.Run(new Func<List<Patient>>(() =>
            {
                List<Patient> patients;

                lock (new object())
                {
                    patients = data.Patients.ToList();
                    return patients;
                }
            }));

            return t.Result;
        }
    }
}
