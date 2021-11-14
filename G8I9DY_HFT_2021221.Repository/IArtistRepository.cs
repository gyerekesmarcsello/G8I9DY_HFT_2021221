using G8I9DY_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G8I9DY_HFT_2021221.Repository
{
    public interface IArtistRepository : IRepository<Artists>
    {
        //create
        void CreateAlbum(int ArtistID, string Name, string Birthday, string Country);
        //read
        Albums ReadAlbum(int ArtistID);
        //readall
        HashSet<Albums> ReadAllAlbums();
        //update
        void UpdateAlbum(int ArtistID, string Name, string Birthday, string Country);
        //delete
        void DeleteAlbum(int ArtistID);
    }
}
