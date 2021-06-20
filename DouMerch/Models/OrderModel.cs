using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DouMerch.Models
{
    [Table("order")]
    public class OrderModel
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey("Users")]
        public long UserId { get; set; }
        public string Address { get; set; }
        [ForeignKey("Products")]
        public long ProductId { get; set; }

        public virtual UsersModel Users { get; set; }
        public virtual ProductModel Products { get; set; }

    }
}