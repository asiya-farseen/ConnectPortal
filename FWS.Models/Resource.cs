using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FWS.Models
{
    public class Resource
    {
        [Key]
        public int jobId { get; set; }
        [Required]
        [MaxLength(255)]
        public string JobTitle { get; set; }
        [Required]
        [MaxLength(255)]
        public string SkillSet { get; set; }
        [Required]
        
        public int Experience { get; set; }
        [Required]
        public DateTime  StartDateOfJob  { get; set; }
        [Required]
        public DateTime EndDateOfJob { get; set; }
        [Required]
        public int NumberOfResource { get; set;  }


        [ValidateNever]
        [Display(Name = "Customer Name")]
        public int CustomercustId { get; set; }
        public Customer Customer { get; set; }



        [Required]
        [ValidateNever]
        [Display(Name = "Project Name")]

        public int projectId { get; set; }


    }
}
