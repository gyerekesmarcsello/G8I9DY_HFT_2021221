using G8I9DY_HFT_2021221.Models;
using System;
using System.Collections.Generic;

namespace G8I9DY_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }

        }
        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) C-CREATE (album,artist,tracks)...");
            Console.WriteLine("2) R-READ (FROM albums,artists,tracks)...");
            Console.WriteLine("3) U-UPDATE (FROM existing database data)...");
            Console.WriteLine("4) D-DELETE (FROM existing database data)...");
            Console.WriteLine("5) NON CRUD METHODS");
            Console.WriteLine("E) EXIT");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Create();
                    return true;
                case "2":
                    Read();
                    return true;
                case "3":
                    Update();
                    return true;
                case "4":
                    Delete();
                    return true;
                case "5":
                    NonCrudMenu();
                    return false;
                case "E":
                    Environment.Exit(0);
                    return false;
                default:
                    MainMenu();
                    return true;
            }
        }

        private static void NonCrudMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) AlbumsWhereArtistName");
            Console.WriteLine("2) AVGPlaysByArtists");
            Console.WriteLine("3) AVGTrackDurationByArtist");
            Console.WriteLine("4) TracksWhereGenreIs");
            Console.WriteLine("5) LongestTrackByAlbum");
            Console.WriteLine("B) Exit Non Crud");
            Console.Write("\r\nSelect an option: ");
            switch (Console.ReadLine())
            {
                case "1":
                    AlbumsWhereArtistName();
                    break;
                case "2":
                    AVGPlaysByArtists();
                    break;
                case "3":
                    AVGTrackDurationByArtist();
                    break;
                case "4":
                    TracksWhereGenreIs();
                    break;
                case "5":
                    Delete();
                    break;
                case "B":
                    MainMenu();
                    break;
                default:
                    NonCrudMenu();
                    break;
            }
        }

        private static void AlbumsWhereArtistName()
        {
            Console.Clear();
            RestService rest = new RestService("http://localhost:2509");
            Console.WriteLine("Enter the name of a Artist :");
            string artistname =Console.ReadLine();
            rest.Get<string>("stat/AnimesWhereCharacterName?name=" + artistname);
            var result = rest.Get<string>("stat/AnimesWhereCharacterName?name=" + artistname);
            Console.WriteLine(string.Join(",", result));
            Console.ReadKey();
            NonCrudMenu();
        }

        private static void AVGPlaysByArtists()
        {
            Console.Clear();
            RestService rest = new RestService("http://localhost:2509");
            rest.Get<KeyValuePair<string, double>>("stat/AVGPlaysByArtists");
            var result = rest.Get<KeyValuePair<string, double>>("stat/AVGPlaysByArtists");
            Console.WriteLine(string.Join(",", result));
            Console.ReadKey();
            NonCrudMenu();
        }

        private static void AVGTrackDurationByArtist()
        {
            Console.Clear();
            RestService rest = new RestService("http://localhost:2509");
            rest.Get<KeyValuePair<string, double>>("stat/AVGTrackDurationByArtist");
            var result = rest.Get<KeyValuePair<string, double>>("stat/AVGTrackDurationByArtist");
            Console.WriteLine(string.Join(",", result));
            Console.ReadKey();
            NonCrudMenu();

        }
        private static void TracksWhereGenreIs()
        {
            Console.Clear();
            RestService rest = new RestService("http://localhost:2509");
            Console.WriteLine("Enter a Genre :");
            string genre = Console.ReadLine();
            rest.Get<string>("stat/TracksWhereGenreIs?name=" + genre);
            var result = rest.Get<string>("stat/TracksWhereGenreIs?name=" + genre);
            Console.WriteLine(string.Join(",", result));
            Console.ReadKey();
            NonCrudMenu();
        }

        private static void LongestTrackByAlbum()
        {
            Console.Clear();
            RestService rest = new RestService("http://localhost:2509");
            Console.WriteLine("Enter the title of an album:");
            string title = Console.ReadLine();
            rest.Get<string>("stat/LongestTrackByAlbum?title=" + title);
            var result = rest.Get<string>("stat/LongestTrackByAlbum?title=" + title);
            Console.WriteLine(string.Join(",", result));
            Console.ReadKey();
            NonCrudMenu();

        }
        private static void Delete()
        {
            Console.Clear();
            RestService rest = new RestService("http://localhost:2509");
            Console.WriteLine("Which table you want me to delete from ? (album,track,artist)");
            string table = Console.ReadLine();
            Console.WriteLine("Which value with which ID do you want to delete ?");
            int id = int.Parse(Console.ReadLine());
            rest.Delete(id, table);
            Console.WriteLine("The item has been successfully deleted!");
            Console.ReadKey();
            MainMenu();
        }
        private static void Create()
        {
            Console.Clear();
            RestService rest = new RestService("http://localhost:2509");
            Console.WriteLine("What type of element do you want me to insert ? (artist,track,album)");
            string table = Console.ReadLine();
            if (table == "artist" || table == "track"|| table == "album")
            {
                switch(table)
                {
                    case "artist":
                        Console.WriteLine("Name of the artist: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Birthday of the artist ");
                        DateTime birthday = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Where were they born ? ");
                        string nationality = Console.ReadLine();
                        Console.WriteLine("Do they have a Grammy award ? (true/false)");
                        bool grammy = bool.Parse(Console.ReadLine());
                        rest.Post(new Artists()
                        {
                            Name = name,
                            Birthday = birthday,
                            Nationality = nationality,
                            GrammyWinner = grammy,

                        }, "artist");
                        Console.WriteLine("Item successfully added!");
                        Console.ReadKey();
                        MainMenu();
                        break;
                    case "album":
                        Console.WriteLine("Name of the Album: ");
                        string title = Console.ReadLine();
                        Console.WriteLine("Please enter the ID of the Artist: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Who published the album ?");
                        string label = Console.ReadLine();
                        Console.WriteLine("How long is the track ? ");
                        TimeSpan length = TimeSpan.Parse(Console.ReadLine());
                        Console.WriteLine("When was the album released ?");
                        DateTime releasedate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("What is the album genre ? ");
                        string genre = Console.ReadLine();
                        rest.Post(new Albums()
                        {
                            Title = title,
                            ArtistID = id,
                            Label = label,
                            Length = length,
                            ReleaseDate = releasedate,
                            Genre =  genre
                        }, "album");
                        Console.WriteLine("Item successfully added!");
                        Console.ReadKey();
                        MainMenu();
                        break;
                    case "track":
                        Console.WriteLine("What is the title of the track ?");
                        string tracktitle = Console.ReadLine();
                        Console.WriteLine("Please enter the ID of the Album: ");
                        int albumid = int.Parse(Console.ReadLine());
                        Console.WriteLine("Please enter the ID of the Artist: ");
                        int artistid = int.Parse(Console.ReadLine());
                        Console.WriteLine("How many times was the song played ?");
                        int plays = int.Parse(Console.ReadLine());
                        Console.WriteLine("How long is the Track ?");
                        TimeSpan duration = TimeSpan.Parse(Console.ReadLine());
                        Console.WriteLine("Is the Track suitable ?");
                        bool excplicit = bool.Parse(Console.ReadLine());
                        Console.WriteLine("Item successfully added!");
                        rest.Post(new Tracks()
                        {
                            Title = tracktitle,
                            AlbumID = albumid,
                            ArtistID = artistid,
                            Plays = plays,
                            Duration = duration,
                            IsExplicit = excplicit,

                        }, "track");
                        Console.ReadKey();
                        MainMenu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Incorrect table name!");
                Console.ReadKey();
                MainMenu();
            }
        }
        private static void Read()
        {
            Console.Clear();
            RestService rest = new RestService("http://localhost:2509");
            Console.WriteLine("Which table should I display ? (artist,track,album)");
            string table = Console.ReadLine();
            if (table == "artist" || table == "track" || table == "album")
            {
                switch (table)
                {
                    case "artist":
                        var tempArtist = rest.Get<Artists>("artist");
                        foreach (var item in tempArtist)
                        {
                            Console.WriteLine("ID: {0}, Name: {1}, Birthday: {2}, Nationality: {3}, Do they have a grammy ?: {4}",item.ArtistID,item.Name,item.Birthday,item.Nationality,item.GrammyWinner);
                        }
                        Console.ReadKey();
                        MainMenu();
                        break;
                    case "album":
                        var temparAlbum = rest.Get<Albums>("album");
                        foreach (var item in temparAlbum)
                        {
                            Console.WriteLine("AlbumID: {0}, Title: {1}, ArtistID: {2}, Label: {3}, Length: {4}, ReleaseData: {5}, Genre: {6}", item.AlbumID, item.Title, item.ArtistID, item.Label, item.Length, item.ReleaseDate, item.Genre);
                        }
                        Console.ReadKey();
                        MainMenu();
                        break;
                    case "track":
                        var tempTrack = rest.Get<Tracks>("track");
                        foreach (var item in tempTrack)
                        {
                            Console.WriteLine("TrackID: {0}, Title: {1}, AlbumID: {2}, ArtistID: {3}, Plays: {4}, Duration: {5}, Is it suitable for children ?: {6}", item.TrackID, item.Title, item.AlbumID, item.ArtistID, item.Plays, item.Duration, item.IsExplicit);
                        }
                        Console.ReadKey();
                        MainMenu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Incorrect table name!");
                Console.ReadKey();
                MainMenu();
            }
        }
        private static void Update()
        {
            Console.Clear();
            RestService rest = new RestService("http://localhost:2509");
            Console.WriteLine("What type of element do you want me to update ? (artist,track,album)");
            string table = Console.ReadLine();
            if (table == "artist" || table == "track" || table == "album")
            {
                switch (table)
                {
                    case "artist":
                        Console.WriteLine("Please enter the ID of the Artist: ");
                        int artistid1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Name of the artist: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Birthday of the artist ");
                        DateTime birthday = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Where were they born ? ");
                        string nationality = Console.ReadLine();
                        Console.WriteLine("Do they have a Grammy award ? (true/false)");
                        bool grammy = bool.Parse(Console.ReadLine());
                        rest.Put(new Artists()
                        {
                            ArtistID = artistid1,
                            Name = name,
                            Birthday = birthday,
                            Nationality = nationality,
                            GrammyWinner = grammy,

                        }, "artist");
                        Console.WriteLine("Item successfully added!");
                        Console.ReadKey();
                        MainMenu();
                        break;
                    case "album":
                        Console.WriteLine("Please enter the ID of the Album: ");
                        int albumid1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Name of the Album: ");
                        string title = Console.ReadLine();
                        Console.WriteLine("Please enter the ID of the Artist: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Who published the album ?");
                        string label = Console.ReadLine();
                        Console.WriteLine("How long is the track ? ");
                        TimeSpan length = TimeSpan.Parse(Console.ReadLine());
                        Console.WriteLine("When was the album released ?");
                        DateTime releasedate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("What is the album genre ? ");
                        string genre = Console.ReadLine();
                        rest.Put(new Albums()
                        {
                            AlbumID = albumid1,
                            Title = title,
                            ArtistID = id,
                            Label = label,
                            Length = length,
                            ReleaseDate = releasedate,
                            Genre = genre
                        }, "album");
                        Console.WriteLine("Item successfully added!");
                        Console.ReadKey();
                        MainMenu();
                        break;
                    case "track":
                        Console.WriteLine("Please enter the ID of the Track: ");
                        int trackid = int.Parse(Console.ReadLine());
                        Console.WriteLine("What is the title of the track ?");
                        string tracktitle = Console.ReadLine();
                        Console.WriteLine("Please enter the ID of the Album: ");
                        int albumid = int.Parse(Console.ReadLine());
                        Console.WriteLine("Please enter the ID of the Artist: ");
                        int artistid = int.Parse(Console.ReadLine());
                        Console.WriteLine("How many times was the song played ?");
                        int plays = int.Parse(Console.ReadLine());
                        Console.WriteLine("How long is the Track ?");
                        TimeSpan duration = TimeSpan.Parse(Console.ReadLine());
                        Console.WriteLine("Is the Track suitable ?");
                        bool excplicit = bool.Parse(Console.ReadLine());
                        Console.WriteLine("Item successfully added!");
                        rest.Put(new Tracks()
                        {
                            TrackID = trackid,
                            Title = tracktitle,
                            AlbumID = albumid,
                            ArtistID = artistid,
                            Plays = plays,
                            Duration = duration,
                            IsExplicit = excplicit,

                        }, "track");
                        Console.ReadKey();
                        MainMenu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Incorrect table name!");
                Console.ReadKey();
                MainMenu();
            }

        }
    }
}
