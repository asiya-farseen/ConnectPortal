using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FWS.Models.ViewModels
{
   
   
        public class ResourceVM
        {
            public Resource Resource { get; set; }
            [ValidateNever]
            public IEnumerable<SelectListItem> CustomerList { get; set; }
            [ValidateNever]
            public IEnumerable<SelectListItem> ProjectList { get; set; }






        }
    }
