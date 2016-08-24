using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KompaniInfo.Models;
using KompaniInfo.Repositories.Interfaces;

namespace KompaniInfo.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostRepository _context;

        public PostsController(IPostRepository context)
        {
            _context = context;    
        }



    }
}
