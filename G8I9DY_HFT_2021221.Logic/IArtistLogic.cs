using G8I9DY_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G8I9DY_HFT_2021221.Logic
{
    public interface IArtistLogic
    {
        //create
        void CreateArtist(int ArtistID, string Name, DateTime Birthday, string nationality, bool grammywinner);
        //read
        Artists ReadArtist(int ArtistID);
        //read all
        IEnumerable<Artists> ReadAllArtist();
        //update
        void UpdateArtist(int ArtistID, string Name, DateTime Birthday, string nationality, bool grammywinner);
        //delete
        void DeleteArtist(int ArtistID);
        //NON CRUDS
        public IEnumerable<KeyValuePair<string, double>> AVGTrackDurationByArtists();

    }
}
