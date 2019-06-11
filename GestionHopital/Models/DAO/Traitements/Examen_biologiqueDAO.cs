using GestionHopital.Models.DTO.Traitements;
using GestionHopital.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHopital.Models.DAO.Traitements
{
    public class Examen_biologiqueDAO : TraitementDAO, IDAO<Examen_biologique, int>
    {
        public Examen_biologiqueDAO()
        {
            data = DataContext.Instance;
        }

        public bool Create(Examen_biologique examen)
        {
            if (examen == null)
                throw new ArgumentNullException(nameof(examen));
            else
            {
                Task t = Task.Run(() =>
                {
                    lock (new object())
                    {
                        data.Examen_biologiques.Add(examen);
                        data.SaveChanges();
                    }
                });

                t.Wait();
                return true;
            }
        }

        public new Examen_biologique Retrieve(int id)
        {
            Task<Examen_biologique> t = Task.Run(() =>
            {
                lock (new object())
                {
                    return data.Examen_biologiques.Find(id);
                }
            });

            return t.Result;
        }

        public bool Update(Examen_biologique examen, int id)
        {
            if (examen == null)
                throw new ArgumentNullException(nameof(examen));
            else
            {

                Task t = Task.Run(() =>
                {
                    lock (new object())
                    {
                        Examen_biologique currentExamen_biologique = data.Examen_biologiques.Where(x => x.Id_traitement == id).FirstOrDefault();
                        if (currentExamen_biologique == null)
                            throw new ArgumentNullException(nameof(currentExamen_biologique));
                        else
                        {
                            currentExamen_biologique.Date_traitement = examen.Date_traitement;
                            currentExamen_biologique.Prix_traitement = examen.Prix_traitement;
                            currentExamen_biologique.Designation = examen.Designation;
                            currentExamen_biologique.Resultat_examen = examen.Resultat_examen;

                            data.SaveChanges();
                        }
                    }
                });

                return true;
            }
        }

        public new List<Examen_biologique> ListAll()
        {
            Task<List<Examen_biologique>> t = Task.Run(new Func<List<Examen_biologique>>(() =>
            {
                List<Examen_biologique> examens;

                lock (new object())
                {
                    examens = data.Examen_biologiques.ToList();
                    return examens;
                }
            }));

            return t.Result;
        }
    }
}
