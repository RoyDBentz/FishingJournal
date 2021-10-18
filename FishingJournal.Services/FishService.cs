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
                    AverageSize = fish.AverageSize,
                    AverageWeight = fish.AverageWeight,
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
                                    AverageSize = e.AverageSize,
                                    AverageWeight = e.AverageWeight,
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
                    AverageSize = entity.AverageSize,
                    AverageWeight = entity.AverageWeight
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
                entity.AverageSize = model.AverageSize;
                entity.AverageWeight = model.AverageWeight;

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
