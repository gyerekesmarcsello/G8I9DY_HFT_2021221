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
        public IEnumerable<Album> Get()
        {
            return albumLogic.ReadAllAlbums();
        }

        //GET/albums/5
        [HttpGet("{id}")]
        public Album Get (int id)
        {
            return albumLogic.ReadAlbum(id);
        }

        //POST /albums
        [HttpPost]
        public void Post([FromBody] Album albums)
        {
            albumLogic.CreateAlbum(albums.AlbumID, albums.Title, (int)albums.ArtistID, albums.Label, albums.Length, albums.ReleaseDate, albums.Genre);
            this.hub.Clients.All.SendAsync("AlbumCreated", albums);
        }

        [HttpPut]
        public void Put([FromBody] Album albums)
        {
            albumLogic.UpdateAlbum(albums.AlbumID, albums.Title, (int)albums.ArtistID, albums.Label, albums.Length, albums.ReleaseDate, albums.Genre);
            this.hub.Clients.All.SendAsync("AlbumUpdated", albums);
        }

        //DELETE /albums/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var album = albumLogic.ReadAlbum(id);
            albumLogic.DeleteAlbum(id);
            this.hub.Clients.All.SendAsync("AlbumDeleted", album);
        }
    }
}
