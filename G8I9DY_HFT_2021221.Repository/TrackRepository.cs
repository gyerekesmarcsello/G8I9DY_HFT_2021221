using G8I9DY_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G8I9DY_HFT_2021221.Repository
{
    class TrackRepository : Repository<Tracks>, ITrackRepository
    {
        public TrackRepository(DbContext context) : base(context)
        {

        }
        public void CreateTrack(int TrackID, string Title, int AlbumID, string Genre, int ArtistID, string ReleaseDate)
        {
            Tracks artist = new Tracks() { TrackID = TrackID, Title = Title, AlbumID = AlbumID, Genre = Genre,ArtistID=ArtistID,ReleaseDate=ReleaseDate};
            context.SaveChanges();
        }

        public void DeleteTrack(int TrackID)
        {
            Delete(GetOne(TrackID));
            context.SaveChanges();
        }

        public override Tracks GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.TrackID == id);
        }

        public HashSet<Tracks> ReadAllTracks()
        {
            return (HashSet<Tracks>)GetAll();
        }

        public Tracks ReadTrack(int TrackID)
        {
            return GetOne(TrackID);
        }

        public void UpdateTrack(int TrackID, string Title, int AlbumID, string Genre, int ArtistID, string ReleaseDate)
        {
            DeleteTrack(ArtistID);
            CreateTrack(TrackID, Title, AlbumID, Genre, ArtistID, ReleaseDate);
            context.SaveChanges();
        }
    }
}
