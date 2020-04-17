using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using Microsoft.SharePoint.Client;

namespace CallAAD_Certificate
{
    public class CertificateAuthentication
    {

       
        public async Task<AuthenticationResult> GetS2SAccessToken(AuthCertModel auth)
        {
            try
            {
                X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                var certificatesCollection = store.Certificates.Find(X509FindType.FindByThumbprint, auth.ThumbPrint, false);
                var builder = ConfidentialClientApplicationBuilder.Create(auth.AppId).WithCertificate(certificatesCollection[0]).WithAuthority(new Uri(auth.Authority), true).Build();
                string[] scopes = new string[] { auth.Url };

                var result = await builder.AcquireTokenForClient(scopes).ExecuteAsync();

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public ClientContext GetSPOnlineContext(string siteUrl, AuthenticationResult token)
        {
 
            try
            {

                ClientContext clientContext = new ClientContext(siteUrl);

                clientContext.ExecutingWebRequest += delegate (object sender, WebRequestEventArgs args)
                {
                    args.WebRequestExecutor.WebRequest.Headers.Add("Authorization", "Bearer " + token.AccessToken);
                };


                return clientContext;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

    }
}
