using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminPanel.DataBase;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.JwtServices;


namespace AdminPanel.Controllers
{
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]User model, [FromServices]DataContext context)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var user = await context.Users.AsNoTracking().Where( x => x.Username == model.Username && x.Password == model.Password).FirstOrDefaultAsync();
                if (user == null)
                    return NotFound(new { message = "Invalid User or Password..."});
                var token = TokenService.GenerateToken(user);
                user.Password = "";
                return new {
                    user = user,
                    token = token
                }; 
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Could not authenticate. Error: {ex.Message}"});
            }
        }
    }
}

