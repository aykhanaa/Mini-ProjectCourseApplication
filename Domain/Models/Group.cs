using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Group:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Capacity { get; set; }
        public int EducationId {  get; set; }
        public Education Education { get; set; }
    }
}
