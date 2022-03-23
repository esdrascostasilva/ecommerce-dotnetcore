namespace NerdStoreEnterprise.WebApp.MVC.Models
{
    public class ResponseResultError
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public ResponseMessagesError Errors { get; set; }
    }
}
