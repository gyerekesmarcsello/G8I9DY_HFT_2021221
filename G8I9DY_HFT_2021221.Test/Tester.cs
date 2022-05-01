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
            var mockTrackRepository = new Mock<ITrackRepository>();
            var fakeartist = new List<Artist>()
        {   new Artist()
            {
                ArtistID = 1,
                Name = "Bereczki Zoltán",
                Birthday = new DateTime(1976, 05, 02),
                Nationality = "Hungary",
                GrammyWinner = false,              
         }
         }.AsQueryable();

            var fakealbum = new List<Album>()
        {   new Album()
            {
                AlbumID = 1,
                Title = "Álomkép",
                Label = "Universal Music",
                Length = new TimeSpan(00, 42, 55),
                ReleaseDate = new DateTime(2010, 01, 01),
                Genre="Hungarian Pop",
                Artist = fakeartist.FirstOrDefault()
         }
         }.AsQueryable();

            var tracks = new List<Track>()
           {
                new Track()
                {
                    TrackID = 1,
                    Title = "Kerek Egész",
                    Plays= 525401,
                    Duration=new TimeSpan(00,02,53),
                    IsExplicit = false,
                    Album=fakealbum.FirstOrDefault(),
                    Artist=fakeartist.FirstOrDefault()

                },
                new Track()
                {
                    TrackID = 2,
                    Title = "Szállj velem!",
                    Plays= 103094,
                    Duration=new TimeSpan(00,02,18),
                    IsExplicit = false,
                    Album=fakealbum.FirstOrDefault(),
                    Artist=fakeartist.FirstOrDefault()
                },
                new Track()
                {
                    TrackID = 3,
                    Title = "1001 Éjjel",
                    Plays= 19100,
                    Duration=new TimeSpan(00,04,04),
                    IsExplicit = false,
                    Album=fakealbum.FirstOrDefault(),
                    Artist=fakeartist.FirstOrDefault(),
                }
            }.AsQueryable();
            
            mockArtistRepository.Setup((t) => t.GetAll()).Returns(fakeartist);
            mockAlbumRepository.Setup((t) => t.GetAll()).Returns(fakealbum);
            mockTrackRepository.Setup((t) => t.GetAll()).Returns(tracks);
            mockArtistRepository.Setup(x => x.ReadArtist(It.IsAny<int>())).Returns(
             new Artist()
             {
                 ArtistID = 1,
                 Name = "Bereczki Zoltán",
                 Birthday = new DateTime(1976, 05, 02),
                 Nationality = "Hungary",
                 GrammyWinner = false,
             });

            albumLogic = new AlbumLogic(mockAlbumRepository.Object,mockTrackRepository.Object,mockArtistRepository.Object);
            artistLogic = new ArtistLogic(mockArtistRepository.Object,mockTrackRepository.Object);
            trackLogic = new TrackLogic(mockTrackRepository.Object,mockAlbumRepository.Object);
            
        }
        #region Független tesztek
        [TestCase(2)]
        public void AlbumDeleteExceptionTest(int id)
        {
            Assert.That(() => albumLogic.DeleteAlbum(id), Throws.TypeOf<KeyNotFoundException>());

        }
        [TestCase(78, "ValamiTitle", 32, "ValamiLabel", null, null, "Trash")]
        public void AlbumUpdateExceptionTest(int albumID, string Title, int ArtistID, string Label, TimeSpan length, DateTime releasedate, string Genre)
        {
            Assert.That(() => albumLogic.UpdateAlbum(albumID, Title, ArtistID, Label, length, releasedate, Genre), Throws.TypeOf<KeyNotFoundException>());

        }
        #endregion
        #region CRUD tesztek
        [TestCase(1, "Álomkép", 1, "Universal Music", null, null, "Hungarian Pop")]
        public void AlbumCreateTest(int albumID, string Title, int ArtistID, string Label, TimeSpan length, DateTime releasedate, string Genre)
        {
            Assert.That(() => albumLogic.CreateAlbum(albumID, Title, ArtistID, Label, length, releasedate, Genre), Throws.TypeOf<ArgumentException>());

        }
        [TestCase(1, "Bereczki Zoltán", null, "Hungary", false)]
        public void ArtistCreateTest(int ArtistID, string Name, DateTime Birthday, string nationality, bool grammywinner)
        {
            Assert.That(() => artistLogic.CreateArtist(ArtistID, Name, Birthday, nationality, grammywinner), Throws.TypeOf<ArgumentException>());
        }

        [TestCase(1, "Kerek Egész", 1, 525401, null, 1, false)]
        public void TrackCreateTest(int TrackID, string Title, int AlbumID, int plays, TimeSpan duration, int ArtistID, bool IsExplicit)
        {
            Assert.That(() => trackLogic.CreateTrack(TrackID, Title, AlbumID, plays, duration, ArtistID, IsExplicit), Throws.TypeOf<ArgumentException>());
        }
        #endregion

        [TestCase(1)]
        public void ReadArtistTest(int id)
        {
            Assert.That(artistLogic.ReadArtist(id).Name, Is.EqualTo("Bereczki Zoltán"));
        }
        //NON-CRUD tesztek
        [Test]
        public void AVGPlaysByArtists()
        {
            var result = albumLogic.AVGPlaysByArtists();
            var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("Bereczki Zoltán", 215865)
            };
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void AVGTrackDurationByArtist()
        {
            var result = artistLogic.AVGTrackDurationByArtists();
            var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("Bereczki Zoltán", 1850000000)
            };
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("Hungarian Pop")]
        public void TracksWhereGenreIs(string genre)
        {
            var exp = new List<string>()
            {
                "Kerek Egész","Szállj velem!","1001 Éjjel"
            };
            Assert.That(trackLogic.TracksWhereGenreIs(genre), Is.EqualTo(exp));

        }

        [TestCase("Álomkép")]
        public void LongestTrackByAlbum(string title)
        {
            var exp = new List<string>()
            {
                "1001 Éjjel",
            };
            Assert.That(trackLogic.LongestTrackByAlbum(title), Is.EqualTo(exp));
        }
    }
}
