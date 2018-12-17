using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EducationDepartment.Infrastructure.Entityframework.Data.Entities;
using EducationDepartment.Infrastructure.Entityframework.Data.EntityFramework.Entities;


namespace EducationDepartment.Infrastructure.Entityframework.Data.EntityFramework
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleType> ArticleTypes { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<FieldType> FieldTypes { get; set; }
        public DbSet<ArticleTypeFieldType> ArticleTypeFieldTypes { get; set; }
        public DbSet<Notification> Notifications { get; set; }


        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ArticleTypeFieldType>().HasKey(bc => new { bc.ArticleTypeId, bc.FieldTypeId });
            modelBuilder.Entity<ArticleTypeFieldType>().HasOne(bc => bc.ArticleType).WithMany(b => b.ArticleTypeFieldTypes).HasForeignKey(bc => bc.ArticleTypeId);
            modelBuilder.Entity<ArticleTypeFieldType>().HasOne(bc => bc.FieldType).WithMany(c => c.FieldTypeArticleType).HasForeignKey(bc => bc.FieldTypeId);
            //builder.Entity<FieldType>().HasData(new FieldType { IsDeleted = false, Created = DateTime.Now, Modified = DateTime.Now, Name = "plainText", Options = "{}", Id = 1 });
        }

        public override int SaveChanges()
        {
            AddAuitInfo();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            AddAuitInfo();
            return await base.SaveChangesAsync();
        }

        private void AddAuitInfo()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).Created = DateTime.UtcNow;
                }
                ((BaseEntity)entry.Entity).Modified = DateTime.UtcNow;
            }
        }
    }
}
