using G8I9DY_HFT_2021221.Models;
using G8I9DY_HFT_2021221.Endpoint;
using Microsoft.AspNetCore.SignalR;
using G8I9DY_HFT_2021221.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace G8I9DY_HFT_2021221.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        IArtistLogic artistLogic;
        IHubContext<SignalRHub> hub;

        public ArtistController(IArtistLogic artistLogic, IHubContext<SignalRHub> hub)
        {
            this.artistLogic = artistLogic;
            this.hub = hub;
        }

        [HttpGet]
        //GET:/artists
        public IEnumerable<Artists> Get()
        {
            return artistLogic.ReadAllArtist();
        }

        //GET/artists/5
        [HttpGet("{id}")]
        public Artists Get(int id)
        {
            return artistLogic.ReadArtist(id);
        }

        //POST /artists
        [HttpPost]
        public void Post([FromBody] Artists artists)
        {
            artistLogic.CreateArtist(artists.ArtistID, artists.Name, artists.Birthday, artists.Nationality, artists.GrammyWinner);
            this.hub.Clients.All.SendAsync("ArtistCreated", artists);
        }
        [HttpPut]
        public void Put([FromBody] Artists artists)
        {
            artistLogic.UpdateArtist(artists.ArtistID, artists.Name, artists.Birthday, artists.Nationality, artists.GrammyWinner);
            this.hub.Clients.All.SendAsync("ArtistUpdated", artists);
        }

        //DELETE /artists/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var ArtistToDelete = this.artistLogic.ReadArtist(id);
            artistLogic.DeleteArtist(id);
            this.hub.Clients.All.SendAsync("ArtistDeleted", ArtistToDelete);
        }
    }
}
