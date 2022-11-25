
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace FWS.Models
{
    public class Customer
    {
        [Key]
        public int custId { get; set; }

        [Required]
        [DisplayName("Customer Name")]

        public string CustName { get; set; }

        [Required]
        public string Address { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public long Mobile { get; set; }

    }
}
