using System;

namespace DownNotifierWebApi.JWT
{
    public partial class JwtSettings
    {
        public string Secret { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public TimeSpan TokenLifeTime { get; set; }
    }
}