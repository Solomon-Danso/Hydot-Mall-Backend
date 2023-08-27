using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hydot_Mall_Backend_v1.Data;
using Microsoft.AspNetCore.Mvc;

namespace Hydot_Mall_Backend_v1.Commanders
{
    [ApiController]
    [Route("api/[controller]")]
    public class Authentication : ControllerBase
    {
        private readonly DataContext context;
        public Authentication(DataContext ctx){
            context = ctx;
        }

        
    }
}