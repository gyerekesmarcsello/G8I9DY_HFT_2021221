using G8I9DY_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G8I9DY_HFT_2021221.Repository
{
    class ArtistRepository : Repository<Artists>, IArtistRepository
    {
        public ArtistRepository(DbContext context) : base(context)
        {

        }
        public void CreateArtist(int ArtistID, string Name, string Birthday, string Country)
        {
            Artists artist = new Artists() { ArtistID = ArtistID, Name = Name, Birthday = Birthday, Country = Country };
            context.SaveChanges();
        }

        public void DeleteArtist(int ArtistID)
        {
            Delete(GetOne(ArtistID));
            context.SaveChanges();
        }

        public override Artists GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.ArtistID == id);
        }

        public HashSet<Artists> ReadAllArtist()
        {
            return (HashSet<Artists>)GetAll();
        }

        public Artists ReadArtist(int ArtistID)
        {
            return GetOne(ArtistID);
        }

        public void UpdateArtist(int ArtistID, string Name, string Birthday, string Country)
        {
            DeleteArtist(ArtistID);
            CreateArtist(ArtistID, Name, Birthday, Country);
            context.SaveChanges();
        }
    }
}
