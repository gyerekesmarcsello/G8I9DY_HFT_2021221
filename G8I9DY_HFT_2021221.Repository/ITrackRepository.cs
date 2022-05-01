using G8I9DY_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G8I9DY_HFT_2021221.Repository
{
    public interface ITrackRepository: IRepository<Track>
    {
        //create
        void CreateTrack(int TrackID, string Title, int AlbumID, int plays, TimeSpan duration, int ArtistID, bool IsExplicit);
        //read
        Track ReadTrack(int TrackID);
        //readall
        IQueryable<Track> ReadAllTracks();
        //update
        void UpdateTrack(int TrackID, string Title, int AlbumID, int plays, TimeSpan duration, int ArtistID, bool IsExplicit);
        //delete
        void DeleteTrack(int TrackID);
    }
}
