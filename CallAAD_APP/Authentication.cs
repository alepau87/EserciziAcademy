using Microsoft.Identity.Client;
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


    }
}
