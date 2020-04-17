using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using File = System.IO.File;
using SharepointFile = Microsoft.SharePoint.Client.File;

namespace CallAAD_Certificate
{
    public static class SharepointOperations
    {


        public static void UploadFileOnSharepoint(ClientContext context)
        {
            string filePath = ConfigurationSettings.AppSettings["FilePath"];

            using (FileStream fileStream = File.OpenRead(filePath))
            {
                String fileName = System.IO.Path.GetFileName(filePath);
                Web web = context.Web;

                context.Load(web);
                context.ExecuteQuery();

                List library = web.Lists.GetByTitle("DocumentiAlessio");

                context.Load(library.RootFolder);
                context.Load(library.RootFolder.Files);
                context.ExecuteQuery();

                FileCreationInformation uploadFile = new FileCreationInformation();
                uploadFile.ContentStream = fileStream;
                uploadFile.Url = fileName;
                uploadFile.Overwrite = true;


                SharepointFile spfile = library.RootFolder.Files.Add(uploadFile);

                library.RootFolder.Update();
                context.ExecuteQuery();
            }


        }







    }
}
