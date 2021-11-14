using G8I9DY_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G8I9DY_HFT_2021221.Repository
{
    class AlbumRepository : IRepository<Albums>, IAlbumRepository
    {
        public void CreateAlbum(int albumID, string Title, int ArtistID, string Label)
        {
            Albums album = new Albums() { AlbumID = albumID, Title = Title, ArtistID = ArtistID, Label = Label };
        }

        public void DeleteAlbum(int albumID)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Albums> GetAll()
        {
            throw new NotImplementedException();
        }

        public Albums GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public Albums ReadAlbum(int albumID)
        {
            throw new NotImplementedException();
        }

        public HashSet<Albums> ReadAllAlbums()
        {
            throw new NotImplementedException();
        }

        public void UpdateAlbum(int albumID, string Title, int ArtistID, string Label)
        {
            throw new NotImplementedException();
        }
    }
}
