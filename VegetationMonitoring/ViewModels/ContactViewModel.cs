using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VegetationMonitoring.ViewModels
{
    public class ContactViewModel
    {
        // MVC Model binding to form
        [Required]
        public string Name{ get; set;}
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(4096, MinimumLength = 10)]
        public string Body { get; set; }

    }
}
