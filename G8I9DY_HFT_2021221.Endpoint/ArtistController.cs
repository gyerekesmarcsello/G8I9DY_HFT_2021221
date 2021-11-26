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
    public class ArtistController : ControllerBase
    {
        IArtistLogic artistLogic;

        public ArtistController(IArtistLogic artistLogic)
        {
            this.artistLogic = artistLogic;
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
        }
        [HttpPut]
        public void Put([FromBody] Artists artists)
        {
            artistLogic.UpdateArtist(artists.ArtistID, artists.Name, artists.Birthday, artists.Nationality, artists.GrammyWinner);
        }

        //DELETE /artists/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            artistLogic.DeleteArtist(id);
        }
    }
}
