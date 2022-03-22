using Microsoft.AspNetCore.Mvc;
using NerdStoreEnterprise.WebApp.MVC.Models;
using NerdStoreEnterprise.WebApp.MVC.Services;
using System.Threading.Tasks;

namespace NerdStoreEnterprise.WebApp.MVC.Controllers
{
    public class IdentidadeController : Controller
    {
        private readonly IAutenticacaoService _autenticacaoService;

        public IdentidadeController(IAutenticacaoService autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;
        }

        [HttpGet]
        [Route("nova-conta")]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [Route("nova-conta")]
        public async Task<IActionResult> Registro(UsuarioRegistroViewModel usuarioRegistro)
        {
            if (!ModelState.IsValid)
                return View(usuarioRegistro);

            // Comunicar-se com a API para realizar o Registro
            var resposta = await _autenticacaoService.Registro(usuarioRegistro);

            if (false) return View(usuarioRegistro);

            // Caso contrário, realizar o login na APP e redirecionar para algum lugar
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UsuarioLoginViewModel usuarioLogin)
        {
            if (!ModelState.IsValid)
                return View(usuarioLogin);

            // Comunicar-se com a API para realizar o Login
            var resposta = await _autenticacaoService.Login(usuarioLogin);

            if (false) return View(usuarioLogin);

            // Caso contrário, realizar o login na APP e redirecionar para algum lugar
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("sair")]
        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Index", "Home");
        }


    }
}
