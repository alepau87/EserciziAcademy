using Microsoft.Identity.Client;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallAAD_APP
{
    public class Authentication
    {

       
        public static async Task<AuthenticationResult> GetS2SAccessToken(AuthModel auth)
        {
            try
            {
                var builder = ConfidentialClientApplicationBuilder.Create(auth.AppId).WithClientSecret(auth.ClientSecret)
                                                  .WithAuthority(new Uri(auth.Authority))
                                                  .Build();
                string[] scopes = new string[] { auth.Url };

                var result = await builder.AcquireTokenForClient(scopes).ExecuteAsync();

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public static ClientContext GetSPOnlineContext(string siteUrl, string token)
        {
 
            try
            {
               
                ClientContext clientContext = new ClientContext(siteUrl);
                clientContext.ExecutingWebRequest += delegate (object sender, WebRequestEventArgs args)
                {
                    args.WebRequestExecutor.WebRequest.Headers.Add("Authorization", "Bearer " + token);
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
