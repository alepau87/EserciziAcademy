using System.Configuration;


namespace CallAAD_Certificate
{
    public class AuthCertModel
    {


        public AuthCertModel()
        {
            ThumbPrint = ConfigurationSettings.AppSettings["ThumbPrint"];
            AppId = ConfigurationSettings.AppSettings["AppId"];
            Authority = ConfigurationSettings.AppSettings["Authority"];
            Url = ConfigurationSettings.AppSettings["Url"];
            auth = new CertificateAuthentication();
        }


        public string ThumbPrint { get; set; }
        public string AppId { get; set; }
        public string Authority { get; set; }
        public string Url { get; set; }
        public CertificateAuthentication auth { get; set; }


    }
}