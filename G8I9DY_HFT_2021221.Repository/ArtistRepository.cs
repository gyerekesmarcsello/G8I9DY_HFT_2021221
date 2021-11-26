using G8I9DY_HFT_2021221.Data;
using G8I9DY_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G8I9DY_HFT_2021221.Repository
{
    public class ArtistRepository : Repository<Artists>, IArtistRepository
    {
        public ArtistRepository(TracksDbContext context) : base(context)
        {

        }
        public void CreateArtist(int ArtistID, string Name, DateTime Birthday, string nationality,bool grammywinner)
        {
            Artists artist = new Artists() { ArtistID = ArtistID, Name = Name, Birthday = Birthday, Nationality = nationality,GrammyWinner=grammywinner };
            Create(artist);
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

        public IQueryable<Artists> ReadAllArtist()
        {
            return (IQueryable<Artists>)GetAll();
        }

        public Artists ReadArtist(int ArtistID)
        {
            return GetOne(ArtistID);
        }

        public void UpdateArtist(int ArtistID, string Name, DateTime Birthday, string nationality, bool grammywinner)
        {
            DeleteArtist(ArtistID);
            CreateArtist(ArtistID, Name, Birthday, nationality,grammywinner);
            context.SaveChanges();
        }
    }
}
