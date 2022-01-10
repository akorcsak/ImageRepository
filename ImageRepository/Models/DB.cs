using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace OriginalCardGen.Models
{
    public class DB : DbContext
    {
        public DB() : base("DefaultConnection")
        {
        }

        public DbSet<AccountTable> AccountTables { get; set; }
    }
}
