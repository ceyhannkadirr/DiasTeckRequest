using System.ComponentModel.DataAnnotations;

namespace DiasService.Entities
{
    public partial class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}