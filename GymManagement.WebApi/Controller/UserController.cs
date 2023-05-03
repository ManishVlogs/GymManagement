using GymManagement.Application.Interface;
using GymManagement.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.WebApi.Controller
{
    public class UserController : ControllerBase
    {
        private readonly IUserService _IUserService;
        public UserController(IUserService UserService)
        {
            _IUserService = UserService;
        }
        public async Task<List< TestResponse>> TestApi(string var1, string var2)
        {
            try
            {
                var response = await _IUserService.TestInterface( var1, var2);
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
