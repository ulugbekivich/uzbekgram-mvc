using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uzbekgram.Domain.Entities.Contacts;
using Uzbekgram.Domain.Entities.Messages;
using Uzbekgram.Domain.Entities.Users;

namespace Uzbekgram.DataAccess.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; } = default!;
        public virtual DbSet<TextMessage> TextMessages { get; set; } = default!;
        public virtual DbSet<MediaMessage> MediaMessages { get; set; } = default!;
        public virtual DbSet<Contact> Contacts { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasIndex(x => x.Username).IsUnique();
        }

    }
}
