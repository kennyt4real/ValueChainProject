using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValueChain.Models;

namespace ValueChain.Controllers
{
    public class BaseController : Controller
    {
        public ValueChainDbContext _db;

        public BaseController()
        {
            _db = new ValueChainDbContext();
        }

       
    }
}