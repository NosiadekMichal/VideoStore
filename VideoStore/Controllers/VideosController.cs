using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using VideoStore.Core;

namespace VideoStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideosController : ControllerBase
    {
        private readonly IVideoServices _videoServices;

        public VideosController(IVideoServices videoServices)
        {
            _videoServices = videoServices;
          
        }

        [HttpGet]
        public IActionResult GetVideos()
        {
            return Ok(_videoServices.GetVideos());
        }

        [HttpGet("{id}", Name ="GetVideo")]
        public IActionResult GetVideo(string id )
        {
            return Ok(_videoServices.GetVideo(id));
        }

        [HttpPost]
        public IActionResult AddVideo(Video video)
        {
            video.Id = ObjectId.GenerateNewId().ToString();
            _videoServices.AddVideo(video);
            return CreatedAtRoute("GetVideo", new { id = video.Id }, video);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(string id)
        {
            _videoServices.DeleteVideo(id);
            return NoContent();
        }
        [HttpPut]
        public IActionResult UpdateVideo(Video video)
        {
            return Ok(_videoServices.UpdateVideo(video));
        }
    }
}
