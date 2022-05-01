using G8I9DY_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G8I9DY_HFT_2021221.Logic
{
    public interface IAlbumLogic
    {
        //create
        void CreateAlbum(int albumID, string Title, int ArtistID, string Label, TimeSpan length, DateTime releasedate, string Genre);
        //read
        Album ReadAlbum(int albumID);
        //readall
        IEnumerable<Album> ReadAllAlbums();
        //update
        void UpdateAlbum(int albumID, string Title, int ArtistID, string Label, TimeSpan length, DateTime releasedate, string Genre);
        //delete
        void DeleteAlbum(int albumID);

        public IEnumerable<string> AlbumsWhereArtistName(string name);
        public IEnumerable<KeyValuePair<string, double>> AVGPlaysByArtists();
    }
}
