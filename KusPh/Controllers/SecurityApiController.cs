using System.Web.Http;
using KusPh.Data;

namespace KusPh.Controllers
{
    public class SecurityApiController : ApiController
    {
//        [System.Web.Http.Route("api/SecurityApi/GetLastError")]
        public IHttpActionResult PostLastError()
        {
            return Ok(Tools.GetLastError());
        }
    }
}
