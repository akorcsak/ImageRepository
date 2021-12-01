using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OriginalCardGen.Models
{
    public class LoginTable
    {
        [Key]
        public int Id { get; set; }
        public string userEmail { get; set; }

        public string userPass { get; set; }

        public string userRole { get; set; }

        public bool isActive { get; set; }
    }
}