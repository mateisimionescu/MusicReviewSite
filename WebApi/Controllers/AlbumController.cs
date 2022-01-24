using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AlbumController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult Create(AlbumArtistHelper newAlbumData)
        {
            List<Artist> MatchedArtists = _unitOfWork.Artists.RowsById(newAlbumData.ArtistIds);

            if (MatchedArtists.Count != newAlbumData.ArtistIds.Count)
                return NotFound("Some artists are non existent!");


            _unitOfWork.Albums.Add(newAlbumData.Album);
            _unitOfWork.Complete();

            foreach (var artist in MatchedArtists)
            {
               AlbumArtist temp = new AlbumArtist
                {
                    ArtistId = artist.Id,
                    AlbumId = newAlbumData.Album.Id,
                    Album = newAlbumData.Album,
                    Artist = artist
                };

                _unitOfWork.AlbumArtists.Add(temp);
            }
            _unitOfWork.Complete();


            return Ok();
        }


    }
}
