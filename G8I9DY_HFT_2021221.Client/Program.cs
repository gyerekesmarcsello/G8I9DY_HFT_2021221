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

            //CRUDs(Artist)
            rest.Post(new Artists()
            {
                Name = "POSTARTIST",
                Birthday = new DateTime(2001, 11, 23),
                Nationality = ("Hungary"),
                GrammyWinner = false,

            }, "artist");

            var tempArtist = rest.Get<Artists>("artist");
            ;
            rest.Put(new Artists()
            {
                ArtistID = 9,
                Name = "PUTARTIST",
                Birthday = new DateTime(2001, 11, 23),
                Nationality = ("PUTNATIONALITY"),
                GrammyWinner = true,

            }, "artist");

            rest.Delete(8, "artist");

            //CRUDs(Albums)
            rest.Post(new Albums()
            {
                Title = "POSTALBUM",
                ArtistID = 10,
                Label = "POSTLABEL",
                Length = new TimeSpan(00, 40, 20),
                ReleaseDate = new DateTime(2021, 11, 27),
                Genre = "POSTGENRE"
            }, "album");

            var temparAlbum = rest.Get<Albums>("album");

            rest.Put(new Albums()
            {
                AlbumID = 16,
                Title = "PUTALBUM",
                ArtistID = 9,
                Label = "PUTLABEL",
                Length = new TimeSpan(00, 40, 20),
                ReleaseDate = new DateTime(2021, 11, 27),
                Genre = "PUTUPDATE"

            }, "album"); ;

            rest.Delete(15, "album");

            //CRUDs(Tracks)
            rest.Post(new Tracks()
            {
                Title="POSTTRACK",
                AlbumID = 17,
                ArtistID = 10,
                Plays=42069,
                Duration= new TimeSpan(00,04,20),
                IsExplicit = true,

            }, "track");

            var tempTrack = rest.Get<Tracks>("track");

            rest.Put(new Tracks()
            {
                TrackID = 44,
                Title = "PUTTRACK",
                AlbumID = 16,
                ArtistID = 9,
                Plays = 42069,
                Duration = new TimeSpan(00, 40, 20),
                IsExplicit = true,

            }, "track") ;

            rest.Delete(43, "track");
            ;
        }

    }
}
