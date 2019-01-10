using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ValueChain.Models
{
    public class ReportGenerationVm
    {
        [Required]
        public string OrganizationName { get; set; }
    }
}