﻿using FishingJournal.Data;
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
                    Content = entry.Content,                    
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
                                    Content = e.Content,                                    
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
                        Content = entity.Content,
                    };
            }
        }
    }
}
