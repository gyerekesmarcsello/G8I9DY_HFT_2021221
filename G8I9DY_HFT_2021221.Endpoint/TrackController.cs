using G8I9DY_HFT_2021221.Logic;
using G8I9DY_HFT_2021221.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
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
        IHubContext<SignalRHub> hub;

        public TrackController(ITrackLogic trackLogic, IHubContext<SignalRHub> hub)
        {
            this.trackLogic = trackLogic;
            this.hub = hub;
        }

        [HttpGet]
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
        public void Post([FromBody] Tracks tracks)
        {
            trackLogic.CreateTrack(tracks.TrackID, tracks.Title, tracks.AlbumID, tracks.Plays, tracks.Duration, tracks.ArtistID, tracks.IsExplicit);
            this.hub.Clients.All.SendAsync("TrackCreated", tracks);
        }

        [HttpPut]
        public void Put([FromBody] Tracks tracks)
        {
            trackLogic.UpdateTrack(tracks.TrackID,tracks.Title,tracks.AlbumID,tracks.Plays,tracks.Duration,tracks.ArtistID,tracks.IsExplicit);
            this.hub.Clients.All.SendAsync("TrackUpdated", tracks);
        }

        //DELETE /track/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var track = trackLogic.ReadTrack(id);
            trackLogic.DeleteTrack(id);
            this.hub.Clients.All.SendAsync("TrackDeleted", track);
        }
    }
}
