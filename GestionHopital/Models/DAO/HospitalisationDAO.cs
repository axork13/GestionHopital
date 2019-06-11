using GestionHopital.Models.DTO;
using GestionHopital.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHopital.Models.DAO
{
    public class HospitalisationDAO : IDAO<Hospitalisation, int>
    {
        private DataContext data;

        public HospitalisationDAO()
        {
            data = DataContext.Instance;
        }

        public bool Create(Hospitalisation hospitalisation)
        {
            if (hospitalisation == null)
                throw new ArgumentNullException(nameof(hospitalisation));
            else
            {
                Task t = Task.Run(() =>
                {
                    lock (new object())
                    {
                        data.Hospitalisations.Add(hospitalisation);
                        data.SaveChanges();
                    }
                });

                t.Wait();
                return true;
            }
        }
        
        public Hospitalisation Retrieve(int id)
        {
            Task<Hospitalisation> t = Task.Run(() =>
            {
                lock (new object())
                {
                    return data.Hospitalisations.Find(id);
                }
            });

            return t.Result;
        }

        public bool Update(Hospitalisation hospitalisation, int id)
        {
            if (hospitalisation == null)
                throw new ArgumentNullException(nameof(hospitalisation));
            else
            {

                Task t = Task.Run(() =>
                {
                    lock (new object())
                    {
                        Hospitalisation currentHospitalisation = data.Hospitalisations.Where(x => x.Id_admission == id).FirstOrDefault();
                        if (currentHospitalisation == null)
                            throw new ArgumentNullException(nameof(currentHospitalisation));
                        else
                        {
                            currentHospitalisation.Date_admission = hospitalisation.Date_admission;
                            currentHospitalisation.Type_admission = hospitalisation.Type_admission;
                            currentHospitalisation.Motif_admission = hospitalisation.Motif_admission;
                            currentHospitalisation.Medecin_traitant = hospitalisation.Medecin_traitant;
                            currentHospitalisation.Nom_accompagnant = hospitalisation.Nom_accompagnant;
                            currentHospitalisation.Prenom_accompagnant = hospitalisation.Prenom_accompagnant;
                            currentHospitalisation.Lien_parente = hospitalisation.Lien_parente;
                            currentHospitalisation.Date_entreeAcc = hospitalisation.Date_entreeAcc;
                            currentHospitalisation.Date_sortieAcc = hospitalisation.Date_sortieAcc;
                            currentHospitalisation.Date_sortie = hospitalisation.Date_sortie;
                            currentHospitalisation.Motif_sortie = hospitalisation.Motif_sortie;
                            currentHospitalisation.Resultat_sortie = hospitalisation.Resultat_sortie;
                            currentHospitalisation.Date_deces = hospitalisation.Date_deces;
                            currentHospitalisation.Motif_deces = hospitalisation.Motif_deces;

                            currentHospitalisation.Patient_id = hospitalisation.Patient_id;
                            currentHospitalisation.Traitement_id = hospitalisation.Traitement_id;
                            currentHospitalisation.Facture_id = hospitalisation.Facture_id;
                                                       
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
                    Hospitalisation currentHospitalisation = data.Hospitalisations.Where(x => x.Id_admission == id).FirstOrDefault();

                    if (currentHospitalisation == null)
                        throw new ArgumentNullException(nameof(currentHospitalisation));
                    else
                    {
                        data.Hospitalisations.Remove(currentHospitalisation);
                    }
                }
            });

            return true;
        }

        public List<Hospitalisation> ListAll()
        {
            Task<List<Hospitalisation>> t = Task.Run(new Func<List<Hospitalisation>>(() =>
            {
                List<Hospitalisation> hospitalisations;

                lock (new object())
                {
                    hospitalisations = data.Hospitalisations.ToList();
                    return hospitalisations;
                }
            }));

            return t.Result;
        }
    }
}
