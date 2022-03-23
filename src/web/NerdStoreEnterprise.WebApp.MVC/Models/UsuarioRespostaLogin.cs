namespace NerdStoreEnterprise.WebApp.MVC.Models
{
    public class UsuarioRespostaLogin
    {
        public string AccessToken { get; set; }
        public double ExpireIn { get; set; }
        public UsuarioToken UsuarioToken { get; set; }
        public ResponseResultError ResponseResult { get; set; }
    }
}
