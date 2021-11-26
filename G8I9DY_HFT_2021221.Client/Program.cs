using G8I9DY_HFT_2021221.Models;
using System;

namespace G8I9DY_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);
            RestService rest = new RestService("http://localhost:2509/");
            rest.Post<Tracks>(new Tracks() { TrackID =});
            var albums = rest.Get<Albums>("albums");
        }
    }
}
