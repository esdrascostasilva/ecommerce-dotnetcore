using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NerdStoreEnterprise.Identidade.API.Models;
using System.Threading.Tasks;

namespace NerdStoreEnterprise.Identidade.API.Controllers
{
    [ApiController]
    [Route("api/identidade")]
    public class AuthController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public string Get()
        {
            return ("Ok");
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult> CadastrarUsuario(UsuarioCadastroViewModel usuarioCadastro)
        {
            // Validar se a model esta ok
            if (!ModelState.IsValid)
                return BadRequest();

            // criar uma instancia de IdentityUser
            var user = new IdentityUser
            {
                UserName = usuarioCadastro.Email,
                Email = usuarioCadastro.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, usuarioCadastro.Senha);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return  Ok();
            }

            return BadRequest();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UsuarioLoginViewModel usuarioLogin)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _signInManager.PasswordSignInAsync(usuarioLogin.Email, usuarioLogin.Senha, false, true);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest();
        }

    }
}
