using GymManagement.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Interface
{
    public interface IUserService
    {
        Task<List<TestResponse>> TestInterface(string var1, string var2);
        Task<List<TestResponse1>> TestInterface2(string var1, string var2);

    }
}
