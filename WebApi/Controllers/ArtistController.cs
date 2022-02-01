using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ArtistController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /*public IActionResult GetPopularDevelopers([FromQuery] int count)
        {
            var popularDevelopers = _unitOfWork.Developers.GetPopularDevelopers(count);
            return Ok(popularDevelopers);
        }*/

        [HttpPost]
        public IActionResult Create(Artist artist)
        {
            if (_unitOfWork.Artists.ArtistExists(artist.Name))
                return BadRequest("Already exists!!!!!");
            else
            {
                _unitOfWork.Artists.Add(artist);
                _unitOfWork.Complete();
                return Ok();
            }
        }

        [HttpDelete]
        [Authorize]
        public IActionResult Delete(int id)
        {
            if (_unitOfWork.Artists.ArtistExists(id))
                return NotFound();
            else
            {
                _unitOfWork.Artists.RemoveById(id);
                _unitOfWork.Complete();
                return Ok(" {'deleted' : 'true' ");
            }

        }

        [HttpGet]
        public IActionResult GetAllArtists()
        {
            var Artists = _unitOfWork.Artists.GetAll();
            _unitOfWork.Complete();
            return Ok(Artists);
        }

        [Authorize]
        [HttpPut]
        public IActionResult Update(int id, Artist newArtist)
        {
            var old = _unitOfWork.Artists.GetById(id);
            if (old == null) return NotFound();
            else
            {
                old.Name = newArtist.Name;
                old.Description = newArtist.Description;
                _unitOfWork.Complete();
                return Ok(old.Id);
            }
        }
    }

}
