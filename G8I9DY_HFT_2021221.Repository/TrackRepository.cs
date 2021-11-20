using G8I9DY_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G8I9DY_HFT_2021221.Repository
{
    public class TrackRepository : Repository<Tracks>, ITrackRepository
    {
        public TrackRepository(DbContext context) : base(context)
        {

        }
        public void CreateTrack(int TrackID, string Title, int AlbumID, string Genre,int plays,TimeSpan duration, int ArtistID)
        {
            Tracks artist = new Tracks() { TrackID = TrackID, Title = Title, AlbumID = AlbumID, Genre = Genre,Plays=plays,Duration=duration,ArtistID=ArtistID,};
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

        public void UpdateTrack(int TrackID, string Title, int AlbumID, string Genre, int Plays, TimeSpan Duration, int ArtistID)
        {
            DeleteTrack(ArtistID);
            CreateTrack(TrackID, Title, AlbumID, Genre,Plays,Duration, ArtistID);
            context.SaveChanges();
        }
    }
}
