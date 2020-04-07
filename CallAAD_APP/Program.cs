using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallAAD_APP
{
    class Program
    {
        static void Main(string[] args)
        {
            AuthModel authModel = new AuthModel();

            var access = Authentication.GetS2SAccessToken(authModel);

           var token = access.Result.AccessToken;
        }
    }
}
