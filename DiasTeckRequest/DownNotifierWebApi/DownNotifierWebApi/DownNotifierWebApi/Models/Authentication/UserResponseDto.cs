namespace DownNotifierWebApi.Models.Authentication
{
    public partial class UserResponseDto
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string UserToken { get; set; }
    }
}