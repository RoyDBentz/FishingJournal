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
                    LureName = bait.LureName,
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
                                    LureId = e.LureId,
                                    LureName = e.LureName,
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
                    LureName = entity.LureName,
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
