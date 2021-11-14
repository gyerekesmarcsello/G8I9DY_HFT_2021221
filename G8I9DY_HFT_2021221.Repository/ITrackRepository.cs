using G8I9DY_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G8I9DY_HFT_2021221.Repository
{
    public interface ITrackRepository: IRepository<Tracks>
    {
        //create
        void CreateTrack(int TrackID, string Title, int AlbumID, string Genre, int ArtistID, string ReleaseDate);
        //read
        Tracks ReadTrack(int TrackID);
        //readall
        HashSet<Tracks> ReadAllTracks();
        //update
        void UpdateTrack(int TrackID, string Title, int AlbumID, string Genre, int ArtistID, string ReleaseDate);
        //delete
        void DeleteTrack(int TrackID);
    }
}
