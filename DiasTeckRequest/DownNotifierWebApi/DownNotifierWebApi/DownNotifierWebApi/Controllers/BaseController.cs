using DownNotifierWebApi.DataAccess.Contexts;
using DownNotifierWebApi.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DownNotifierWebApi.Controllers
{
    [Route("[controller]/[action]")]
    public class BaseController<TEntity> : ControllerBase
        where TEntity : BaseEntity, new()
    {
        public ApplicationDbContext Context { get; set; }

        public BaseController(ApplicationDbContext context)
        {
            this.Context = context;
        }

        [HttpGet]
        public IActionResult GetById(long id)
        {
            try
            {
                return Ok(Context.Set<TEntity>().FirstOrDefault(x => x.Id == id));
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public virtual IActionResult Add([FromBody] TEntity entity)//TODO jobject olarak gönderiyoruz ama test edemedik çünkü hata var: MSB4181
        {
            try
            {
                Context.Set<TEntity>().Add(entity);
                Context.SaveChanges();

                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(500, "internal server error");
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] TEntity entity)//TODO jobject ile gönderilecek
        {
            try
            {
                Context.Set<TEntity>().Update(entity);
                Context.SaveChanges();

                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(500, "internal server error");
            }
        }

        [HttpDelete]
        public IActionResult Delete(long id)
        {
            try
            {
                var data = Context.Set<TEntity>().FirstOrDefault(x => x.Id == id);

                Context.Set<TEntity>().Remove(data);
                Context.SaveChanges();

                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(500, "internal server error");
            }

        }

        [HttpGet]
        public IActionResult GetList()
        {
            try
            {
                return Ok(Context.Set<TEntity>().ToList());
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }
    }
}