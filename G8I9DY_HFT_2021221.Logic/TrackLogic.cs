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
        IAlbumRepository albumRepo;
        public TrackLogic(ITrackRepository trackRepo,IAlbumRepository albumRepo)
        {
            this.trackRepo = trackRepo;
            this.albumRepo = albumRepo;
        }
        public void CreateTrack(int TrackID, string Title, int AlbumID, int plays, TimeSpan duration, int ArtistID, bool IsExplicit)
        {
            if (String.IsNullOrEmpty(TrackID.ToString()) || Title == null || String.IsNullOrEmpty(AlbumID.ToString()) || String.IsNullOrEmpty(plays.ToString()) || String.IsNullOrEmpty(duration.ToString()) || String.IsNullOrEmpty(ArtistID.ToString()) || String.IsNullOrEmpty(IsExplicit.ToString()))
            {
                throw new ArgumentException("Value cannot be null!");
            }
            else
            {
                var temp = from tracks in trackRepo.GetAll() where tracks.TrackID == TrackID select tracks.TrackID;
                if (temp.Count() > 0)
                {
                    throw new ArgumentException("Already exists!");
                }
                else
                {
                    trackRepo.CreateTrack(TrackID, Title, AlbumID, plays, duration, ArtistID, IsExplicit);
                }
            } 
        }
        public void DeleteTrack(int TrackID)
        {
            try
            {
                ReadTrack(TrackID);
                trackRepo.DeleteTrack(TrackID);
            }
            catch (Exception)
            {
                throw new KeyNotFoundException();
            }
        }
        public IEnumerable<Track> ReadAllTracks()
        {
            return trackRepo.ReadAllTracks();
        }
        public Track ReadTrack(int TrackID)
        {
            var temp = from tracks in trackRepo.GetAll() where tracks.TrackID == TrackID select tracks.TrackID;
            if (temp.Count() > 0)
            {
                return trackRepo.ReadTrack(TrackID);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
        public void UpdateTrack(int TrackID, string Title, int AlbumID, int plays, TimeSpan duration, int ArtistID, bool IsExplicit)
        {
            if (String.IsNullOrEmpty(TrackID.ToString()) || Title == null || String.IsNullOrEmpty(AlbumID.ToString()) || String.IsNullOrEmpty(plays.ToString()) || String.IsNullOrEmpty(duration.ToString()) || String.IsNullOrEmpty(ArtistID.ToString()) || String.IsNullOrEmpty(IsExplicit.ToString()))
            {
                throw new ArgumentException("Value cannot be null!");
            }
            else
            {
                var temp = from tracks in trackRepo.GetAll() where tracks.TrackID == TrackID select tracks.TrackID;
                if (temp.Count() > 0)
                {
                   trackRepo.UpdateTrack(TrackID, Title, AlbumID, plays, duration, ArtistID, IsExplicit);
                }
                else
                {
                    throw new KeyNotFoundException();
                }
            }

        }

        public IEnumerable<string> TracksWhereGenreIs(string name) //DONE
        {
            var q3 = from x in trackRepo.GetAll()
                     where x.Album.Genre==name
                     select x.Title;
            List<string> Tracks = new List<string>();
            foreach (var item in q3)
            {
                Tracks.Add(item);
            }
            return Tracks;
        }

        public IEnumerable<string> LongestTrackByAlbum(string title)
        {
            var q1 = from x in trackRepo.GetAll()
                     where x.Album.Title == title
                     select x.TrackID;
            var q2 = from x in trackRepo.GetAll()
                     where q1.Contains(x.TrackID)
                     orderby x.Duration descending
                     select x.Title;
            List<string> track = new List<string>();
            foreach (var item in q2)
            {
                track.Add(item.ToString());
            }
            return track.Take(1);
        }

    }
}
