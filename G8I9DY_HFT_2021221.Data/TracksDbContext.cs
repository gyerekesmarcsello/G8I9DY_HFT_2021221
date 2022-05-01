using G8I9DY_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G8I9DY_HFT_2021221.Data
{
    public class TracksDbContext : DbContext
    {
        public virtual DbSet<Album> Albums { get; set; }

        public virtual DbSet<Artist> Artist { get; set; }

        public virtual DbSet<Track> Tracks { get; set; }

        public TracksDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\LocalDB.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Track>(entity =>
            {
                entity
                .HasOne(tracks => tracks.Album)
                .WithMany(albums => albums.Tracks)
                .HasForeignKey(tracks => tracks.AlbumID)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<Track>(entity =>
            {
                entity
                .HasOne(tracks => tracks.Artist)
                .WithMany(artists => artists.Tracks)
                .HasForeignKey(tracks => tracks.ArtistID)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<Album>(entity =>
            {
                entity
                .HasOne(albums => albums.Artist)
                .WithMany(artists => artists.Albums)
                .HasForeignKey(albums => albums.ArtistID)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            #region Albumok
            //TYLER THE CREATOR
            Album album1 = new Album() { AlbumID = 1, Title = "Call Me If You Get Lost", ArtistID = 1, Label = "Columbia Records", Length=new TimeSpan(00,52,41),ReleaseDate=new DateTime(2020,06,25), Genre = "Hip hop" };
            Album album2 = new Album() { AlbumID = 2, Title = "Flower Boy", ArtistID = 1, Label = "Columbia Records", Length = new TimeSpan(00, 46, 33), ReleaseDate = new DateTime(2017, 07, 21), Genre = "Hip Hop" };
            //KRÚBI
            Album album3 = new Album() { AlbumID = 3, Title = "Ösztönlény", ArtistID = 2, Label = "Universal Music Group",Length = new TimeSpan(00, 52, 04), ReleaseDate = new DateTime(2020, 03, 23), Genre= "Hip Hop" };
            Album album4 = new Album() { AlbumID = 4, Title = "Nehézlábérzés", ArtistID = 2, Label = "Universal Music Group", Length = new TimeSpan(00, 46, 32), ReleaseDate = new DateTime(2018, 05, 11), Genre="Hip Hop" };
            //DOJA CAT
            Album album5 = new Album() { AlbumID = 5, Title = "Hot Pink", ArtistID = 3, Label = "RCA", Length = new TimeSpan(00, 39, 48), ReleaseDate = new DateTime(2019, 11, 07), Genre = "Soul" };
            Album album6 = new Album() { AlbumID = 6, Title = "Planet Her", ArtistID = 3, Label = "RCA", Length = new TimeSpan(00, 44, 06), ReleaseDate = new DateTime(2021, 06, 25),Genre= "Pop" };
            //GAMBINO
            Album album7 = new Album() { AlbumID = 7, Title = "Awaken, My love!", ArtistID = 4, Label = "Glassnote", Length = new TimeSpan(00, 48, 57), ReleaseDate = new DateTime(2020, 12, 02), Genre= "Soul" };
            Album album8 = new Album() { AlbumID = 8, Title = "Because the Internet", ArtistID = 4, Label = "Glassnote", Length = new TimeSpan(00, 57, 52), ReleaseDate = new DateTime(2013, 12, 10), Genre="Hip Hop"};
            //KANYE
            Album album9 = new Album() { AlbumID = 9, Title = "Graduation", ArtistID = 5, Label = "Def Jam", Length = new TimeSpan(00, 51, 23), ReleaseDate = new DateTime(2007, 09, 11),Genre ="Hip Hop"};
            Album album10 = new Album() { AlbumID = 10, Title = "Yeezus", ArtistID = 5, Label = "Def Jam", Length = new TimeSpan(00, 40, 01), ReleaseDate = new DateTime(2013, 06, 18),Genre = "Hip Hop" };
            //JOJI
            Album album11 = new Album() { AlbumID = 11, Title = "Nectar", ArtistID = 6, Label = "88rising", Length = new TimeSpan(00, 53, 03), ReleaseDate = new DateTime(2020, 11, 25), Genre="Indie"};
            Album album12 = new Album() { AlbumID = 12, Title = "Ballads 1", ArtistID = 6, Label = "88rising", Length = new TimeSpan(00, 35, 06), ReleaseDate = new DateTime(2018, 10, 26),Genre= "Soul" };
            //RADIOHEAD
            Album album13 = new Album() { AlbumID = 13, Title = "OK Computer", ArtistID = 7, Label = "Parlophone", Length = new TimeSpan(00, 53, 27), ReleaseDate = new DateTime(1997, 05, 21), Genre = "Rock"};
            Album album14 = new Album() { AlbumID = 14, Title = "In Rainbows", ArtistID = 7, Label = "Self-released", Length = new TimeSpan(00, 42, 39), ReleaseDate = new DateTime(2007, 10, 10), Genre="Indie"};

            //TODO
            Album album15 = new Album() { AlbumID = 15, Title = "WILLBEDELETED", ArtistID = 9, Label = "WILLBEDELETED", Length = new TimeSpan(00, 04, 20), ReleaseDate = new DateTime(2069, 04, 20), Genre = "WILLBEDELETED" };
            Album album16 = new Album() { AlbumID = 16, Title = "WILLBEUPDATED", ArtistID = 9, Label = "WILLBEUPDATED", Length = new TimeSpan(00, 04, 20), ReleaseDate = new DateTime(2069, 04, 20), Genre = "WILLBEUPDATED" };
            #endregion
            #region Artists
            Artist artist1 = new Artist() { ArtistID = 1, Name = "Tyler, The Creator", Birthday = new DateTime(1991,03,06), Nationality = "United States",GrammyWinner=true };
            Artist artist2 = new Artist() { ArtistID = 2, Name = "Krúbi", Birthday = new DateTime(1994, 11, 17), Nationality = "Hungary", GrammyWinner = false };
            Artist artist3 = new Artist() { ArtistID = 3, Name = "Doja Cat", Birthday = new DateTime(1995, 10, 21), Nationality = "United States", GrammyWinner = false };
            Artist artist4 = new Artist() { ArtistID = 4, Name = "Childish Gambino", Birthday = new DateTime(1983, 09, 25), Nationality = "United States", GrammyWinner = true };
            Artist artist5 = new Artist() { ArtistID = 5, Name = "Kanye West", Birthday = new DateTime(1977, 06, 08), Nationality = "United States", GrammyWinner = true };
            Artist artist6 = new Artist() { ArtistID = 6, Name = "Joji", Birthday = new DateTime(1992, 09, 18), Nationality = "Japan", GrammyWinner = false };
            Artist artist7 = new Artist() { ArtistID = 7, Name = "Radiohead", Birthday = new DateTime(1968, 11, 07), Nationality = "England", GrammyWinner = true };
            //TODO
            Artist artist8 = new Artist() { ArtistID = 8, Name = "WILLBEDELETED", Birthday = new DateTime(1969, 04, 20), Nationality = "WILLBEDELETED", GrammyWinner = true };
            Artist artist9 = new Artist() { ArtistID = 9, Name = "WILLBEUPDATED", Birthday = new DateTime(1969, 04, 20), Nationality = "WILLBEUPDATED", GrammyWinner = true };

            #endregion
            #region Számok
            //TYLER
            Track track1 = new Track() { TrackID = 1, Title = "WUSYANAME", AlbumID = 1, Plays= 92452833,Duration=new TimeSpan(00,02,01), ArtistID = 1,IsExplicit = true };
            Track track2 = new Track() { TrackID = 2, Title = "LUMBERJACK", AlbumID = 1, Plays = 53477915, Duration = new TimeSpan(00, 02, 18), ArtistID = 1,IsExplicit=true};
            Track track3 = new Track() { TrackID = 3, Title = "MANIFESTO", AlbumID = 1, Plays = 19483580, Duration = new TimeSpan(00, 02, 55), ArtistID = 1, IsExplicit = true };

            Track track4 = new Track() { TrackID = 4, Title = "See You Again", AlbumID = 2, Plays = 448443147, Duration = new TimeSpan(00, 03, 00), ArtistID = 1, IsExplicit = true };
            Track track5 = new Track() { TrackID = 5, Title = "Garden Shed", AlbumID = 2, Plays = 57885737, Duration = new TimeSpan(00, 03, 43), ArtistID = 1, IsExplicit = true };
            Track track6 = new Track() { TrackID = 6, Title = "Boredom", AlbumID = 2, Plays = 214694024, Duration = new TimeSpan(00, 05, 20), ArtistID = 1, IsExplicit = true };
            //KRÚBI
            Track track7 = new Track() { TrackID = 7, Title = "JÉGHIDEG", AlbumID = 3, Plays = 728261, Duration = new TimeSpan(00, 07, 11), ArtistID = 2,IsExplicit = true };
            Track track8 = new Track() { TrackID = 8, Title = "LEJTŐ", AlbumID = 3, Plays = 1559344, Duration = new TimeSpan(00, 04, 25), ArtistID = 2, IsExplicit = true };
            Track track9 = new Track() { TrackID = 9, Title = "KUTYA", AlbumID = 3, Plays = 873112, Duration = new TimeSpan(00, 05, 23), ArtistID = 2, IsExplicit = true };

            Track track10 = new Track() { TrackID = 10, Title = "PestiEst", AlbumID = 4, Plays = 2960427, Duration = new TimeSpan(00, 03, 32), ArtistID = 2 ,IsExplicit = true };
            Track track11 = new Track() { TrackID = 11, Title = "SCHMUCK", AlbumID = 4, Plays = 1030281, Duration = new TimeSpan(00, 02, 59), ArtistID = 2, IsExplicit = false };
            Track track12 = new Track() { TrackID = 12, Title = "Egy Sírásó Viccei", AlbumID = 4, Plays = 375212, Duration = new TimeSpan(00, 05, 05), ArtistID = 2, IsExplicit = true };
            //DOJA CAT
            Track track13 = new Track() { TrackID = 13, Title = "Say So", AlbumID = 5, Plays = 868337709, Duration = new TimeSpan(00, 03, 57), ArtistID = 3, IsExplicit = true };
            Track track14 = new Track() { TrackID = 14, Title = "Cyber sex", AlbumID = 5, Plays = 153710317, Duration = new TimeSpan(00, 02, 45), ArtistID = 3, IsExplicit = true };
            Track track15 = new Track() { TrackID = 15, Title = "Streets", AlbumID = 5, Plays = 492478498, Duration = new TimeSpan(00, 03, 46), ArtistID = 3, IsExplicit = true };

            Track track16 = new Track() { TrackID = 16, Title = "Woman", AlbumID = 6, Plays = 408457890, Duration = new TimeSpan(00, 02, 52), ArtistID = 3, IsExplicit = true };
            Track track17 = new Track() { TrackID = 17, Title = "Need to Know", AlbumID = 6, Plays = 439020022, Duration = new TimeSpan(00, 03, 30), ArtistID = 3, IsExplicit = true };
            Track track18 = new Track() { TrackID = 18, Title = "You Right", AlbumID = 6, Plays = 206425584, Duration = new TimeSpan(00, 03, 06), ArtistID = 3, IsExplicit = true };
            //CHILDISH GAMBINO
            Track track19 = new Track() { TrackID = 19, Title = "Redbone", AlbumID = 7, Plays = 1023428431, Duration = new TimeSpan(00, 05, 26), ArtistID = 4, IsExplicit = true };
            Track track20 = new Track() { TrackID = 20, Title = "Me and Your Mama", AlbumID = 7, Plays = 126122416, Duration = new TimeSpan(00, 06, 19), ArtistID = 4, IsExplicit = false};
            Track track21 = new Track() { TrackID = 21, Title = "Have Some Love", AlbumID = 7, Plays = 35135795, Duration = new TimeSpan(00, 03, 44), ArtistID = 4, IsExplicit = false };

            Track track22 = new Track() { TrackID = 22, Title = "Worldstar", AlbumID = 8, Plays = 55673808, Duration = new TimeSpan(00, 04, 04), ArtistID = 4, IsExplicit = true };
            Track track23 = new Track() { TrackID = 23, Title = "Sweatpants", AlbumID = 8, Plays = 325882511, Duration = new TimeSpan(00, 03, 00), ArtistID = 4, IsExplicit = true };
            Track track24 = new Track() { TrackID = 24, Title = "3005", AlbumID = 8, Plays = 509695148, Duration = new TimeSpan(00, 03, 54), ArtistID = 4, IsExplicit = true };
            //KANYE
            Track track25 = new Track() { TrackID = 25, Title = "I Wonder", AlbumID = 9, Plays = 148588843, Duration = new TimeSpan(00, 04, 03), ArtistID = 5, IsExplicit = true };
            Track track26 = new Track() { TrackID = 26, Title = "Homecoming", AlbumID = 9, Plays = 256386074, Duration = new TimeSpan(00, 03, 23), ArtistID = 5, IsExplicit = true };
            Track track27 = new Track() { TrackID = 27, Title = "Stronger", AlbumID = 9, Plays = 910676613, Duration = new TimeSpan(00, 05, 11), ArtistID = 5, IsExplicit = true };

            Track track28 = new Track() { TrackID = 28, Title = "Black Skinhead", AlbumID = 10, Plays = 434865663, Duration = new TimeSpan(00, 03, 08), ArtistID = 5, IsExplicit = true };
            Track track29 = new Track() { TrackID = 29, Title = "Bound 2", AlbumID = 10, Plays = 280091647, Duration = new TimeSpan(00, 03, 49), ArtistID = 5, IsExplicit = true };
            Track track30 = new Track() { TrackID = 30, Title = "New Slaves", AlbumID = 10, Plays = 94430899, Duration = new TimeSpan(00, 04, 16), ArtistID = 5, IsExplicit = true };

            //JOJI
            Track track31 = new Track() { TrackID = 31, Title = "Run", AlbumID = 11, Plays = 165988821, Duration = new TimeSpan(00, 03, 15), ArtistID = 6, IsExplicit = false };
            Track track32 = new Track() { TrackID = 32, Title = "Aftertought", AlbumID = 11, Plays = 56967771, Duration = new TimeSpan(00, 03, 14), ArtistID = 6, IsExplicit = false };
            Track track33 = new Track() { TrackID = 33, Title = "Like You Do", AlbumID = 11, Plays = 57788584, Duration = new TimeSpan(00, 04, 00), ArtistID = 6, IsExplicit = false };

            Track track34 = new Track() { TrackID = 34, Title = "SLOW DANCING IN THE DARK", AlbumID = 12, Plays = 718658337, Duration = new TimeSpan(00, 03, 29), ArtistID = 6, IsExplicit = true };
            Track track35 = new Track() { TrackID = 35, Title = "CAN'T GET OVER YOU", AlbumID = 12, Plays = 190897372, Duration = new TimeSpan(00, 01, 47), ArtistID = 6, IsExplicit = false };
            Track track36 = new Track() { TrackID = 36, Title = "TEST DRIVE", AlbumID = 12, Plays = 159320678, Duration = new TimeSpan(00, 02, 59), ArtistID = 6, IsExplicit = true };
            //RADIOHEAD
            Track track37 = new Track() { TrackID = 37, Title = "Karma Police", AlbumID = 13, Plays = 300834753, Duration = new TimeSpan(00, 04, 24), ArtistID = 7, IsExplicit=false};
            Track track38 = new Track() { TrackID = 38, Title = "No Surprises", AlbumID = 13, Plays = 213815947, Duration = new TimeSpan(00, 03, 49), ArtistID = 7, IsExplicit = false };
            Track track39 = new Track() { TrackID = 39, Title = "Paranoid Android", AlbumID = 13, Plays = 131042474, Duration = new TimeSpan(00, 06, 27), ArtistID = 7, IsExplicit = false };

            Track track40 = new Track() { TrackID = 40, Title = "Nude", AlbumID = 14, Plays = 300834753, Duration = new TimeSpan(00, 04, 24), ArtistID = 7, IsExplicit = false };
            Track track41 = new Track() { TrackID = 41, Title = "House Of Cards", AlbumID = 14, Plays = 45572524, Duration = new TimeSpan(00, 05, 28), ArtistID = 7, IsExplicit = false };
            Track track42 = new Track() { TrackID = 42, Title = "Reckoner", AlbumID = 14, Plays = 50375856, Duration = new TimeSpan(00, 04, 50), ArtistID = 7, IsExplicit = false };

            //WILLBE
            Track track43 = new Track() { TrackID = 43, Title = "WILLBEDELETED", AlbumID = 15, Plays = 69420, Duration = new TimeSpan(00, 04, 20), ArtistID = 9, IsExplicit = false };
            Track track44 = new Track() { TrackID = 44, Title = "WILLBEUPDATED", AlbumID = 16, Plays = 69420, Duration = new TimeSpan(00, 04, 20), ArtistID = 9, IsExplicit = false };
            #endregion

            modelBuilder.Entity<Album>().HasData(album1, album2, album3, album4, album5, album6, album7, album8, album9, album10, album11, album12, album13, album14,album15,album16);
            modelBuilder.Entity<Artist>().HasData(artist1, artist2, artist3, artist4, artist5, artist6, artist7,artist8,artist9);
            modelBuilder.Entity<Track>().HasData(track1, track2, track3, track4, track5, track6, track7,
                                                  track8, track9, track10, track11, track12, track13, track14,
                                                  track15, track16, track17, track18, track19, track20, track21, track22,
                                                  track23, track24, track25, track26, track27, track28, track29,
                                                  track30, track31, track32, track33, track34, track35, track36,
                                                  track37, track38, track39, track40, track41, track42, track43,track44);


        }


    }
}
