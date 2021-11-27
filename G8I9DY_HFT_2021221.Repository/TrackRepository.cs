﻿using G8I9DY_HFT_2021221.Data;
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
        public TrackRepository(TracksDbContext context) : base(context)
        {

        }
        public void CreateTrack(int TrackID, string Title, int AlbumID,int plays,TimeSpan duration, int ArtistID, bool IsExplicit)
        {
            Tracks tracks = new Tracks() { TrackID = TrackID, Title = Title, AlbumID = AlbumID,Plays=plays,Duration=duration,ArtistID=ArtistID, IsExplicit= IsExplicit};
            Create(tracks);
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

        public IQueryable<Tracks> ReadAllTracks()
        {
            return (IQueryable<Tracks>)GetAll();
        }

        public Tracks ReadTrack(int TrackID)
        {
            return GetOne(TrackID);
        }

        public void UpdateTrack(int TrackID, string Title, int AlbumID, int plays, TimeSpan duration, int ArtistID, bool IsExplicit)
        {
            var toUpdate = GetOne(TrackID);
            toUpdate.Title=Title;
            toUpdate.AlbumID=AlbumID;
            toUpdate.Plays=plays;
            toUpdate.Duration=duration;
            toUpdate.ArtistID=ArtistID;
            toUpdate.IsExplicit=IsExplicit;
            context.SaveChanges();
        }
    }
}
