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
        public ArtistLogic(IArtistRepository artistRepo)
        {
            this.artistRepo = artistRepo;
        }
        public void CreateArtist(int ArtistID, string Name, DateTime Birthday, string nationality, bool grammywinner)
        {
            if (String.IsNullOrEmpty(ArtistID.ToString()) || Name == null || nationality == null)
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
            artistRepo.UpdateArtist(ArtistID, Name, Birthday, nationality,grammywinner);
        }
    }
}
