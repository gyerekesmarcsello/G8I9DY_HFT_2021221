using G8I9DY_HFT_2021221.Logic;
using G8I9DY_HFT_2021221.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace G8I9DY_HFT_2021221.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        IAlbumLogic albumLogic;

        public AlbumController(IAlbumLogic albumLogic)
        {
            this.albumLogic = albumLogic;
        }

        //GET:/albums
        public IEnumerable<Albums> Get()
        {
            return albumLogic.ReadAllAlbums();
        }

        //GET/albums/5
        [HttpGet("{id}")]
        public Albums Get (int id)
        {
            return albumLogic.ReadAlbum(id);
        }

        //POST /albums
        [HttpPost]
        public void Post([FromBody] int albumID, string Title, int ArtistID, string Label, TimeSpan length, DateTime releasedate, string Genre)
        {
            albumLogic.CreateAlbum(albumID, Title, ArtistID, Label, length, releasedate, Genre);
        }

        //DELETE /albums/5
        [HttpGet("{id}")]
        public void Delete(int id)
        {
            albumLogic.DeleteAlbum(id);
        }
    }
}
