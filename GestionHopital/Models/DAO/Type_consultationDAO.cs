using GestionHopital.Models.DTO;
using GestionHopital.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHopital.Models.DAO
{
    public class Type_consultationDAO : IDAO<Type_consultation, int>
    {
        private DataContext data;

        public Type_consultationDAO()
        {
            data = DataContext.Instance;
        }

        public bool Create(Type_consultation type_consultation)
        {
            if (type_consultation == null)
                throw new ArgumentNullException(nameof(type_consultation));
            else
            {
                Task t = Task.Run(() =>
                {
                    lock (new object())
                    {
                        data.Type_consultations.Add(type_consultation);
                        data.SaveChanges();
                    }
                });

                t.Wait();
                return true;
            }
        }

        public Type_consultation Retrieve(int id)
        {
            Task<Type_consultation> t = Task.Run(() =>
            {
                lock (new object())
                {
                    return data.Type_consultations.Find(id);
                }
            });

            return t.Result;
        }

        public bool Update(Type_consultation type_consultation, int id)
        {
            if (type_consultation == null)
                throw new ArgumentNullException(nameof(type_consultation));
            else
            {

                Task t = Task.Run(() =>
                {
                    lock (new object())
                    {
                        Type_consultation currentType_consultation = data.Type_consultations.Where(x => x.Id_type_consultation == id).FirstOrDefault();
                        if (currentType_consultation == null)
                            throw new ArgumentNullException(nameof(currentType_consultation));
                        else
                        {
                            currentType_consultation.Type_consultation = type_consultation.Type_consultation;
                            currentType_consultation.Prix_consultation = type_consultation.Prix_consultation;

                            currentType_consultation.Consultation_id = type_consultation.Consultation_id;

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
                    Type_consultation currentType_consultation = data.Type_consultations.Where(x => x.Id_type_consultation == id).FirstOrDefault();

                    if (currentType_consultation == null)
                        throw new ArgumentNullException(nameof(currentType_consultation));
                    else
                    {
                        data.Type_consultations.Remove(currentType_consultation);
                    }
                }
            });

            return true;
        }

        public List<Type_consultation> ListAll()
        {
            Task<List<Type_consultation>> t = Task.Run(new Func<List<Type_consultation>>(() =>
            {
                List<Type_consultation> type_consultations;

                lock (new object())
                {
                    type_consultations = data.Type_consultations.ToList();
                    return type_consultations;
                }
            }));

            return t.Result;
        }
    }
}
