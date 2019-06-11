using GestionHopital.Models.DTO;
using GestionHopital.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHopital.Models.DAO
{
    public class MedecinDAO : IDAO<Medecin, int>
    {
        private DataContext data;

        public MedecinDAO()
        {
            data = DataContext.Instance;
        }

        public bool Create(Medecin medecin)
        {
            if (medecin == null)
                throw new ArgumentNullException(nameof(medecin));
            else
            {
                Task t = Task.Run(() =>
                {
                    lock (new object())
                    {
                        data.Medecins.Add(medecin);
                        data.SaveChanges();
                    }
                });

                t.Wait();
                return true;
            }
        }

        public Medecin Retrieve(int id)
        {
            Task<Medecin> t = Task.Run(() =>
            {
                lock (new object())
                {
                    return data.Medecins.Find(id);
                }
            });

            return t.Result;
        }

        public bool Update(Medecin medecin, int id)
        {
            if (medecin == null)
                throw new ArgumentNullException(nameof(medecin));
            else
            {

                Task t = Task.Run(() =>
                {
                    lock (new object())
                    {
                        Medecin currentMedecin = data.Medecins.Where(x => x.Id_medecin == id).FirstOrDefault();
                        if (currentMedecin == null)
                            throw new ArgumentNullException(nameof(currentMedecin));
                        else
                        {
                            currentMedecin.Nom_medecin = medecin.Nom_medecin;
                            currentMedecin.Prenom_medecin = medecin.Prenom_medecin;
                            currentMedecin.Tel_medecin = medecin.Tel_medecin;

                            currentMedecin.Consultation_id = medecin.Consultation_id;
                            currentMedecin.Prescription_id = medecin.Prescription_id;

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
                    Medecin currentMedecin = data.Medecins.Where(x => x.Id_medecin == id).FirstOrDefault();

                    if (currentMedecin == null)
                        throw new ArgumentNullException(nameof(currentMedecin));
                    else
                    {
                        data.Medecins.Remove(currentMedecin);
                    }
                }
            });

            return true;
        }

        public List<Medecin> ListAll()
        {
            Task<List<Medecin>> t = Task.Run(new Func<List<Medecin>>(() =>
            {
                List<Medecin> medecins;

                lock (new object())
                {
                    medecins = data.Medecins.ToList();
                    return medecins;
                }
            }));

            return t.Result;
        }
    }
}
