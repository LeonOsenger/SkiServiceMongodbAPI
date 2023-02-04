using Microsoft.AspNetCore.Mvc;
using SkiServiceMongodbAPI.DTO;
using SkiServiceMongodbAPI.Services;

namespace SkiServiceMongodbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MitarbeiterLoginController : ControllerBase
    {
        private readonly MitarbeiterLoginService _mitarbeiterLoginService;

        public MitarbeiterLoginController(MitarbeiterLoginService MitarbeiterLoginService)
        {
            _mitarbeiterLoginService = MitarbeiterLoginService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO UserData)
        {
            bool login = _mitarbeiterLoginService.CheckUser(UserData.BenutzerName, UserData.BenutzerPasswort);

            if (login)
                return new JsonResult(new { userName = UserData.BenutzerName, token = _mitarbeiterLoginService.CreateToken(UserData.BenutzerName) });
            else
                return Unauthorized("Invalid Credentials");

        }
    }
}