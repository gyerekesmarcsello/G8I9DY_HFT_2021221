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
        ITrackRepository trackRepo;
        IArtistRepository artistRepo;
        public AlbumLogic(IAlbumRepository albumRepo,ITrackRepository trackRepo,IArtistRepository artistRepo)
        {
            this.albumRepo = albumRepo;
            this.trackRepo = trackRepo;
            this.artistRepo = artistRepo;
        }
        public void CreateAlbum(int albumID, string Title, int ArtistID, string Label, TimeSpan length, DateTime releasedate, string Genre)
        {
            if (String.IsNullOrEmpty(albumID.ToString()) || Title == null || String.IsNullOrEmpty(ArtistID.ToString()) || Label == null || String.IsNullOrEmpty(length.ToString()) || String.IsNullOrEmpty(releasedate.ToString()) || String.IsNullOrEmpty(Genre.ToString()))
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
        public Album ReadAlbum(int albumID)
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
        public IEnumerable<Album> ReadAllAlbums()
        {
            return albumRepo.ReadAllAlbums();
        }
        public void UpdateAlbum(int albumID, string Title, int ArtistID, string Label, TimeSpan length, DateTime releasedate, string Genre)
        {
            if (String.IsNullOrEmpty(albumID.ToString()) || Title == null || String.IsNullOrEmpty(ArtistID.ToString()) || Label == null ||  String.IsNullOrEmpty(length.ToString()) || String.IsNullOrEmpty(releasedate.ToString()) || String.IsNullOrEmpty(Genre.ToString()))
            {
                throw new ArgumentException("Value cannot be null!");
            }
            else
            {
                var temp = from albums in albumRepo.GetAll() where albums.AlbumID == albumID select albums.AlbumID;
                if (temp.Count() > 0)
                {
                    albumRepo.UpdateAlbum(albumID, Title, ArtistID, Label, length, releasedate, Genre);
                }
                else
                {
                    throw new KeyNotFoundException();
                }

            }
        }
        public IEnumerable<string> AlbumsWhereArtistName(string name) //DONE
        {
            var q1 = from x in artistRepo.GetAll()
                     where x.Name == name
                     select x.ArtistID;
            var q2 = from x in albumRepo.GetAll().AsEnumerable()
                     where q1.Contains(x.ArtistID)
                     select x.Title;
            List<string> albums = new List<string>();
            foreach (var item in q2)
            {
                albums.Add(item);
            }
            return albums;
        }

        public IEnumerable<KeyValuePair<string, double>> AVGPlaysByArtists()
        {
            return from x in trackRepo.GetAll()
                   group x by x.Artist.Name into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Average(t => t.Plays));
        }
    }
}
