using GestionHopital.Models.DTO.Traitements;
using GestionHopital.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHopital.Models.DAO.Traitements
{
    public abstract class TraitementDAO : IDAO<Traitement, int>
    {
        protected DataContext data;
        public TraitementDAO()
        {
            data = DataContext.Instance;
        }

        public bool Create(Traitement traitement)
        {
            if (traitement == null)
                throw new ArgumentNullException(nameof(traitement));
            else
            {
                Task t = Task.Run(() =>
                {
                    lock (new object())
                    {
                        data.Traitements.Add(traitement);
                        data.SaveChanges();
                    }
                });

                t.Wait();
                return true;
            }
        }


        public Traitement Retrieve(int id)
        {
            Task<Traitement> t = Task.Run(() =>
            {
                lock (new object())
                {
                    return data.Traitements.Find(id);
                }
            });

            return t.Result;
        }

        public bool Update(Traitement traitement, int id)
        {
            if (traitement == null)
                throw new ArgumentNullException(nameof(traitement));
            else
            {

                Task t = Task.Run(() =>
                {
                    lock (new object())
                    {
                        Traitement currentTraitement = data.Traitements.Where(x => x.Id_traitement == id).FirstOrDefault();
                        if (currentTraitement == null)
                            throw new ArgumentNullException(nameof(currentTraitement));
                        else
                        {
                            currentTraitement.Date_traitement = traitement.Date_traitement;
                            currentTraitement.Prix_traitement = traitement.Prix_traitement;

                            currentTraitement.Facture_id = traitement.Facture_id;
                            currentTraitement.Admission_id = traitement.Admission_id;
                            currentTraitement.Patient_id = traitement.Patient_id;

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
                    Traitement currentTraitement = data.Traitements.Where(x => x.Id_traitement == id).FirstOrDefault();

                    if (currentTraitement == null)
                        throw new ArgumentNullException(nameof(currentTraitement));
                    else
                    {
                        data.Traitements.Remove(currentTraitement);
                    }
                }
            });

            return true;
        }

        public List<Traitement> ListAll()
        {
            Task<List<Traitement>> t = Task.Run(new Func<List<Traitement>>(() =>
            {
                List<Traitement> traitements;

                lock (new object())
                {
                    traitements = data.Traitements.ToList();
                    return traitements;
                }
            }));

            return t.Result;
        }
    }
}
