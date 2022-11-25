using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FWS.Models
{
    public class ProjectManager
    {
        [Key]
        public int pmId { get; set; }

        [Required]
        [MaxLength(100)]
      
        public String ManagerName { get; set; }

        [Required]
        [MaxLength(100)]

       

        public String pmPhone { get; set; }
        [Required]
        [MaxLength(100)]

        public String pmEmail { get; set; }


        [Required]
        [MaxLength(100)]


        public String pmAddress { get; set; }
        [Required]
        [MaxLength(100)]
        public String pmPinCode { get; set; }
        [Required]
        [MaxLength(100)]


        public String pmPassword { get; set; }
    }
}



