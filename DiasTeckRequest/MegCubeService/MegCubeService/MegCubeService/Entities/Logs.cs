using System;

namespace DiasService.Entities
{
    public partial class Logs : BaseEntity
    {
        public string Url { get; set; }
        public string Status { get; set; }
        public string Value { get; set; }
        public DateTime StoreDate { get; set; }
    }
}