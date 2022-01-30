using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreJenkinsDocker.Api.Models
{
    public class SampleDataModel
    {
        public SampleDataModel()
        {
            Items = new HashSet<ItemModel>();
        }

        [Key]
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "The field {0} must be greater than {1} And Lower than {2}.")]
        public int Id { get; set; }

        [Required]
        [Range(minimum:0,maximum: 60,  ErrorMessage = "The field {0} must be greater than {1} And Lower than {2}.")]
        public int Age { get; set; }


        [Required]
        [StringLength(20)]
        public string Name { get; set; }


        public HashSet<ItemModel> Items { get; set; }
    }

    public class ItemModel
    {
        [Key]
        [Required] 
        public int Id { get; set; }

        [Required] 
        public int SampleDataId { get; set; }
        public SampleDataModel SampleData { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }
    }


}
