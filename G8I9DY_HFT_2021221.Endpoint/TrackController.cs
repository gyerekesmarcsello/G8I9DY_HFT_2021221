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
    public class TrackController : ControllerBase
    {
        ITrackLogic trackLogic;

        public TrackController(ITrackLogic trackLogic)
        {
            this.trackLogic = trackLogic;
        }

        //GET:/tracks
        public IEnumerable<Tracks> Get()
        {
            return trackLogic.ReadAllTracks();
        }

        //GET/tracks/5
        [HttpGet("{id}")]
        public Tracks Get(int id)
        {
            return trackLogic.ReadTrack(id);
        }

        //POST /tracks
        [HttpPost]
        public void Post([FromBody] int TrackID, string Title, int AlbumID, int plays, TimeSpan duration, int ArtistID, bool IsExplicit)
        {
            trackLogic.CreateTrack(TrackID, Title, AlbumID,plays, duration, ArtistID, IsExplicit);
        }

        //DELETE /track/5
        [HttpGet("{id}")]
        public void Delete(int id)
        {
            trackLogic.DeleteTrack(id);
        }
    }
}
