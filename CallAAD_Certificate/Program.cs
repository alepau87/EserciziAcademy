using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;

namespace CallAAD_Certificate
{
    class Program
    {
        static async Task Main(string[] args)
        {

            AuthCertModel authModel = new AuthCertModel();

            var access = authModel.auth.GetS2SAccessToken(authModel);

            ClientContext ctx = authModel.auth.GetSPOnlineContext("https://m365x013432.sharepoint.com/", access.Result);

            SharepointOperations.UploadFileOnSharepoint(ctx);
        }
    }
}
