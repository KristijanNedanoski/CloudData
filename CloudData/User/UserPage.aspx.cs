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
            string fLoc = "~/User/Files/" + Context.User.Identity.GetUserName() + "/";
            string folderPath = Server.MapPath(fLoc);

            int fCat = 0;

            if (Path.GetExtension(FileUpload1.FileName) == ".jpg" || Path.GetExtension(FileUpload1.FileName) == ".png" || Path.GetExtension(FileUpload1.FileName) == ".gif"
                || Path.GetExtension(FileUpload1.FileName) == ".webp")
            {
                fCat = 1;
            }
            else if (Path.GetExtension(FileUpload1.FileName) == ".txt" || Path.GetExtension(FileUpload1.FileName) == ".pdf" || Path.GetExtension(FileUpload1.FileName) == ".doc"
                  || Path.GetExtension(FileUpload1.FileName) == ".docx" || Path.GetExtension(FileUpload1.FileName) == ".tex" || Path.GetExtension(FileUpload1.FileName) == ".c"
                  || Path.GetExtension(FileUpload1.FileName) == ".java" || Path.GetExtension(FileUpload1.FileName) == ".cpp" || Path.GetExtension(FileUpload1.FileName) == ".cs"
                  || Path.GetExtension(FileUpload1.FileName) == ".class")
            {
                fCat = 3;
            }
            else if (Path.GetExtension(FileUpload1.FileName) == ".mp4" || Path.GetExtension(FileUpload1.FileName) == ".wmv" || Path.GetExtension(FileUpload1.FileName) == ".mpg"
                 || Path.GetExtension(FileUpload1.FileName) == ".avi" || Path.GetExtension(FileUpload1.FileName) == ".m4v")
            {
                fCat = 2;
            }

            else if (Path.GetExtension(FileUpload1.FileName) == ".zip" || Path.GetExtension(FileUpload1.FileName) == ".rar" || Path.GetExtension(FileUpload1.FileName) == ".war" ||
                     Path.GetExtension(FileUpload1.FileName) == ".xar" || Path.GetExtension(FileUpload1.FileName) == ".pit" || Path.GetExtension(FileUpload1.FileName) == ".dar")
            {
                fCat = 4;
            }

            else if (Path.GetExtension(FileUpload1.FileName) == ".exe" || Path.GetExtension(FileUpload1.FileName) == ".jar" || Path.GetExtension(FileUpload1.FileName) == ".wsf"
                || Path.GetExtension(FileUpload1.FileName) == ".bin" || Path.GetExtension(FileUpload1.FileName) == ".py")
            {
                fCat = 5;
            }
            else 
            {
                fCat = 6;
            }

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
            files.AddFile(FileUpload1.FileName, AddFileDescription.Text, FileUpload1.PostedFile.ContentLength, folderPath, fCat);
        }
    }
}