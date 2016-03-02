using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AspNetWebApi.Controllers
{
    [RoutePrefix("multipart")]
    public class MultipartDataController : ApiController
    {
        [Route("post")]
        public async Task<IHttpActionResult> Post()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                return BadRequest();
            }

            var multipartMemoryStreamProvider = await Request.Content.ReadAsMultipartAsync();

            foreach (var content in multipartMemoryStreamProvider.Contents)
            {
                if (content.Headers.ContentDisposition.Name == "model")
                {
                    var model = await content.ReadAsAsync<Model>();
                }

                if (content.Headers.ContentDisposition.Name == "content")
                {
                    var contentBytes = await content.ReadAsByteArrayAsync();
                }
            }

            return Ok("parsed!");
        }

        private class Model
        {
            public string Id { get; set; }

            public string Whatever { get; set; }
        }
    }
}