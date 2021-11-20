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
            Artists fakeartist= new Artists() { ArtistID = 1, Name = "Tyler, The Creator", Birthday = new DateTime(1991, 03, 06), Nationality = "United States", GrammyWinner = true };
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
        #region Független tesztek
        [TestCase(1)]
        public void AlbumDeleteExceptionTest(int id)
        {
            Assert.That(() => albumLogic.DeleteAlbum(id), Throws.TypeOf<KeyNotFoundException>());

        }
        [TestCase(78,"ValamiTitle",32,"ValamiLabel",null,null)]
        public void AlbumUpdateExceptionTest(int albumID, string Title, int ArtistID, string Label, TimeSpan length, DateTime releasedate)
        {
            Assert.That(() => albumLogic.UpdateAlbum(albumID,Title,ArtistID,Label,length,releasedate), Throws.TypeOf<KeyNotFoundException>());

        }
        #endregion
        #region CRUD tesztek
        [TestCase(1,"Álomkép",1,"Universal Music", null,null)]
        public void AlbumCreateTest(int albumID, string Title, int ArtistID, string Label, TimeSpan length, DateTime releasedate)
        {
            Assert.That(() => albumLogic.CreateAlbum(albumID, Title, ArtistID,Label, length, releasedate),Throws.TypeOf<ArgumentException>());

        }
        [TestCase(1,"Bereczki Zoltán",null,"Magyarország", false)]
        public void ArtistCreateTest(int ArtistID, string Name, DateTime Birthday, string nationality, bool grammywinner)
        {
            Assert.That(() => artistLogic.CreateArtist(ArtistID, Name, Birthday, nationality, grammywinner), Throws.TypeOf<ArgumentException>());
        }

        [TestCase(1, "Kerek Egész", 1, "Hungarian Pop", 525401,null,1)]
        public void TrackCreateTest(int TrackID, string Title, int AlbumID, string Genre, int plays, TimeSpan duration, int ArtistID)
        {
            Assert.That(() => trackLogic.CreateTrack(TrackID, Title, AlbumID, Genre, plays, duration, ArtistID), Throws.TypeOf<ArgumentException>());
        }
        #endregion
        //NON-CRUD tesztek




    }
}
