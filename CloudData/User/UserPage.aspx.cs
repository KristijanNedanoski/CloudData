using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CloudData.Logic;
using System.Text;
using System.Web.UI.WebControls.WebParts;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace CloudData.User
{
    public partial class UserPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void UploadFile(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            string fLoc = "~/User/Files/" + Context.User.Identity.GetUserName() + "/";
            string folderPath = Server.MapPath(fLoc);

            //Check whether Directory (Folder) exists.
            if (!Directory.Exists(folderPath))
            {
                //If Directory (Folder) does not exists. Create it.
                Directory.CreateDirectory(folderPath);
            }

            //Save the File to the Directory (Folder).
            FileUpload1.SaveAs(folderPath + Path.GetFileName(FileUpload1.FileName));

            //Display the success message.
            lblMessage.Text = Path.GetFileName(FileUpload1.FileName) + " has been uploaded.";

            AddFiles files = new AddFiles();
            files.AddFile(FileUpload1.FileName, AddFileDescription.Text, FileUpload1.PostedFile.ContentLength, folderPath);
        }
    }
}