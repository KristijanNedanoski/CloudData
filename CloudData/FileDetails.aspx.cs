using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CloudData.Models;
using System.Web.ModelBinding;

namespace CloudData
{
    public partial class FileDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<File> GetFile([QueryString("fileID")] int? fileId)
        {
            var _db = new CloudData.Models.FileContext();
            IQueryable<File> query = _db.Files;
            if (fileId.HasValue && fileId > 0)
            {
                query = query.Where(p => p.FileID == fileId);
            }
            else
            {
                query = null;
            }
            return query;
        }
    }
}