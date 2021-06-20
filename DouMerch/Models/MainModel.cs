using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DouMerch.Models
{
    public class MainModel
    {
        public List<CategoryModel> Categories{ get; set; }
        public List<ProductModel> Products { get; set; }
    }
}