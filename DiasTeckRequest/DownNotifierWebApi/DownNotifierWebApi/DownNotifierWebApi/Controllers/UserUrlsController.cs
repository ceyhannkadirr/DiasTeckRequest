using DownNotifierWebApi.DataAccess.Contexts;
using DownNotifierWebApi.DataAccess.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DownNotifierWebApi.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserUrlsController : BaseController<UserUrls>
    {
        public UserUrlsController(ApplicationDbContext context) : base(context)
        {
        }

        public override IActionResult Add([FromBody] UserUrls entity)
        {
            return base.Add(entity);
        }
    }
}