using G8I9DY_HFT_2021221.Models;
using G8I9DY_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G8I9DY_HFT_2021221.Logic
{
    public class TrackLogic : ITrackLogic
    {
        ITrackRepository trackRepo;
        public TrackLogic(ITrackRepository trackRepo)
        {
            this.trackRepo = trackRepo;
        }
        public void CreateTrack(int TrackID, string Title, int AlbumID, string Genre, int plays, TimeSpan duration, int ArtistID)
        {
            trackRepo.CreateTrack(TrackID, Title, AlbumID, Genre,plays,duration,ArtistID);   
        }
        public void DeleteTrack(int TrackID)
        {
            trackRepo.DeleteTrack(TrackID);
        }
        public IEnumerable<Tracks> ReadAllTracks()
        {
            return trackRepo.ReadAllTracks();
        }
        public Tracks ReadTrack(int TrackID)
        {
            return trackRepo.ReadTrack(TrackID);
        }
        public void UpdateTrack(int TrackID, string Title, int AlbumID, string Genre, int plays, TimeSpan duration, int ArtistID)
        {
            trackRepo.UpdateTrack(TrackID, Title, AlbumID, Genre, plays, duration, ArtistID);
        }
    }
}
