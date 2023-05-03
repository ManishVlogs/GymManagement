using GymManagement.Application.Interface;
using GymManagement.Application.Translator;
using GymManagement.Domain.Interface.Repository;
using GymManagement.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;
        public UserService(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }
        public async  Task<List<TestResponse>> TestInterface(string var1, string var2)
        {
            var response =  await _UserRepository.TestInterface(var1, var2);
            if (response == null || response.Rows.Count == 0)
            {
                return default;
            }
            else
            {
               return response.TestInterface();
            }
        }
    }
}
