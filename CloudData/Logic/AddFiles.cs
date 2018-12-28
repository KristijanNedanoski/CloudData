using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CloudData;
using CloudData.Models;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.Entity.Validation;

namespace CloudData.Logic
{
    public class AddFiles
    {
        public bool AddFile(string fName, string OName, string FileDesc, int fSize, string FileLocation, int FileCategory, string Owner)
        {
            var myFile = new Models.File
            {
                FileName = fName,
                OriginalFileName = OName,
                OwnerName = Owner,
                Description = FileDesc,
                FileSize = Convert.ToDouble(fSize),
                FilePath = FileLocation,
                CategoryID = FileCategory
            };

            using (FileContext _db = new FileContext())
            {
                // Add file to DB.
                _db.Files.Add(myFile);
                try
                {
                    _db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    Console.WriteLine(e);
                }
            }
            // Success.
            return true;
        }
    }
}