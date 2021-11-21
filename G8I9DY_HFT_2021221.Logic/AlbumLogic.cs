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
        public void CreateAlbum(int albumID, string Title, int ArtistID, string Label, TimeSpan length, DateTime releasedate, string Genre)
        {
            albumRepo.CreateAlbum(albumID, Title, ArtistID, Label, length, releasedate,Genre);
        }
        public void DeleteAlbum(int albumID)
        {
            albumRepo.DeleteAlbum(albumID);
        }
        public IEnumerable<Albums> GetAll()
        {
            return albumRepo.GetAll();
        }
        public Albums GetOne(int id)
        {
            return albumRepo.GetOne(id);
        }
        public Albums ReadAlbum(int albumID)
        {
            return albumRepo.ReadAlbum(albumID);
        }

        public IEnumerable<Albums> ReadAllAlbums()
        {
            return albumRepo.ReadAllAlbums();
        }
        public void UpdateAlbum(int albumID, string Title, int ArtistID, string Label, TimeSpan length, DateTime releasedate, string Genre)
        {
            albumRepo.UpdateAlbum(albumID, Title, ArtistID, Label, length, releasedate,Genre);
        }
    }
}
