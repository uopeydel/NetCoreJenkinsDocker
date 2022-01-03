using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreJenkinsDocker.Api.Models
{
    public class SampleDataModel
    {
        [Required]
        [Range(minimum: 2, maximum: 6, ErrorMessage = "The field {0} must be greater than {1} And Lower than {2}.")]
        public int Id { get; set; }

        [Required]
        [Range(minimum:2,maximum: 6,  ErrorMessage = "The field {0} must be greater than {1} And Lower than {2}.")]
        public int Id2 { get; set; }


        [Required]
        [StringLength(20)]
        public string Name { get; set; }
    }
}
