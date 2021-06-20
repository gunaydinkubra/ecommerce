using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DouMerch.Models
{
    [Table("category")]
    public class CategoryModel
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Imageurl { get; set; }
        public virtual ICollection<ProductModel> Products { get; set; }

    }
}