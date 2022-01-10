using System.ComponentModel.DataAnnotations;

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