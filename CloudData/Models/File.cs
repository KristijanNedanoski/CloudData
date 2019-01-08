using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudData.Models
{
    public class File
    {
        [ScaffoldColumn(false)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid FileID { get; set; }
        [Required, StringLength(100), Display(Name = "Name")]
        public string FileName { get; set; }
        [Required, StringLength(100), Display(Name = "Original Name")]
        public string OriginalFileName { get; set; }
        [Required, StringLength(100), Display(Name = "Owner")]
        public string OwnerName { get; set; }
        [StringLength(10000), Display(Name = "File Description"),
        DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string FilePath { get; set; }
        [Display(Name = "Size")]
        public double? FileSize { get; set; }
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}