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
        static void Main(string[] args)
        {
            AuthModel authModel = new AuthModel();

            var access = Authentication.GetS2SAccessToken(authModel);

            var token = access.Result.AccessToken;

            ClientContext context = Authentication.GetSPOnlineContext("https://m365x013432.sharepoint.com/sites/ContosoWeb1", token);

            SharepointOperations.UploadFileOnSharepoint(context);
        }
    }
}
