using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OriginalCardGen.Models
{
    public class AccountTable
    {
        [Key]
        public int Id { get; set; }

        public string userEmail { get; set; }

        public string userPass { get; set; }

    }
}