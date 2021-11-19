﻿using G8I9DY_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G8I9DY_HFT_2021221.Logic
{
    public interface IArtistLogic : ILogic<Artists>
    {
        //create
        void CreateArtist(int ArtistID, string Name, string Birthday, string Country);
        //read
        Artists ReadArtist(int ArtistID);
        //readall
        IEnumerable<Artists> ReadAllArtist();
        //update
        void UpdateArtist(int ArtistID, string Name, string Birthday, string Country);
        //delete
        void DeleteArtist(int ArtistID);
    }
}
