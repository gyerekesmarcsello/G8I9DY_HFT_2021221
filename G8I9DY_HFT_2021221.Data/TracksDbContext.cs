using G8I9DY_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G8I9DY_HFT_2021221.Data
{
    class TracksDbContext : DbContext
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

            Albums album1 = new Albums() { AlbumID = 1, Title = "Call Me If You Get Lost", ArtistID = 1, Label = "Columbia Records" };
            Albums album2 = new Albums() { AlbumID = 2, Title = "Ösztönlény", ArtistID = 2, Label = "Universal Music Group" };
            Albums album3 = new Albums() { AlbumID = 3, Title = "Hot Pink", ArtistID = 3, Label = "RCA" };
            Albums album4 = new Albums() { AlbumID = 4, Title = "Awaken, My love!", ArtistID = 4, Label = "Glassnote" };
            Albums album5 = new Albums() { AlbumID = 5, Title = "Graduation", ArtistID = 5, Label = "Def Jam" };
            Albums album6 = new Albums() { AlbumID = 6, Title = "Nectar", ArtistID = 6, Label = "88rising" };
            Albums album7 = new Albums() { AlbumID = 7, Title = "OK Computer", ArtistID = 7, Label = "Parlophone" };

            Artists artist1 = new Artists() { ArtistID = 1, Name = "Tyler, The Creator", Birthday = "March 6, 1991", Country = "United States" };
            Artists artist2 = new Artists() { ArtistID = 2, Name = "Krúbi", Birthday = "November 17, 1994", Country = "Hungary" };
            Artists artist3 = new Artists() { ArtistID = 3, Name = "Doja Cat", Birthday = "October 21 1995", Country = "United States" };
            Artists artist4 = new Artists() { ArtistID = 4, Name = "Childish Gambino", Birthday = "September 25 1983", Country = "United States" };
            Artists artist5 = new Artists() { ArtistID = 5, Name = "Kanye West", Birthday = "June 8 1977", Country = "United States" };
            Artists artist6 = new Artists() { ArtistID = 6, Name = "Joji", Birthday = "September 18 1992", Country = "Japan" };
            Artists artist7 = new Artists() { ArtistID = 7, Name = "Radiohead", Birthday = "October 7 1968", Country = "England" };

            Tracks track1 = new Tracks() { TrackID = 1, Title = "WUSYANAME", AlbumID = 1, Genre = "R&B", ReleaseDate = "June 22, 2021", ArtistID = 1 };
            Tracks track2 = new Tracks() { TrackID = 2, Title = "JÉGHIDEG", AlbumID = 2, Genre = "Experimental", ReleaseDate = "March 23, 2020", ArtistID = 2 };
            Tracks track3 = new Tracks() { TrackID = 3, Title = "Say So", AlbumID = 3, Genre = "Pop", ReleaseDate = "November 7, 2019", ArtistID = 3 };
            Tracks track4 = new Tracks() { TrackID = 4, Title = "Redbone", AlbumID = 4, Genre = "Funk", ReleaseDate = "November 17, 2016", ArtistID = 4 };
            Tracks track5 = new Tracks() { TrackID = 5, Title = "I Wonder", AlbumID = 5, Genre = "Hip Hop", ReleaseDate = "August 28, 2007", ArtistID = 5 };
            Tracks track6 = new Tracks() { TrackID = 6, Title = "Run", AlbumID = 6, Genre = "Rock", ReleaseDate = "February 6, 2020", ArtistID = 6 };
            Tracks track7 = new Tracks() { TrackID = 7, Title = "Karma Police", AlbumID = 7, Genre = "Alternative", ReleaseDate = "August 25, 1997", ArtistID = 7 };

            modelBuilder.Entity<Albums>().HasData(album1, album2, album3, album4, album5, album6, album7);
            modelBuilder.Entity<Artists>().HasData(artist1, artist2, artist3, artist4, artist5, artist6, artist7);
            modelBuilder.Entity<Tracks>().HasData(track1, track2, track3, track4, track5, track6, track7);


        }


    }
}
