using G8I9DY_HFT_2021221.Logic;
using G8I9DY_HFT_2021221.Endpoint;
using G8I9DY_HFT_2021221.Models;
using Microsoft.AspNetCore.SignalR;
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
        IHubContext<SignalRHub> hub;

        public AlbumController(IAlbumLogic albumLogic, IHubContext<SignalRHub> hub)
        {
            this.albumLogic = albumLogic;
            this.hub = hub;
        }

        [HttpGet]
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
        public void Post([FromBody] Albums albums)
        {
            albumLogic.CreateAlbum(albums.AlbumID, albums.Title, albums.ArtistID, albums.Label, albums.Length, albums.ReleaseDate, albums.Genre);
            this.hub.Clients.All.SendAsync("AlbumCreated", albums);
        }

        [HttpPut]
        public void Put([FromBody] Albums albums)
        {
            albumLogic.UpdateAlbum(albums.AlbumID, albums.Title, albums.ArtistID, albums.Label, albums.Length, albums.ReleaseDate, albums.Genre);
            this.hub.Clients.All.SendAsync("PostUpdated", albums);
        }

        //DELETE /albums/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var album = albumLogic.ReadAlbum(id);
            albumLogic.DeleteAlbum(id);
            this.hub.Clients.All.SendAsync("PostDeleted", album);
        }
    }
}
