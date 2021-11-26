using G8I9DY_HFT_2021221.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
