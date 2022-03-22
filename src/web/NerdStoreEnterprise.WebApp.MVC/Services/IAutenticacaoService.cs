using NerdStoreEnterprise.WebApp.MVC.Models;
using System.Threading.Tasks;

namespace NerdStoreEnterprise.WebApp.MVC.Services
{
    public interface IAutenticacaoService
    {
        Task<UsuarioRespostaLogin> Login(UsuarioLoginViewModel usuarioLogin);

        Task<UsuarioRespostaLogin> Registro(UsuarioRegistroViewModel usuarioRegistro);
    }
}
