using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;

namespace CallAAD_APP
{
    class Program
    {
        static async Task Main(string[] args)
        {
            AuthModel authModel = new AuthModel();

            var access = await authModel.auth.GetS2SAccessToken(authModel);

            authModel.auth.GetSPOnlineContext("https://m365x013432.sharepoint.com/", access);
            
        }
    }
}
