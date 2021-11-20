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
        public void CreateArtist(int ArtistID, string Name, string Birthday, string nationality, bool grammywinner)
        {
           artistRepo.CreateArtist(ArtistID, Name, Birthday, nationality,grammywinner);  
        }
        public void DeleteArtist(int ArtistID)
        {
            artistRepo.DeleteArtist(ArtistID);
        }
        public IEnumerable<Artists> ReadAllArtist()
        {
            return artistRepo.ReadAllArtist();
        }
        public Artists ReadArtist(int ArtistID)
        {
            return artistRepo.ReadArtist(ArtistID);
        }
        public void UpdateArtist(int ArtistID, string Name, string Birthday, string nationality, bool grammywinner)
        {
            artistRepo.UpdateArtist(ArtistID, Name, Birthday, nationality,grammywinner);
        }
    }
}
