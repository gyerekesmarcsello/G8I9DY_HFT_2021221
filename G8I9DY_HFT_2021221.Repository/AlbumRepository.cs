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
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public AlbumRepository(TracksDbContext context) : base(context)
        {

        }
        public void CreateAlbum(int albumID, string Title, int ArtistID, string Label, TimeSpan length, DateTime releasedate, string Genre)
        {
            Album album = new Album() { AlbumID = albumID, Title = Title, ArtistID = ArtistID, Label = Label, Length=length,ReleaseDate=releasedate,Genre=Genre};
            Create(album);
            context.SaveChanges();
        }

        public void DeleteAlbum(int albumID)
        {
            Delete(GetOne(albumID));
            context.SaveChanges();
        }

        public override Album GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.AlbumID == id);
        }
        public Album ReadAlbum(int albumID)
        {
            return GetOne(albumID);
        }

        public IQueryable<Album> ReadAllAlbums()
        {
            return (IQueryable<Album>)GetAll();
        }

        public void UpdateAlbum(int albumID, string Title, int ArtistID, string Label, TimeSpan length, DateTime releasedate, string Genre)
        {
            var toUpdate = GetOne(albumID);
            toUpdate.Title=Title;
            toUpdate.ArtistID=ArtistID;
            toUpdate.Label=Label;
            toUpdate.Length=length;
            toUpdate.ReleaseDate=releasedate;
            toUpdate.Genre=Genre;
            context.SaveChanges();
        }
    }
}
