using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CloudData.Logic;
using CloudData.Models;
using System.Text;
using System.Web.UI.WebControls.WebParts;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web.Hosting;

namespace CloudData
{
    public class DownloadFile : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                Guid fileId = Guid.Parse(context.Request.QueryString["file"]);
                var _db = new CloudData.Models.FileContext();
                var myItem = (from c in _db.Files
                          where c.FileID == fileId
                          select c).FirstOrDefault();
                string serverFilename = myItem.FileName;
                string filename = myItem.OriginalFileName;
                string folder = myItem.OwnerName;

                string path = context.Server.MapPath("~/User/Files/" + folder + "/" + serverFilename);

                context.Response.Clear();
                context.Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                //context.Response.ContentType = "image/png";
                context.Response.TransmitFile(path);
                context.Response.End();
            }
            catch (System.ArgumentNullException e)
            {
                Console.WriteLine(e);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}