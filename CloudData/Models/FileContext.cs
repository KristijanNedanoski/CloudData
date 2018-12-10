using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CloudData.Models
{
    public class FileContext : DbContext
    {
        public FileContext() : base("CloudData")
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<File> Files { get; set; }
    }
}