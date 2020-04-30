using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DatingApp.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly DataContext _context;

        public WeatherForecastController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var val =await _context.Values.ToListAsync();

            return Ok(val);
        }


            [AllowAnonymous]
          [HttpGet("{id}")]

          public async Task<IActionResult> GetValue(int id){
              var val =await _context.Values.FirstOrDefaultAsync(x=> x.id == id);
                return Ok(val);
          }

    }
}
