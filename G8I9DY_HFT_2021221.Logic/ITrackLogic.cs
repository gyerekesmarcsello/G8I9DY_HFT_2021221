using G8I9DY_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G8I9DY_HFT_2021221.Logic
{
    public interface ITrackLogic
    {
        //create
        void CreateTrack(int TrackID, string Title, int AlbumID, int plays, TimeSpan duration, int ArtistID, bool IsExplicit);
        //read
        Tracks ReadTrack(int TrackID);
        //readall
        IEnumerable<Tracks> ReadAllTracks();
        //update
        void UpdateTrack(int TrackID, string Title, int AlbumID, int plays, TimeSpan duration, int ArtistID, bool IsExplicit);
        //delete
        void DeleteTrack(int TrackID);

        //NON CRUDS
        public IEnumerable<string> TracksWhereGenreIs(string name);
        public IEnumerable<string> LongestTrackByAlbum(string title);
    }
}
