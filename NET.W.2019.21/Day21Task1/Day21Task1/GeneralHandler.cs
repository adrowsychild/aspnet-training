﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day21Tasks
{
    public class GeneralHandler : IHttpHandler
    {
        public bool IsReusable { get { return false; } }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write(context);
        }
    }
}