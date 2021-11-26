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
            if (String.IsNullOrEmpty(albumID.ToString()) || Title == null || String.IsNullOrEmpty(length.ToString()) || Label == null ||  String.IsNullOrEmpty(ArtistID.ToString()) || String.IsNullOrEmpty(releasedate.ToString()))
            {
                throw new ArgumentException("Value cannot be null!");
            }
            else
            {
                var temp = from albums in albumRepo.GetAll() where albums.AlbumID == albumID select albums.AlbumID;
                if (temp.Count() > 0)
                {
                    throw new ArgumentException("Already exists!");
                }
                else
                {
                    albumRepo.CreateAlbum(albumID, Title, ArtistID, Label, length, releasedate, Genre);
                }

            }
        }
        public void DeleteAlbum(int albumID)
        {
            try
            {
                ReadAlbum(albumID);
                albumRepo.DeleteAlbum(albumID);
            }
            catch (Exception)
            {
                throw new KeyNotFoundException();
            }
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
            var temp = from albums in albumRepo.GetAll() where albums.AlbumID == albumID select albums.AlbumID;
            if (temp.Count() > 0)
            {
                return albumRepo.ReadAlbum(albumID);
            }
            else
            {
                throw new KeyNotFoundException();
            }
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
