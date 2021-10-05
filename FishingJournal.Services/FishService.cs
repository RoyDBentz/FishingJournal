using FishingJournal.Data;
using FishingJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingJournal.Services
{
    public class FishService
    {
        private readonly Guid _userId;

        public FishService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateFish(FishCreate fish)
        {
            var entity =
                new Fish()
                {
                    OwnerId = _userId,
                    Species = fish.Species,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Fishes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FishListItem> GetFishes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Fishes
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new FishListItem
                                {
                                    FishId = e.FishId,
                                    Species = e.Species,
                                }
                               );
                return query.ToArray();
            }
        }

        public FishDetail GetFishById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Fishes
                        .Single(e => e.FishId == id && e.OwnerId == _userId);
                return
                new FishDetail
                {
                    FishId = entity.FishId,
                    Species = entity.Species,
                };
            }
        }

        public bool UpdateFish(FishEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Fishes
                        .Single(e => e.FishId == model.FishId && e.OwnerId == _userId);

                entity.Species = model.Species;
                //entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteFish(int fishId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Fishes
                        .Single(e => e.FishId == fishId && e.OwnerId == _userId);

                ctx.Fishes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
