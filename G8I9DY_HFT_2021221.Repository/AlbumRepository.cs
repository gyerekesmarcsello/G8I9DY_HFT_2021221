using G8I9DY_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G8I9DY_HFT_2021221.Repository
{
    class AlbumRepository : Repository<Albums>, IAlbumRepository
    {
        public AlbumRepository(DbContext context) : base(context)
        {

        }
        public void CreateAlbum(int albumID, string Title, int ArtistID, string Label)
        {
            Albums album = new Albums() { AlbumID = albumID, Title = Title, ArtistID = ArtistID, Label = Label };
            context.SaveChanges();
        }

        public void DeleteAlbum(int albumID)
        {
            Delete(GetOne(albumID));
            context.SaveChanges();
        }

        public override Albums GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.AlbumID == id);
        }
        public Albums ReadAlbum(int albumID)
        {
            return GetOne(albumID);
        }

        public HashSet<Albums> ReadAllAlbums()
        {
            return (HashSet<Albums>)GetAll();
        }

        public void UpdateAlbum(int albumID, string Title, int ArtistID, string Label)
        {
            DeleteAlbum(albumID);
            CreateAlbum(albumID,Title,ArtistID,Label);
            context.SaveChanges();
        }
    }
}
