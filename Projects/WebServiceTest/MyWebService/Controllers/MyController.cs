﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MyWebService.Controllers
{
    public class MyController : ApiController
    {
        public IHttpActionResult Get()
        {
            return this.Ok("Pesho");
        }
    }
}