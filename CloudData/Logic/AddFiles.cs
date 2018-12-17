using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CloudData.Models;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace CloudData.Logic
{
    public class AddFiles
    {
        public bool AddFile(string FileName, string FileDesc, int FileSize, string FileLocation)
        {
            var myFile = new Models.File();
            myFile.FileName = FileName;
            myFile.Description = FileDesc;
            myFile.FileSize = Convert.ToDouble(FileSize);
            myFile.FilePath = FileLocation;
            using (FileContext _db = new FileContext())
            {
                // Add product to DB.
                _db.Files.Add(myFile);
                _db.SaveChanges();
            }
            return true;
        }
    }
}