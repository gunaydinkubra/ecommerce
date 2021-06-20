using DouMerch.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DouMerch.Models
{
    [Table("users")]
    public class UsersModel
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please enter your username")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }

        public UserTypeEnum UserType { get; set; }
        public virtual ICollection<OrderModel> Orders { get; set; }

    }
}