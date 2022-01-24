using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeveloperController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /*public IActionResult GetPopularDevelopers([FromQuery] int count)
        {
            var popularDevelopers = _unitOfWork.Developers.GetPopularDevelopers(count);
            return Ok(popularDevelopers);
        }*/

        [HttpPost]
        public IActionResult AddDeveloperAndProject()
        {
            var artist = new Artist
            {
                Name = "deadmau5",
                Description = "It's cool"
            };
            _unitOfWork.Artists.Add(artist);
            _unitOfWork.Complete();
            return Ok();
        }
    }

}
