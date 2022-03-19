using System;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStoreEnterprise.Identidade.API.Models
{
    public class UsuarioRespostaLoginViewModel
    {
        public string AccessToken { get; set; }
        public double ExpireIn { get; set; }
        public UsuarioTokenViewModel UsuarioToken { get; set; }
    }
}
