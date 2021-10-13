using FishingJournal.Data;
using FishingJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingJournal.Services
{
    public class EntryService
    {
        private readonly Guid _userId;        

        public EntryService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEntry(EntryCreate entry)
        {
            var entity =
                new Entry()
                {
                    OwnerId = _userId, 
                    EntryId = entry.EntryId,
                    FishId = entry.FishId,
                    LureId = entry.LureId,
                    JournalDate = entry.JournalDate,
                    Notes = entry.Notes,
                    TotalFishCaught = entry.TotalFishCaught,
                    Location = entry.Location, 
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Entries.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EntryListItem> GetEntries()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Entries
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new EntryListItem
                                {
                                    EntryId = e.EntryId,
                                    JournalDate = e.JournalDate,
                                    Notes = e.Notes,
                                    TotalFishCaught = e.TotalFishCaught,
                                    Location= e.Location                                   
                                }
                               );
                return query.ToArray();
            }
        }

        public EntryDetail GetEntryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Entries
                        .Single(e => e.EntryId == id && e.OwnerId == _userId);
                    return
                    new EntryDetail
                    {
                        EntryId = entity.EntryId,
                        JournalDate = entity.JournalDate,
                        Notes = entity.Notes,
                        TotalFishCaught = entity.TotalFishCaught,
                        Location = entity.Location,
                    };
            }
        }

        public bool UpdateEntry (EntryEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Entries
                        .Single(e => e.EntryId == model.EntryId && e.OwnerId == _userId);

                entity.Notes = model.Notes;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteEntry(int entryID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Entries
                        .Single(e => e.EntryId == entryID && e.OwnerId == _userId);

                ctx.Entries.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
