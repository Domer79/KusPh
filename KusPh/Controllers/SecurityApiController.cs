using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
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
