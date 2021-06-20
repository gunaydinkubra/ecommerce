using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DouMerch.Models
{
    [Table("product")]
    public class ProductModel
    {
        public long Id { get; set; }

        [ForeignKey("Categories")]
        public long CategoryId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Cost { get; set; }

        public virtual CategoryModel Categories { get; set; }
    }
}