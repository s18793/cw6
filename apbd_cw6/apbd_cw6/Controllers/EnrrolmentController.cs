using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace apbd_cw6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrrolmentController : ControllerBase
    {

        public IConfiguration Configuration { get; set; }
        public EnrrolmentController(IConfiguration configuration)
        {
            Configuration = configuration;
        }




    }
}