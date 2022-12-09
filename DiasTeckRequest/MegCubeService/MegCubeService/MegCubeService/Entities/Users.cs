using System.ComponentModel.DataAnnotations;

namespace DiasService.Entities
{
    public partial class Users : BaseEntity
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}