using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CloudData;
using CloudData.Models;
using System.Web.ModelBinding;
using System.Web.Hosting;

namespace CloudData
{
    public partial class FileDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public IQueryable<Models.File> GetFile([QueryString("fileID")] Guid? fileId)
        {
            var _db = new CloudData.Models.FileContext();
            IQueryable<Models.File> query = _db.Files;
            if (fileId.HasValue)
            {
                query = query.Where(p => p.FileID == fileId);
            }
            else
            {
                query = null;
            }
            return query;
        }

        public IQueryable GetCategories()
        {
            var _db = new CloudData.Models.FileContext();
            IQueryable query = _db.Categories;
            return query;
        }

        public IQueryable GetProducts()
        {
            var _db = new CloudData.Models.FileContext();
            IQueryable query = _db.Files;
            return query;
        }

        protected global::System.Web.UI.WebControls.Label LabelRemoveStatus;

        protected void RemoveFileButton_Click(object sender, EventArgs e)
            {
                using (var _db = new CloudData.Models.FileContext())
                {
                    Guid fileId = Guid.Parse(Request.QueryString["FileId"]);
                var myFile = (from c in _db.Files
                                  where c.FileID == fileId
                                  select c).FirstOrDefault();
                    if (myFile != null)
                    {
                    string path = HostingEnvironment.MapPath("~/User/Files/" + myFile.OwnerName + "/");
                    System.IO.File.Delete(path + myFile.FileName);
                    _db.Files.Remove(myFile);
                    _db.SaveChanges();
                        // Reload the page.
                        string pageUrl = Request.Url.AbsoluteUri.Substring(0,
                        Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                        Response.Redirect(pageUrl + "?FileAction=remove");
                        LabelRemoveStatus.Text = "File Removed.";
                }
                    else
                    {
                        LabelRemoveStatus.Text = "Unable to locate file.";
                    }
                }
            }
        
    }
}