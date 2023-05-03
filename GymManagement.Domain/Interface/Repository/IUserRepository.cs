using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Domain.Interface.Repository
{
    public interface IUserRepository
    {
        Task<DataTable> TestInterface(string var1, string var2);
    }
}
