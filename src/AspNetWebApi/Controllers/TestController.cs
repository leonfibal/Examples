using System.Web.Http;

namespace AspNetWebApi.Controllers
{
    [RoutePrefix("test")]
    public class TestController : ApiController
    {
        [Route("get")]
        public IHttpActionResult Get()
        {
            return Ok("testowane");
        }
    }
}