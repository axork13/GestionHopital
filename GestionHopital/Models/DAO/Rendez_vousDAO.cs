using GestionHopital.Models.DTO;
using GestionHopital.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHopital.Models.DAO
{
    public class Rendez_vousDAO : IDAO<Rendez_vous, int>
    {
        private DataContext data;
        public Rendez_vousDAO()
        {
            data = DataContext.Instance;
        }

        public bool Create(Rendez_vous rdv)
        {
            if (rdv == null)
                throw new ArgumentNullException(nameof(rdv));
            else
            {
                Task t = Task.Run(() =>
                {
                    lock (new object())
                    {
                        data.Rendez_vouss.Add(rdv);
                        data.SaveChanges();
                    }
                });

                t.Wait();
                return true;
            }
        }
        
        public Rendez_vous Retrieve(int id)
        {
            Task<Rendez_vous> t = Task.Run(() =>
            {
                lock (new object())
                {
                    return data.Rendez_vouss.Find(id);
                }
            });

            return t.Result;
        }

        public bool Update(Rendez_vous rdv, int id)
        {
            if (rdv == null)
                throw new ArgumentNullException(nameof(rdv));
            else
            {

                Task t = Task.Run(() =>
                {
                    lock (new object())
                    {
                        Rendez_vous currentRdv = data.Rendez_vouss.Where(x => x.Code_rdv == id).FirstOrDefault();
                        if (currentRdv == null)
                            throw new ArgumentNullException(nameof(currentRdv));
                        else
                        {
                            currentRdv.Medecin = rdv.Medecin;
                            currentRdv.Date = rdv.Date;
                            currentRdv.Service = rdv.Service;

                            currentRdv.Patient_id = rdv.Patient_id;
                            currentRdv.Consultation_id = rdv.Consultation_id;

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
                    Rendez_vous currentRdv = data.Rendez_vouss.Where(x => x.Code_rdv == id).FirstOrDefault();

                    if (currentRdv == null)
                        throw new ArgumentNullException(nameof(currentRdv));
                    else
                    {
                        data.Medecins.Remove(currentRdv);
                    }
                }
            });

            return true;
        }

        public List<Rendez_vous> ListAll()
        {
            Task<List<Rendez_vous>> t = Task.Run(new Func<List<Rendez_vous>>(() =>
            {
                List<Rendez_vous> rdvs;

                lock (new object())
                {
                    rdvs = data.Rendez_vouss.ToList();
                    return rdvs;
                }
            }));

            return t.Result;
        }              
    }
}
