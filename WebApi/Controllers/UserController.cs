using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private IConfiguration _config;

        public UserController(IUnitOfWork unitOfWork, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _config = config;
        }

        [HttpPost]
        public IActionResult Register(User newUser)
        {
            if(_unitOfWork.Users.Find(x => x.Username == newUser.Username) == null)
            {
                return BadRequest("Already exists!!!!!");
            }
            else
            {
                newUser.Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password);
                _unitOfWork.Users.Add(newUser);
                _unitOfWork.Complete();
                return Ok();
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(User user)
        {
            User tempUser = _unitOfWork.Users.Find(x => x.Username == user.Username)?.FirstOrDefault();

            if (tempUser == null) return BadRequest("User does not exist");

            if (BCrypt.Net.BCrypt.Verify(user.Password, tempUser.Password))
            {
                var tokenString = Helpers.JWTAuth.GenerateJSONWebToken(tempUser, _config);
                return Ok(new { token = tokenString });
            }
            else return BadRequest("Wrong password!");
        }

        [HttpGet]
        public IActionResult GetByID(int id)
        {
            User user = _unitOfWork.Users.GetById(id);
            if (user == null) return NotFound();
            else return Ok(user);
        }

        [HttpDelete]
        [Authorize]
        public IActionResult Delete(int id)
        {
            var isAdmin = "false";
            if (HttpContext.User.HasClaim(c => c.Type == "isAdmin"))
            {
                isAdmin = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "isAdmin").Value;
            }
            if (isAdmin == "false")
                return BadRequest("User is not admin!");
             
            User user = _unitOfWork.Users.GetById(id);
            if (user == null) return NotFound();
            _unitOfWork.Users.Remove(user);
            _unitOfWork.Complete();
            return Ok("User " + user.Username + " removed!");
        }
    }
}
