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
            //Loaction where the file will be storred.
            string fLoc = "User/Files/" + Context.User.Identity.GetUserName() + "/";
            string folderPath = Server.MapPath("~/User/Files/" + Context.User.Identity.GetUserName() + "/");

            //User who uploaded the file and has access to it.
            string ownerName = Context.User.Identity.GetUserName();

            //File original name.
            string originalName = FileUpload1.FileName;

            //Encoded name
            string encodedName = Path.GetRandomFileName();
            encodedName = encodedName.Replace(".", "");
            encodedName = encodedName + Path.GetExtension(FileUpload1.FileName);

            //Figures out what Category the File will belong to.
            int fCat = 0;

            if (Path.GetExtension(FileUpload1.FileName) == ".jpg" || Path.GetExtension(FileUpload1.FileName) == ".JPG" || 
                Path.GetExtension(FileUpload1.FileName) == ".png" || Path.GetExtension(FileUpload1.FileName) == ".PNG" ||
                Path.GetExtension(FileUpload1.FileName) == ".gif" || Path.GetExtension(FileUpload1.FileName) == ".GIF" ||
                Path.GetExtension(FileUpload1.FileName) == ".webp" || Path.GetExtension(FileUpload1.FileName) == ".WEBP")
            {
                fCat = 1;
            }

            else if (Path.GetExtension(FileUpload1.FileName) == ".mp4" || Path.GetExtension(FileUpload1.FileName) == ".MP4" ||
                     Path.GetExtension(FileUpload1.FileName) == ".wmv" || Path.GetExtension(FileUpload1.FileName) == ".WMV" ||
                     Path.GetExtension(FileUpload1.FileName) == ".mpg" || Path.GetExtension(FileUpload1.FileName) == ".MPG" ||
                     Path.GetExtension(FileUpload1.FileName) == ".avi" || Path.GetExtension(FileUpload1.FileName) == ".AVI" ||
                     Path.GetExtension(FileUpload1.FileName) == ".m4v" || Path.GetExtension(FileUpload1.FileName) == ".M4V")
            {
                fCat = 2;
            }

            else if (Path.GetExtension(FileUpload1.FileName) == ".txt" || Path.GetExtension(FileUpload1.FileName) == ".TXT" ||
                     Path.GetExtension(FileUpload1.FileName) == ".pdf" || Path.GetExtension(FileUpload1.FileName) == ".PDF" ||
                     Path.GetExtension(FileUpload1.FileName) == ".doc" || Path.GetExtension(FileUpload1.FileName) == ".DOC" ||
                     Path.GetExtension(FileUpload1.FileName) == ".docx" || Path.GetExtension(FileUpload1.FileName) == ".DOCX" ||
                     Path.GetExtension(FileUpload1.FileName) == ".tex" || Path.GetExtension(FileUpload1.FileName) == ".TEX" ||
                     Path.GetExtension(FileUpload1.FileName) == ".c" || Path.GetExtension(FileUpload1.FileName) == ".C" ||
                     Path.GetExtension(FileUpload1.FileName) == ".java" || Path.GetExtension(FileUpload1.FileName) == ".JAVA" ||
                     Path.GetExtension(FileUpload1.FileName) == ".cpp" || Path.GetExtension(FileUpload1.FileName) == ".CPP" ||
                     Path.GetExtension(FileUpload1.FileName) == ".cs" || Path.GetExtension(FileUpload1.FileName) == ".CS" ||
                     Path.GetExtension(FileUpload1.FileName) == ".class" || Path.GetExtension(FileUpload1.FileName) == ".CLASS")
            {
                fCat = 3;
            }
            else if (Path.GetExtension(FileUpload1.FileName) == ".zip" || Path.GetExtension(FileUpload1.FileName) == ".ZIP" ||
                     Path.GetExtension(FileUpload1.FileName) == ".rar" || Path.GetExtension(FileUpload1.FileName) == ".RAR" ||
                     Path.GetExtension(FileUpload1.FileName) == ".war" || Path.GetExtension(FileUpload1.FileName) == ".WAR" ||
                     Path.GetExtension(FileUpload1.FileName) == ".xar" || Path.GetExtension(FileUpload1.FileName) == ".XAR" ||
                     Path.GetExtension(FileUpload1.FileName) == ".pit" || Path.GetExtension(FileUpload1.FileName) == ".PIT" ||
                     Path.GetExtension(FileUpload1.FileName) == ".dar" || Path.GetExtension(FileUpload1.FileName) == ".DAR")
            {
                fCat = 4;
            }

            else if (Path.GetExtension(FileUpload1.FileName) == ".exe" || Path.GetExtension(FileUpload1.FileName) == ".EXE" ||
                     Path.GetExtension(FileUpload1.FileName) == ".jar" || Path.GetExtension(FileUpload1.FileName) == ".JAR" ||
                     Path.GetExtension(FileUpload1.FileName) == ".wsf" || Path.GetExtension(FileUpload1.FileName) == ".WSF" ||
                     Path.GetExtension(FileUpload1.FileName) == ".bin" || Path.GetExtension(FileUpload1.FileName) == ".BIN" ||
                     Path.GetExtension(FileUpload1.FileName) == ".py" || Path.GetExtension(FileUpload1.FileName) == ".PY")
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
            FileUpload1.SaveAs(folderPath + encodedName);

            //Display the success message.
            lblMessage.Text = Path.GetFileName(FileUpload1.FileName) + " has been uploaded.";

            //Add File info to the Database.
            AddFiles files = new AddFiles();
            files.AddFile(encodedName, originalName, AddFileDescription.Text, FileUpload1.PostedFile.ContentLength, fLoc, fCat, ownerName);
        }
    }
}