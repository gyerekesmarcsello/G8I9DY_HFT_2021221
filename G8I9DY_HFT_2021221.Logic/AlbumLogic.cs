using G8I9DY_HFT_2021221.Models;
using G8I9DY_HFT_2021221.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G8I9DY_HFT_2021221.Logic
{
    public class AlbumLogic : IAlbumLogic
    {
        IAlbumRepository albumRepo;
        public AlbumLogic(IAlbumRepository albumRepo)
        {
            this.albumRepo = albumRepo;
        }
        public void CreateAlbum(int albumID, string Title, int ArtistID, string Label)
        {
            throw new NotImplementedException();
        }

        public void DeleteAlbum(int albumID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Albums> GetAll()
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

        public IEnumerable<Albums> ReadAllAlbums()
        {
            throw new NotImplementedException();
        }

        public void UpdateAlbum(int albumID, string Title, int ArtistID, string Label)
        {
            throw new NotImplementedException();
        }
    }
}
