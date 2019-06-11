using GestionHopital.Models.DTO;
using GestionHopital.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHopital.Models.DAO
{
    public class FactureDAO : IDAO<Facture, int>
    {
        private DataContext data;

        public FactureDAO()
        {
            data = DataContext.Instance;
        }

        public bool Create(Facture facture)
        {
            if (facture == null)
                throw new ArgumentNullException(nameof(facture));
            else
            {
                Task t = Task.Run(() =>
                {
                    lock (new object())
                    {
                        data.Factures.Add(facture);
                        data.SaveChanges();
                    }
                });

                t.Wait();
                return true;
            }
        }
        
        public Facture Retrieve(int id)
        {
            Task<Facture> t = Task.Run(() =>
            {
                lock (new object())
                {
                    return data.Factures.Find(id);
                }
            });

            return t.Result;
        }

        public bool Update(Facture facture, int id)
        {
            if (facture == null)
                throw new ArgumentNullException(nameof(facture));
            else
            {

                Task t = Task.Run(() =>
                {
                    lock (new object())
                    {
                        Facture currentFacture = data.Factures.Where(x => x.Id_facture == id).FirstOrDefault();
                        if (currentFacture == null)
                            throw new ArgumentNullException(nameof(currentFacture));
                        else
                        {
                            currentFacture.Date_facture = facture.Date_facture;
                            currentFacture.Total = facture.Total;

                            currentFacture.Admission_id = facture.Admission_id;
                            currentFacture.Traitement_id = facture.Traitement_id;

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
                    Facture currentFacture = data.Factures.Where(x => x.Id_facture == id).FirstOrDefault();

                    if (currentFacture == null)
                        throw new ArgumentNullException(nameof(currentFacture));
                    else
                    {
                        data.Factures.Remove(currentFacture);
                    }
                }
            });

            return true;
        }

        public List<Facture> ListAll()
        {
            Task<List<Facture>> t = Task.Run(new Func<List<Facture>>(() =>
            {
                List<Facture> factures;

                lock (new object())
                {
                    factures = data.Factures.ToList();
                    return factures;
                }
            }));

            return t.Result;
        }
    }
}
