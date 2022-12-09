using DownNotifierWebApi.DataAccess.Contexts;
using DownNotifierWebApi.DataAccess.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DownNotifierWebApi.Controllers
{
    public class UsersController : BaseController<Users>
    {
        public UsersController(ApplicationDbContext context) : base(context)
        {
        }

        public override IActionResult Add([FromBody] Users entity)
        {
            return base.Add(entity);
        }

    }
}