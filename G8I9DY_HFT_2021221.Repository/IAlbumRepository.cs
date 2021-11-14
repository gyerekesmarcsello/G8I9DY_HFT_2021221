using G8I9DY_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G8I9DY_HFT_2021221.Repository
{
    public interface IAlbumRepository: IRepository<Albums>
    {
        //create
        void CreateAlbum(int albumID, string Title, int ArtistID, string Label);
        //read
        Albums ReadAlbum(int albumID);
        //readall
        HashSet<Albums> ReadAllAlbums();
        //update
        void UpdateAlbum(int albumID, string Title, int ArtistID, string Label);
        //delete
        void DeleteAlbum(int albumID);
    }
}
