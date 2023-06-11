using GymManagement.Application.Interface;
using GymManagement.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.WebApi.Controller
{
    [Route("api/v{version:apiVersion}/User")]
    [ApiVersion("1")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _IUserService;
        public UserController(IUserService UserService)
        {
            _IUserService = UserService;
        }

        [HttpGet]
        [Route("GetTestApi")]
        public async Task<List<TestResponse>> GetTestApi(string var1, string var2)
        {
            try
            {
                var response = await _IUserService.TestInterface(var1, var2);
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("GetTestApi2")]
        public async Task<List<TestResponse1>> GetTestApi2(string var1, string var2)
        {
            try
            {
                var response = await _IUserService.TestInterface2(var1, var2);
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
