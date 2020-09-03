using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Musical.Entity.Models;
using Musical.Services;
using musicalog_api.Model;
using System;

namespace musicalog_api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/Albums")]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;
        private readonly IMapper _mapper;
        AlbumController(IAlbumService albumService,
            IMapper mapper)
        {
            _albumService = albumService ?? throw new ArgumentException("albumService");
            _mapper = mapper ?? throw new ArgumentException("mapper");
        }
        // GET: api/Albums
        [HttpGet]
        public IActionResult Get()
        {
            var albums = _albumService.GetAllAlbums();
            if (albums == null) return NotFound(new BaseResponse
            {
                IsSuccess = false,
                Message = "No albums found"
            });
            return Ok(new BaseResponse()
            {
                IsSuccess = true,
                Result = albums
            });
        }

        // GET: api/Albums/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int? id)
        {
            if (!id.HasValue) return BadRequest(new BaseResponse
            {
                IsSuccess = false,
                Message = "Bad request"
            });
            var album = _albumService.GetAlbum(id.Value);
            if (album == null) return NotFound(new BaseResponse
            {
                Message = $"{id.Value} Album not found for id {id.Value}"
            });

            return Ok(new BaseResponse()
            {
                IsSuccess = true,
                Result = album
            });
        }

        // POST: api/Albums
        [HttpPost]
        public IActionResult Post([FromBody]AlbumRequest albumRequest)
        {
            if (albumRequest == null) return BadRequest(new BaseResponse()
            {
                Message = "Bad request",
                IsSuccess = false
            });
            var album = _mapper.Map<Album>(albumRequest);
            try
            {
                _albumService.CreateAlbum(album);
                return Ok(new BaseResponse
                {
                    IsSuccess = true,
                    Result = album,
                    Message = "Album created"
                });
            }
            catch(Exception)
            {
                return BadRequest(new BaseResponse
                {
                    Message = "Error occured",
                    IsSuccess = false
                });
            }
        }

        // PUT: api/Albums/5
        [HttpPut("{id}")]
        public IActionResult Put(int? id, [FromBody]AlbumRequest newAlbum)
        {
            if (!id.HasValue) return BadRequest(new BaseResponse()
            {
                IsSuccess = false,
                Message = "Bad request"
            });

            newAlbum.Id = id.Value;
            var album = _mapper.Map<Album>(newAlbum);
            try
            {
                _albumService.UpdateAlbum(album);
                return Ok(new BaseResponse
                {
                    IsSuccess = true,
                    Result = album,
                    Message = "Album updated"
                });
            }
            catch (Exception)
            {
                return BadRequest(new BaseResponse
                {
                    Message = "Error occured",
                    IsSuccess = false
                });
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue) return BadRequest(new BaseResponse
            {
                IsSuccess = false,
                Message = "Bad request"
            });
            try
            {
                _albumService.DeleteAlbum(id.Value);
                return Ok(new BaseResponse
                {
                    IsSuccess = true,
                    Message = "Album created"
                });
            }
            catch (Exception)
            {
                return BadRequest(new BaseResponse
                {
                    Message = "Error occured",
                    IsSuccess = false
                });
            }
        }
    }
}
