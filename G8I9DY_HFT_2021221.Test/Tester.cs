using G8I9DY_HFT_2021221.Logic;
using G8I9DY_HFT_2021221.Models;
using G8I9DY_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace G8I9DY_HFT_2021221.Test
{
    [TestFixture]
    public class Tester
    {
        AlbumLogic albumLogic;
        ArtistLogic artistLogic;
        TrackLogic trackLogic;

        [SetUp]
        public void Init()
        {
            var mockAlbumRepository = new Mock<IAlbumRepository>();
            var mockArtistRepository = new Mock<IArtistRepository>();
            var mockTrackRepository= new Mock<ITrackRepository>();
            Albums fakealbum = new Albums() { AlbumID = 1, Title = "Call Me If You Get Lost", ArtistID = 1, Label = "Columbia Records", Length = new TimeSpan(00, 52, 41), ReleaseDate = new DateTime(2020, 06, 25) };
            Artists fakeartist= new Artists() { ArtistID = 1, Name = "Tyler, The Creator", Birthday = "March 6, 1991", Nationality = "United States", GrammyWinner = true };
            var tracks = new List<Tracks>()
            {
                new Tracks()
                {
                    TrackID = 1,
                    Title = "WUSYANAME",
                    AlbumID = 1,
                    Genre = "R&B",
                    Plays= 92452833,
                    Duration=new TimeSpan(00,02,01),
                    ArtistID = 1
                },
                new Tracks()
                {
                    TrackID = 2,
                    Title = "LUMBERJACK",
                    AlbumID = 1,
                    Genre = "Hip-hop",
                    Plays= 53477915,
                    Duration=new TimeSpan(00,02,18),
                    ArtistID = 1
                }
            }.AsQueryable();
            var albums = new List<Albums> { fakealbum}.AsQueryable();
            var artists = new List<Artists> { fakeartist }.AsQueryable();
            mockAlbumRepository.Setup((t) => t.GetAll())
                .Returns(albums);
            mockArtistRepository.Setup((t) => t.GetAll())
                .Returns(artists);
            mockTrackRepository.Setup((t) => t.GetAll())
                .Returns(tracks);
            albumLogic = new AlbumLogic(mockAlbumRepository.Object);
            artistLogic = new ArtistLogic(mockArtistRepository.Object);
            trackLogic = new TrackLogic(mockTrackRepository.Object);
        }
        [TestCase(null)]
        public void AlbumCreateTest(int albumID, string Title, int ArtistID, string Label, TimeSpan length, DateTime releasedate)
        {

        }

    }
}
