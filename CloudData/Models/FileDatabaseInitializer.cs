using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CloudData.Models
{
    public class FileDatabaseInitializer :
DropCreateDatabaseAlways<FileContext>
    {
        protected override void Seed(FileContext context)
        {
            GetCategories().ForEach(c => context.Categories.Add(c));
            GetFiles().ForEach(p => context.Files.Add(p));
        }

        private static List<Category> GetCategories()
        {
            var categories = new List<Category> {
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Images"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Videos"
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "Text Files"
                },
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "Archives"
                },
                new Category
                {
                    CategoryID = 5,
                    CategoryName = "Executables"
                },
                new Category
                {
                    CategoryID = 6,
                    CategoryName = "Other"
                },
            };
            return categories;
        }

        private static List<File> GetFiles()
        {
            var files = new List<File>
            {
            };
            return files;
        }
    }
}