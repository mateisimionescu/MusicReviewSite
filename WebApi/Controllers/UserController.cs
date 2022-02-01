using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

        [HttpPost]
        public IActionResult Login(User user)
        {
            User tempUser = _unitOfWork.Users.Find(x => x.Username == user.Username)?.FirstOrDefault();

            if (tempUser == null) return BadRequest("User does not exist");

            if (BCrypt.Net.BCrypt.Verify(user.Password, tempUser.Password))
            {
                return Ok("Login succesful!");
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
        public IActionResult Delete(int id)
        {
            User user = _unitOfWork.Users.GetById(id);
            if (user == null) return NotFound();
            _unitOfWork.Users.Remove(user);
            _unitOfWork.Complete();
            return Ok("User " + user.Username + " removed!");
        }
    }
}
