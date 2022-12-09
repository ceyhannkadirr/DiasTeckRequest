using System.ComponentModel.DataAnnotations;

namespace DownNotifierWebApi.DataAccess.Entities
{
    public partial class UserUrls : BaseEntity
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}