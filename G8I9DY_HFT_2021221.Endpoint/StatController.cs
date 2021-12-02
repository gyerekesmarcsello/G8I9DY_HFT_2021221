using G8I9DY_HFT_2021221.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace G8I9DY_HFT_2021221.Endpoint
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IAlbumLogic albumLogic;
        IArtistLogic artistLogic;
        ITrackLogic trackLogic;
        public StatController(IAlbumLogic albumLogic, IArtistLogic artistLogic, ITrackLogic trackLogic)
        {
            this.artistLogic = artistLogic;
            this.albumLogic = albumLogic;
            this.trackLogic = trackLogic;
        }

        [HttpGet]
        public IEnumerable<string> AlbumsWhereArtistName(string name)
        {
            return albumLogic.AlbumsWhereArtistName(name);
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AVGPlaysByArtists()
        {
            return albumLogic.AVGPlaysByArtists();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AVGTrackDurationByArtists()
        {
            return artistLogic.AVGTrackDurationByArtists();
        }

        [HttpGet]
        public IEnumerable<string> TrackWhereGenreIs(string name)
        {
            return trackLogic.TracksWhereGenreIs(name);
        }

        [HttpGet]
        public IEnumerable<string> LongestTrackByAlbum(string title)
        {
            return trackLogic.LongestTrackByAlbum(title);
        }


    }
}
