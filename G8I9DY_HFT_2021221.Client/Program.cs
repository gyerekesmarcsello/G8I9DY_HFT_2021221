using G8I9DY_HFT_2021221.Models;
using System;

namespace G8I9DY_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);
            RestService rest = new RestService("http://localhost:2509");
            //rest.Post<Albums>(new Albums() { Title = "Álomkép", ArtistID = 1, Label = "Universal Music", Length = new TimeSpan(00, 42, 55), ReleaseDate = new DateTime(2010, 01, 01), Genre = "Hungarian Pop" },"albums");
            //rest.Post<Artists>(new Artists() { Name = "Bereczki Zoltán", Birthday = new DateTime(1976, 05, 02), Nationality = "Hungary", GrammyWinner = false },"artists");
            var albums = rest.Get<Albums>("album");
            var artists = rest.Get<Artists>("artist");
            var tracks = rest.Get<Tracks>("track");
            ;

        }

    }
}
