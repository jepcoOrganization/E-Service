using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JepcoBackEndSysytemProject.ResourcesFiles.ModelsResources
{
    public class CitiesModelResource
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string LanguageId { get; set; }
    }
}
