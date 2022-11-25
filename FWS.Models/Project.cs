using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FWS.Models
{
    public class Project
    {
        [Key]
        public int projId { get; set; }
    
        [Required]
        [MaxLength(200)]

        public string ProjName { get; set; }
        [Required]
        [MaxLength(500)]
        public string description { get; set; }
        [Required]

        public DateTime startDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }


        [Required]
        [ValidateNever]
        public int CustomercustId { get; set; }

        [ValidateNever]
        [Display(Name ="Customer Name")]
        public Customer Customer { get; set; }
        [Required]
        [ValidateNever]
        [Display(Name = "Project Name")]
        public int ProjectManagerpmId { get; set; }
        [ValidateNever]
        public ProjectManager ProjectManager { get; set; }

    }
}
