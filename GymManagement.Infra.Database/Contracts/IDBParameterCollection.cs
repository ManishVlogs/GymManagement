using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Infra.Database.Contracts
{
    public interface IDBParameterCollection
    {
        void Add(DBParameter parameter);
        void Remove(DBParameter parameter);
        void RemoveAll();
        void RemoveAt(int index);
    }
}
