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
        public virtual DbSet<Albums> Albums { get; set; }

        public virtual DbSet<Artists> Artist { get; set; }

        public virtual DbSet<Tracks> Tracks { get; set; }

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
            modelBuilder.Entity<Tracks>(entity =>
            {
                entity
                .HasOne(tracks => tracks.Album)
                .WithMany(albums => albums.Tracks)
                .HasForeignKey(tracks => tracks.AlbumID)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<Tracks>(entity =>
            {
                entity
                .HasOne(tracks => tracks.Artist)
                .WithMany(artists => artists.Tracks)
                .HasForeignKey(tracks => tracks.ArtistID)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<Albums>(entity =>
            {
                entity
                .HasOne(albums => albums.Artist)
                .WithMany(artist => artist.Albums)
                .HasForeignKey(albums => albums.ArtistID)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            #region Albumok
            //TYLER THE CREATOR
            Albums album1 = new Albums() { AlbumID = 1, Title = "Call Me If You Get Lost", ArtistID = 1, Label = "Columbia Records", Length=new TimeSpan(00,52,41),ReleaseDate=new DateTime(2020,06,25), Genre = "Hip-hop" };
            Albums album2 = new Albums() { AlbumID = 2, Title = "Flower Boy", ArtistID = 1, Label = "Columbia Records", Length = new TimeSpan(00, 46, 33), ReleaseDate = new DateTime(2017, 07, 21), Genre = "Hip - hop" };
            //KRÚBI
            Albums album3 = new Albums() { AlbumID = 3, Title = "Ösztönlény", ArtistID = 2, Label = "Universal Music Group",Length = new TimeSpan(00, 52, 04), ReleaseDate = new DateTime(2020, 03, 23), Genre= "Hip-Hop" };
            Albums album4 = new Albums() { AlbumID = 4, Title = "Nehézlábérzés", ArtistID = 2, Label = "Universal Music Group", Length = new TimeSpan(00, 46, 32), ReleaseDate = new DateTime(2018, 05, 11), Genre="Hip-Hop" };
            //DOJA CAT
            Albums album5 = new Albums() { AlbumID = 5, Title = "Hot Pink", ArtistID = 3, Label = "RCA", Length = new TimeSpan(00, 39, 48), ReleaseDate = new DateTime(2019, 11, 07), Genre = "R&B" };
            Albums album6 = new Albums() { AlbumID = 6, Title = "Planet Her", ArtistID = 3, Label = "RCA", Length = new TimeSpan(00, 44, 06), ReleaseDate = new DateTime(2021, 06, 25),Genre= "Pop" };
            //GAMBINO
            Albums album7 = new Albums() { AlbumID = 7, Title = "Awaken, My love!", ArtistID = 4, Label = "Glassnote", Length = new TimeSpan(00, 48, 57), ReleaseDate = new DateTime(2020, 12, 02), Genre="R&B" };
            Albums album8 = new Albums() { AlbumID = 8, Title = "Because the Internet", ArtistID = 4, Label = "Glassnote", Length = new TimeSpan(00, 57, 52), ReleaseDate = new DateTime(2013, 12, 10), Genre="Hip-Hop"};
            //KANYE
            Albums album9 = new Albums() { AlbumID = 9, Title = "Graduation", ArtistID = 5, Label = "Def Jam", Length = new TimeSpan(00, 51, 23), ReleaseDate = new DateTime(2007, 09, 11),Genre ="Hip-Hop"};
            Albums album10 = new Albums() { AlbumID = 10, Title = "Yeezus", ArtistID = 5, Label = "Def Jam", Length = new TimeSpan(00, 40, 01), ReleaseDate = new DateTime(2013, 06, 18),Genre = "Hip-hop" };
            //JOJI
            Albums album11 = new Albums() { AlbumID = 11, Title = "Nectar", ArtistID = 6, Label = "88rising", Length = new TimeSpan(00, 53, 03), ReleaseDate = new DateTime(2020, 11, 25), Genre="Indie"};
            Albums album12 = new Albums() { AlbumID = 12, Title = "Ballads 1", ArtistID = 6, Label = "88rising", Length = new TimeSpan(00, 35, 06), ReleaseDate = new DateTime(2018, 10, 26),Genre= "R&B" };
            //RADIOHEAD
            Albums album13 = new Albums() { AlbumID = 13, Title = "OK Computer", ArtistID = 7, Label = "Parlophone", Length = new TimeSpan(00, 53, 27), ReleaseDate = new DateTime(1997, 05, 21), Genre = "Rock"};
            Albums album14 = new Albums() { AlbumID = 14, Title = "In Rainbows", ArtistID = 7, Label = "Self-released", Length = new TimeSpan(00, 42, 39), ReleaseDate = new DateTime(2007, 10, 10), Genre="Indie"};

            //TODO
            Albums album15 = new Albums() { AlbumID = 15, Title = "WILLBEDELETED", ArtistID = 1, Label = "WILLBEDELETED", Length = new TimeSpan(00, 04, 20), ReleaseDate = new DateTime(2069, 04, 20), Genre = "WILLBEDELETED" };
            Albums album16 = new Albums() { AlbumID = 16, Title = "WILLBEUPDATED", ArtistID = 1, Label = "WILLBEUPDATED", Length = new TimeSpan(00, 04, 20), ReleaseDate = new DateTime(2069, 04, 20), Genre = "WILLBEUPDATED" };
            #endregion
            #region Artists
            Artists artist1 = new Artists() { ArtistID = 1, Name = "Tyler, The Creator", Birthday = new DateTime(1991,03,06), Nationality = "United States",GrammyWinner=true };
            Artists artist2 = new Artists() { ArtistID = 2, Name = "Krúbi", Birthday = new DateTime(1994, 11, 17), Nationality = "Hungary", GrammyWinner = false };
            Artists artist3 = new Artists() { ArtistID = 3, Name = "Doja Cat", Birthday = new DateTime(1995, 10, 21), Nationality = "United States", GrammyWinner = false };
            Artists artist4 = new Artists() { ArtistID = 4, Name = "Childish Gambino", Birthday = new DateTime(1983, 09, 25), Nationality = "United States", GrammyWinner = true };
            Artists artist5 = new Artists() { ArtistID = 5, Name = "Kanye West", Birthday = new DateTime(1977, 06, 08), Nationality = "United States", GrammyWinner = true };
            Artists artist6 = new Artists() { ArtistID = 6, Name = "Joji", Birthday = new DateTime(1992, 09, 18), Nationality = "Japan", GrammyWinner = false };
            Artists artist7 = new Artists() { ArtistID = 7, Name = "Radiohead", Birthday = new DateTime(1968, 11, 07), Nationality = "England", GrammyWinner = true };
            //TODO
            Artists artist8 = new Artists() { ArtistID = 8, Name = "WILLBEDELETED", Birthday = new DateTime(1969, 04, 20), Nationality = "WILLBEDELETED", GrammyWinner = true };
            Artists artist9 = new Artists() { ArtistID = 9, Name = "WILLBEUPDATED", Birthday = new DateTime(1969, 04, 20), Nationality = "WILLBEUPDATED", GrammyWinner = true };

            #endregion
            #region Számok
            //TYLER
            Tracks track1 = new Tracks() { TrackID = 1, Title = "WUSYANAME", AlbumID = 1, Plays= 92452833,Duration=new TimeSpan(00,02,01), ArtistID = 1,IsExplicit = true };
            Tracks track2 = new Tracks() { TrackID = 2, Title = "LUMBERJACK", AlbumID = 1, Plays = 53477915, Duration = new TimeSpan(00, 02, 18), ArtistID = 1,IsExplicit=true};
            Tracks track3 = new Tracks() { TrackID = 3, Title = "MANIFESTO", AlbumID = 1, Plays = 19483580, Duration = new TimeSpan(00, 02, 55), ArtistID = 1, IsExplicit = true };

            Tracks track4 = new Tracks() { TrackID = 4, Title = "See You Again", AlbumID = 2, Plays = 448443147, Duration = new TimeSpan(00, 03, 00), ArtistID = 1, IsExplicit = true };
            Tracks track5 = new Tracks() { TrackID = 5, Title = "Garden Shed", AlbumID = 2, Plays = 57885737, Duration = new TimeSpan(00, 03, 43), ArtistID = 1, IsExplicit = true };
            Tracks track6 = new Tracks() { TrackID = 6, Title = "Boredom", AlbumID = 2, Plays = 214694024, Duration = new TimeSpan(00, 05, 20), ArtistID = 1, IsExplicit = true };
            //KRÚBI
            Tracks track7 = new Tracks() { TrackID = 7, Title = "JÉGHIDEG", AlbumID = 3, Plays = 728261, Duration = new TimeSpan(00, 07, 11), ArtistID = 2,IsExplicit = true };
            Tracks track8 = new Tracks() { TrackID = 8, Title = "LEJTŐ", AlbumID = 3, Plays = 1559344, Duration = new TimeSpan(00, 04, 25), ArtistID = 2, IsExplicit = true };
            Tracks track9 = new Tracks() { TrackID = 9, Title = "KUTYA", AlbumID = 3, Plays = 873112, Duration = new TimeSpan(00, 05, 23), ArtistID = 2, IsExplicit = true };

            Tracks track10 = new Tracks() { TrackID = 10, Title = "PestiEst", AlbumID = 4, Plays = 2960427, Duration = new TimeSpan(00, 03, 32), ArtistID = 2 ,IsExplicit = true };
            Tracks track11 = new Tracks() { TrackID = 11, Title = "SCHMUCK", AlbumID = 4, Plays = 1030281, Duration = new TimeSpan(00, 02, 59), ArtistID = 2, IsExplicit = false };
            Tracks track12 = new Tracks() { TrackID = 12, Title = "Egy Sírásó Viccei", AlbumID = 4, Plays = 375212, Duration = new TimeSpan(00, 05, 05), ArtistID = 2, IsExplicit = true };
            //DOJA CAT
            Tracks track13 = new Tracks() { TrackID = 13, Title = "Say So", AlbumID = 5, Plays = 868337709, Duration = new TimeSpan(00, 03, 57), ArtistID = 3, IsExplicit = true };
            Tracks track14 = new Tracks() { TrackID = 14, Title = "Cyber sex", AlbumID = 5, Plays = 153710317, Duration = new TimeSpan(00, 02, 45), ArtistID = 3, IsExplicit = true };
            Tracks track15 = new Tracks() { TrackID = 15, Title = "Streets", AlbumID = 5, Plays = 492478498, Duration = new TimeSpan(00, 03, 46), ArtistID = 3, IsExplicit = true };

            Tracks track16 = new Tracks() { TrackID = 16, Title = "Woman", AlbumID = 6, Plays = 408457890, Duration = new TimeSpan(00, 02, 52), ArtistID = 3, IsExplicit = true };
            Tracks track17 = new Tracks() { TrackID = 17, Title = "Need to Know", AlbumID = 6, Plays = 439020022, Duration = new TimeSpan(00, 03, 30), ArtistID = 3, IsExplicit = true };
            Tracks track18 = new Tracks() { TrackID = 18, Title = "You Right", AlbumID = 6, Plays = 206425584, Duration = new TimeSpan(00, 03, 06), ArtistID = 3, IsExplicit = true };
            //CHILDISH GAMBINO
            Tracks track19 = new Tracks() { TrackID = 19, Title = "Redbone", AlbumID = 7, Plays = 1023428431, Duration = new TimeSpan(00, 05, 26), ArtistID = 4, IsExplicit = true };
            Tracks track20 = new Tracks() { TrackID = 20, Title = "Me and Your Mama", AlbumID = 7, Plays = 126122416, Duration = new TimeSpan(00, 06, 19), ArtistID = 4, IsExplicit = false};
            Tracks track21 = new Tracks() { TrackID = 21, Title = "Have Some Love", AlbumID = 7, Plays = 35135795, Duration = new TimeSpan(00, 03, 44), ArtistID = 4, IsExplicit = false };

            Tracks track22 = new Tracks() { TrackID = 22, Title = "Worldstar", AlbumID = 8, Plays = 55673808, Duration = new TimeSpan(00, 04, 04), ArtistID = 4, IsExplicit = true };
            Tracks track23 = new Tracks() { TrackID = 23, Title = "Sweatpants", AlbumID = 8, Plays = 325882511, Duration = new TimeSpan(00, 03, 00), ArtistID = 4, IsExplicit = true };
            Tracks track24 = new Tracks() { TrackID = 24, Title = "3005", AlbumID = 8, Plays = 509695148, Duration = new TimeSpan(00, 03, 54), ArtistID = 4, IsExplicit = true };
            //KANYE
            Tracks track25 = new Tracks() { TrackID = 25, Title = "I Wonder", AlbumID = 9, Plays = 148588843, Duration = new TimeSpan(00, 04, 03), ArtistID = 5, IsExplicit = true };
            Tracks track26 = new Tracks() { TrackID = 26, Title = "Homecoming", AlbumID = 9, Plays = 256386074, Duration = new TimeSpan(00, 03, 23), ArtistID = 5, IsExplicit = true };
            Tracks track27 = new Tracks() { TrackID = 27, Title = "Stronger", AlbumID = 9, Plays = 910676613, Duration = new TimeSpan(00, 05, 11), ArtistID = 5, IsExplicit = true };

            Tracks track28 = new Tracks() { TrackID = 28, Title = "Black Skinhead", AlbumID = 10, Plays = 434865663, Duration = new TimeSpan(00, 03, 08), ArtistID = 5, IsExplicit = true };
            Tracks track29 = new Tracks() { TrackID = 29, Title = "Bound 2", AlbumID = 10, Plays = 280091647, Duration = new TimeSpan(00, 03, 49), ArtistID = 5, IsExplicit = true };
            Tracks track30 = new Tracks() { TrackID = 30, Title = "New Slaves", AlbumID = 10, Plays = 94430899, Duration = new TimeSpan(00, 04, 16), ArtistID = 5, IsExplicit = true };

            //JOJI
            Tracks track31 = new Tracks() { TrackID = 31, Title = "Run", AlbumID = 11, Plays = 165988821, Duration = new TimeSpan(00, 03, 15), ArtistID = 6, IsExplicit = false };
            Tracks track32 = new Tracks() { TrackID = 32, Title = "Aftertought", AlbumID = 11, Plays = 56967771, Duration = new TimeSpan(00, 03, 14), ArtistID = 6, IsExplicit = false };
            Tracks track33 = new Tracks() { TrackID = 33, Title = "Like You Do", AlbumID = 11, Plays = 57788584, Duration = new TimeSpan(00, 04, 00), ArtistID = 6, IsExplicit = false };

            Tracks track34 = new Tracks() { TrackID = 34, Title = "SLOW DANCING IN THE DARK", AlbumID = 12, Plays = 718658337, Duration = new TimeSpan(00, 03, 29), ArtistID = 6, IsExplicit = true };
            Tracks track35 = new Tracks() { TrackID = 35, Title = "CAN'T GET OVER YOU", AlbumID = 12, Plays = 190897372, Duration = new TimeSpan(00, 01, 47), ArtistID = 6, IsExplicit = false };
            Tracks track36 = new Tracks() { TrackID = 36, Title = "TEST DRIVE", AlbumID = 12, Plays = 159320678, Duration = new TimeSpan(00, 02, 59), ArtistID = 6, IsExplicit = true };
            //RADIOHEAD
            Tracks track37 = new Tracks() { TrackID = 37, Title = "Karma Police", AlbumID = 13, Plays = 300834753, Duration = new TimeSpan(00, 04, 24), ArtistID = 7, IsExplicit=false};
            Tracks track38 = new Tracks() { TrackID = 38, Title = "No Surprises", AlbumID = 13, Plays = 213815947, Duration = new TimeSpan(00, 03, 49), ArtistID = 7, IsExplicit = false };
            Tracks track39 = new Tracks() { TrackID = 39, Title = "Paranoid Android", AlbumID = 13, Plays = 131042474, Duration = new TimeSpan(00, 06, 27), ArtistID = 7, IsExplicit = false };

            Tracks track40 = new Tracks() { TrackID = 40, Title = "Nude", AlbumID = 14, Plays = 300834753, Duration = new TimeSpan(00, 04, 24), ArtistID = 7, IsExplicit = false };
            Tracks track41 = new Tracks() { TrackID = 41, Title = "House Of Cards", AlbumID = 14, Plays = 45572524, Duration = new TimeSpan(00, 05, 28), ArtistID = 7, IsExplicit = false };
            Tracks track42 = new Tracks() { TrackID = 42, Title = "Reckoner", AlbumID = 14, Plays = 50375856, Duration = new TimeSpan(00, 04, 50), ArtistID = 7, IsExplicit = false };

            //WILLBE
            Tracks track43 = new Tracks() { TrackID = 43, Title = "WILLBEDELETED", AlbumID = 1, Plays = 69420, Duration = new TimeSpan(00, 04, 20), ArtistID = 1, IsExplicit = false };
            Tracks track44 = new Tracks() { TrackID = 44, Title = "WILLBEUPDATED", AlbumID = 1, Plays = 69420, Duration = new TimeSpan(00, 04, 20), ArtistID = 1, IsExplicit = false };
            #endregion

            modelBuilder.Entity<Albums>().HasData(album1, album2, album3, album4, album5, album6, album7, album8, album9, album10, album11, album12, album13, album14,album15,album16);
            modelBuilder.Entity<Artists>().HasData(artist1, artist2, artist3, artist4, artist5, artist6, artist7,artist8,artist9);
            modelBuilder.Entity<Tracks>().HasData(track1, track2, track3, track4, track5, track6, track7,
                                                  track8, track9, track10, track11, track12, track13, track14,
                                                  track15, track16, track17, track18, track19, track21, track22,
                                                  track23, track24, track25, track26, track27, track28, track29,
                                                  track30, track31, track32, track33, track34, track35, track36,
                                                  track37, track38, track39, track40, track41, track42, track43,track44);


        }


    }
}
