using System.ComponentModel.DataAnnotations;

namespace DownNotifierWebApi.DataAccess.Entities
{
    public partial class Users : BaseEntity
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}