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
            Albums fakealbum = new Albums() { AlbumID = 1, Title = "Álomkép", ArtistID = 1, Label = "Universal Music", Length = new TimeSpan(00, 42, 55), ReleaseDate = new DateTime(2010, 01, 01),Genre="Hungarian Pop" };
            Artists fakeartist= new Artists() { ArtistID = 1, Name = "Bereczki Zoltán", Birthday = new DateTime(1976, 05, 02), Nationality = "Hungary", GrammyWinner = false };
            var tracks = new List<Tracks>()
            {
                new Tracks()
                {
                    TrackID = 1,
                    Title = "Kerek Egész",
                    AlbumID = 1,
                    Plays= 525401,
                    Duration=new TimeSpan(00,02,53),
                    ArtistID = 1,
                    IsExplicit = false
                },
                new Tracks()
                {
                    TrackID = 2,
                    Title = "Szállj velem!",
                    AlbumID = 1,
                    Plays= 103094,
                    Duration=new TimeSpan(00,02,18),
                    ArtistID = 1,
                    IsExplicit = false
                },
                new Tracks()
                {
                    TrackID = 3,
                    Title = "1001 Éjjel",
                    AlbumID = 1,
                    Plays= 19098,
                    Duration=new TimeSpan(00,04,02),
                    ArtistID = 1,
                    IsExplicit = false
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
        [TestCase(78,"ValamiTitle",32,"ValamiLabel",null,null,"Trash")]
        public void AlbumUpdateExceptionTest(int albumID, string Title, int ArtistID, string Label, TimeSpan length, DateTime releasedate, string Genre)
        {
            Assert.That(() => albumLogic.UpdateAlbum(albumID,Title,ArtistID,Label,length,releasedate,Genre), Throws.TypeOf<KeyNotFoundException>());

        }
        #endregion
        #region CRUD tesztek
        [TestCase(1,"Álomkép",1,"Universal Music", null,null,"Trash")]
        public void AlbumCreateTest(int albumID, string Title, int ArtistID, string Label, TimeSpan length, DateTime releasedate,string Genre)
        {
            Assert.That(() => albumLogic.CreateAlbum(albumID, Title, ArtistID,Label, length, releasedate,Genre),Throws.TypeOf<ArgumentException>());

        }
        [TestCase(1,"Bereczki Zoltán",null,"Hungary", false)]
        public void ArtistCreateTest(int ArtistID, string Name, DateTime Birthday, string nationality, bool grammywinner)
        {
            Assert.That(() => artistLogic.CreateArtist(ArtistID, Name, Birthday, nationality, grammywinner), Throws.TypeOf<ArgumentException>());
        }

        [TestCase(1, "Kerek Egész", 1, "Hungarian Pop", 525401,null,1)]
        public void TrackCreateTest(int TrackID, string Title, int AlbumID, int plays, TimeSpan duration, int ArtistID,bool IsExplicit)
        {
            Assert.That(() => trackLogic.CreateTrack(TrackID, Title, AlbumID, plays, duration, ArtistID,IsExplicit), Throws.TypeOf<ArgumentException>());
        }
        #endregion
        //NON-CRUD tesztek




    }
}
