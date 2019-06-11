using GestionHopital.Models.DTO.Traitements;
using GestionHopital.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHopital.Models.DAO.Traitements
{
    public class Examen_radiologiqueDAO : TraitementDAO, IDAO<Examen_radiologique, int>
    {
        public Examen_radiologiqueDAO()
        {
            data = DataContext.Instance;
        }

        public bool Create(Examen_radiologique examen)
        {
            if (examen == null)
                throw new ArgumentNullException(nameof(examen));
            else
            {
                Task t = Task.Run(() =>
                {
                    lock (new object())
                    {
                        data.Examen_radiologiques.Add(examen);
                        data.SaveChanges();
                    }
                });

                t.Wait();
                return true;
            }
        }

        public new Examen_radiologique Retrieve(int id)
        {
            Task<Examen_radiologique> t = Task.Run(() =>
            {
                lock (new object())
                {
                    return data.Examen_radiologiques.Find(id);
                }
            });

            return t.Result;
        }

        public bool Update(Examen_radiologique examen, int id)
        {
            if (examen == null)
                throw new ArgumentNullException(nameof(examen));
            else
            {

                Task t = Task.Run(() =>
                {
                    lock (new object())
                    {
                        Examen_radiologique currentExamen_radiologique = data.Examen_radiologiques.Where(x => x.Id_traitement == id).FirstOrDefault();
                        if (currentExamen_radiologique == null)
                            throw new ArgumentNullException(nameof(currentExamen_radiologique));
                        else
                        {
                            currentExamen_radiologique.Date_traitement = examen.Date_traitement;
                            currentExamen_radiologique.Prix_traitement = examen.Prix_traitement;
                            currentExamen_radiologique.Designation = examen.Designation;
                            currentExamen_radiologique.Resultat_examen = examen.Resultat_examen;
                            currentExamen_radiologique.Image = examen.Image;

                            data.SaveChanges();
                        }
                    }
                });

                return true;
            }
        }

        public new List<Examen_radiologique> ListAll()
        {
            Task<List<Examen_radiologique>> t = Task.Run(new Func<List<Examen_radiologique>>(() =>
            {
                List<Examen_radiologique> examens;

                lock (new object())
                {
                    examens = data.Examen_radiologiques.ToList();
                    return examens;
                }
            }));

            return t.Result;
        }

    }
}
