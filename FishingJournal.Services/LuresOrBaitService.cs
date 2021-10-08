using FishingJournal.Data;
using FishingJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingJournal.Services
{
    public class LuresOrBaitService
    {
        private readonly Guid _userId;

        public LuresOrBaitService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateLure(LuresOrBaitCreate bait)
        {
            var entity =
                new LuresOrBait()
                {
                    OwnerId = _userId,
                    Artificial = bait.Artificial,
                    LureName = bait.LureName,
                    Color = bait.Color,
                    ArtificialType = bait.ArtificialType,
                    Weight = bait.Weight,
                    Depth = bait.Depth,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.LuresOrBaits.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LuresOrBaitListItem> GetLures()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .LuresOrBaits
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new LuresOrBaitListItem
                                {                                    
                                    Artificial = e.Artificial,
                                    LureName = e.LureName,
                                    Color = e.Color,
                                    ArtificialType = e.ArtificialType,
                                    Weight = e.Weight,
                                    Depth = e.Depth,
                                }
                               );
                return query.ToArray();
            }
        }

        public LuresOrBaitDetail GetLuresById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .LuresOrBaits
                        .Single(e => e.LureId == id && e.OwnerId == _userId);
                return
                new LuresOrBaitDetail
                {
                    LureId = entity.LureId,
                    Artificial = entity.Artificial,
                    LureName = entity.LureName,
                    Color = entity.Color,
                    ArtificialType = entity.ArtificialType,
                    Weight = entity.Weight,
                    Depth = entity.Depth,
                };
            }
        }

        public bool UpdateLure(LuresOrBaitEdit lure)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .LuresOrBaits  
                        .Single(e => e.LureId == lure.LureId && e.OwnerId == _userId);

                entity.LureName = lure.LureName;                

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteLure(int lureId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .LuresOrBaits
                        .Single(e => e.LureId == lureId && e.OwnerId == _userId);

                ctx.LuresOrBaits.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
