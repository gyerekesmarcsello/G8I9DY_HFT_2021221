using G8I9DY_HFT_2021221.Models;
using G8I9DY_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G8I9DY_HFT_2021221.Logic
{
    public class ArtistLogic : IArtistLogic
    {
        IArtistRepository artistRepo;
        ITrackRepository trackRepo;
        public ArtistLogic(IArtistRepository artistRepo,ITrackRepository trackRepo)
        {
            this.artistRepo = artistRepo;
            this.trackRepo = trackRepo;
        }
        public void CreateArtist(int ArtistID, string Name, DateTime Birthday, string nationality, bool grammywinner)
        {
            if (String.IsNullOrEmpty(ArtistID.ToString()) || Name == null || String.IsNullOrEmpty(Birthday.ToString()) || nationality == null || String.IsNullOrEmpty(grammywinner.ToString()))
            {
                throw new ArgumentException("Value cannot be null!");
            }
            else {
                var temp = from artists in artistRepo.GetAll() where artists.ArtistID == ArtistID select artists.ArtistID;
                if (temp.Count() > 0)
                {
                    throw new ArgumentException("Already exists!");
                }
                else
                {
                    artistRepo.CreateArtist(ArtistID, Name, Birthday, nationality, grammywinner);
                }
            }
        }
        public void DeleteArtist(int ArtistID)
        {
            try
            {
                ReadArtist(ArtistID);          
                artistRepo.DeleteArtist(ArtistID);
            }
            catch (Exception)
            {
                throw new KeyNotFoundException();
            }
        }
        public IEnumerable<Artists> ReadAllArtist()
        {
            return artistRepo.ReadAllArtist();
        }
        public Artists ReadArtist(int ArtistID)
        {
            var temp = from artists in artistRepo.GetAll() where artists.ArtistID == ArtistID select artists.ArtistID;
            if (temp.Count() > 0)
            {
                return artistRepo.ReadArtist(ArtistID);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
        public void UpdateArtist(int ArtistID, string Name, DateTime Birthday, string nationality, bool grammywinner)
        {
            if (String.IsNullOrEmpty(ArtistID.ToString()) || Name == null || String.IsNullOrEmpty(Birthday.ToString()) || nationality == null || String.IsNullOrEmpty(grammywinner.ToString()))
            {
                throw new ArgumentException("Value cannot be null!");
            }
            else
            {
                var temp = from artists in artistRepo.GetAll() where artists.ArtistID == ArtistID select artists.ArtistID;
                if (temp.Count() > 0)
                {
                    artistRepo.UpdateArtist(ArtistID, Name, Birthday, nationality, grammywinner);
                }
                else
                {
                    throw new KeyNotFoundException();
                }
            }
        }

        public IEnumerable<KeyValuePair<string,double>>AVGTrackDurationByArtists()
        {
            return from x in trackRepo.GetAll().AsEnumerable()
                   group x by x.Artist.Name into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Average(t => t.DurationTicks));
        }
    }
}
