using Microsoft.AspNetCore.Mvc;
using System;

namespace ArticleREST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        [HttpPost]
        public ActionResult<bool> GetArticle([FromBody]int id)
        {
            try
            {
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
