using GestionHopital.Models.DTO.Traitements;
using GestionHopital.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHopital.Models.DAO.Traitements
{
    public class ChirurgieDAO : TraitementDAO, IDAO<Chirurgie, int>
    {       
        public ChirurgieDAO()
        {
            data = DataContext.Instance;
        }

        public bool Create(Chirurgie chirurgie)
        {
            if (chirurgie == null)
                throw new ArgumentNullException(nameof(chirurgie));
            else
            {
                Task t = Task.Run(() =>
                {
                    lock (new object())
                    {
                        data.Traitements.Add(chirurgie);
                        data.SaveChanges();
                    }
                });

                t.Wait();
                return true;
            }
        }

        public new Chirurgie Retrieve(int id)
        {
            Task<Chirurgie> t = Task.Run(() =>
            {
                lock (new object())
                {
                    return data.Chirurgies.Find(id);
                }
            });

            return t.Result;
        }

        public bool Update(Chirurgie chirurgie, int id)
        {
            if (chirurgie == null)
                throw new ArgumentNullException(nameof(chirurgie));
            else
            {

                Task t = Task.Run(() =>
                {
                    lock (new object())
                    {
                        Chirurgie currentChirurgie = data.Chirurgies.Where(x => x.Id_traitement == id).FirstOrDefault();
                        if (currentChirurgie == null)
                            throw new ArgumentNullException(nameof(currentChirurgie));
                        else
                        {
                            currentChirurgie.Date_traitement = chirurgie.Date_traitement;
                            currentChirurgie.Prix_traitement = chirurgie.Prix_traitement;
                            currentChirurgie.Chirurgien = chirurgie.Chirurgien;
                            currentChirurgie.Anesthesiste = chirurgie.Anesthesiste;
                            currentChirurgie.Facture_id = chirurgie.Facture_id;

                            data.SaveChanges();
                        }
                    }
                });

                return true;
            }
        }

        public new List<Chirurgie> ListAll()
        {
            Task<List<Chirurgie>> t = Task.Run(new Func<List<Chirurgie>>(() =>
            {
                List<Chirurgie> chirurgies;

                lock (new object())
                {
                    chirurgies = data.Chirurgies.ToList();
                    return chirurgies;
                }
            }));

            return t.Result;
        }
    }
}
