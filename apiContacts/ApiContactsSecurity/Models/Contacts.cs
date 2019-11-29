using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiContactsSecurity.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Contacts
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        public string Bussines { get; set; }

    }
}