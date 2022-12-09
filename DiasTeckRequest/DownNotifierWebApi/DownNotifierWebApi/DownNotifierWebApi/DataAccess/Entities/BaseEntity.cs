using System.ComponentModel.DataAnnotations;

namespace DownNotifierWebApi.DataAccess.Entities
{
    public partial class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}