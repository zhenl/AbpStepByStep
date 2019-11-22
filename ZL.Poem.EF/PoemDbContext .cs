using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZL.Poem.Core.Poems;

namespace ZL.Poem.EF.EntityFramework
{
    public class PoemDbContext : AbpDbContext
    {
        public virtual DbSet<Poet> Poets { get; set; }

        public virtual DbSet<Core.Poems.Poem> Poems { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<CategoryPoem> CategoryPoems { get; set; }

        public PoemDbContext(DbContextOptions<PoemDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //映射Poet到数据库表
            modelBuilder.Entity<Poet>().ToTable("Poet");

            //映射实体与数据库中的字段，将Id映射到数据库表的PoetID字段
            modelBuilder.Entity<Poet>()
                    .Property(p => p.Id)
                    .HasColumnName("PoetID");

            //Poem映射
            modelBuilder.Entity<Core.Poems.Poem>().ToTable("Poem");
            modelBuilder.Entity<Core.Poems.Poem>()
                    .Property(p => p.Id)
                    .HasColumnName("PoemId");

            //定义Poem与Poet之间的一对多关系
            modelBuilder.Entity<Core.Poems.Poem>().HasOne<Poet>(s => s.Author)
                    .WithMany(s => s.Poems)
                    .HasForeignKey(s => s.PoetID);

            //Category映射
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Category>().
               Property(p => p.Id)
               .HasColumnName("CategoryId");

            ///CategoryPoem映射
            modelBuilder.Entity<CategoryPoem>().ToTable("CategoryPoem");
            modelBuilder.Entity<CategoryPoem>().
               Property(p => p.Id)
               .HasColumnName("CategoryPoemId");

            //定义多对多关系
            modelBuilder.Entity<CategoryPoem>()
                        .HasKey(t => new { t.CategoryId, t.PoemId });

            modelBuilder.Entity<CategoryPoem>()
                .HasOne(pt => pt.Poem)
                .WithMany(p => p.PoemCategories)
                .HasForeignKey(pt => pt.PoemId);

            modelBuilder.Entity<CategoryPoem>()
                .HasOne(pt => pt.Category)
                .WithMany(t => t.CategoryPoems)
                .HasForeignKey(pt => pt.CategoryId);
        }
    }
}