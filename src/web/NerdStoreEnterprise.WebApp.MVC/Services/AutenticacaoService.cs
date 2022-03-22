using NerdStoreEnterprise.WebApp.MVC.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NerdStoreEnterprise.WebApp.MVC.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly HttpClient _httpClient;

        public AutenticacaoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UsuarioRespostaLogin> Login(UsuarioLoginViewModel usuarioLogin)
        {
            var loginContent = new StringContent(   JsonSerializer.Serialize(usuarioLogin),
                                                    Encoding.UTF8,
                                                    "application/json");

            var response = await _httpClient.PostAsync("http://localhost:18054/api/identidade/login", loginContent);

            var teste = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return JsonSerializer.Deserialize<UsuarioRespostaLogin>(await response.Content.ReadAsStringAsync(), options);
        }

        public async Task<UsuarioRespostaLogin> Registro(UsuarioRegistroViewModel usuarioRegistro)
        {
            var registroContent = new StringContent(JsonSerializer.Serialize(usuarioRegistro),
                                                   Encoding.UTF8,
                                                   "application/json");

            var response = await _httpClient.PostAsync("http://localhost:18054/api/identidade/cadastrar", registroContent);

            return JsonSerializer.Deserialize<UsuarioRespostaLogin>(await response.Content.ReadAsStringAsync());
        }
    }
}
