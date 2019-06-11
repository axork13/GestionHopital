using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHopital.Models.DAO
{
    public interface IDAO<T, ID>
    {
        bool Create(T t);
        T Retrieve(ID id);
        bool Update(T t, ID id);
        List<T> ListAll();
    }
}
