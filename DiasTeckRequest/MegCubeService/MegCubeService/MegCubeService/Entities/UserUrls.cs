using System.ComponentModel.DataAnnotations;

namespace DiasService.Entities
{
    public partial class UserUrls : BaseEntity
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}