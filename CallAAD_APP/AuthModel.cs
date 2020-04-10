using System.Configuration;


namespace CallAAD_APP
{
    public class AuthModel
    {


        public AuthModel()
        {
            ClientSecret = ConfigurationSettings.AppSettings["ClientSecret"];
            AppId = ConfigurationSettings.AppSettings["AppId"];
            Authority = ConfigurationSettings.AppSettings["Authority"];
            Url = ConfigurationSettings.AppSettings["Url"];
            auth = new Authentication();
        }


        public string ClientSecret { get; set; }
        public string AppId { get; set; }
        public string Authority { get; set; }
        public string Url { get; set; }
        public Authentication auth { get; set; }


    }
}