using exam_ef.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_ef.Data
{
    public class MusicShopDbContext : DbContext
    {
        public MusicShopDbContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string conn = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EFLibraryDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;";
            optionsBuilder.UseSqlServer(conn);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>().HasData(new Author[]
            {
                new Author() { Id = 0, Name = "Michael Jakson", Country = "USA"},
                new Author() { Id = 1, Name = "50Cent", Country = "USA"},
                new Author() { Id = 2, Name = "Zelinsky", Country = "Ukraine"},
            });

            modelBuilder.Entity<Collection>().HasData(new Collection[]
            {
                new Collection() { Id = 0, Name = "Off the Wall"},
                new Collection() { Id = 1, Name = "Thriller"},
                new Collection() { Id = 2, Name = "Curtis"},
                new Collection() { Id = 3, Name = "Ти його чув?"},
            });

            modelBuilder.Entity<Disk>().HasData(new Disk[]
            {
                new Disk() { Name = "Working day and night", CollectionId = 0, 
                AuthorId = 0, Genre = "Jazz", Year = 1979, Price = 43, PriceForSale = 59},
                new Disk() {Name = "Off the Wall", CollectionId = 0,
                AuthorId = 0, Genre = "Jazz Blues", Year = 1979, Price = 60, PriceForSale = 89},
                new Disk() {Name = "Girlfriend", CollectionId = 0,
                AuthorId = 0, Genre = "Jazz Blues", Year = 1979, Price = 30, PriceForSale = 42},
                new Disk() {Name = "Burn This Disco Out", CollectionId = 0,
                AuthorId = 0, Genre = "Jazz", Year = 1979, Price = 44, PriceForSale = 55},
                new Disk() {Name = "I Can't help it", CollectionId = 0,
                AuthorId = 0, Genre = "Jazz", Year = 1979, Price = 21, PriceForSale = 39},
                new Disk() {Name = "The Girl Is Mine", CollectionId = 1,
                AuthorId = 0, Genre = "Disco", Year = 1982, Price = 39, PriceForSale = 59},
                new Disk() {Name = "Billie Jean", CollectionId = 1,
                AuthorId = 0, Genre = "Jazz", Year = 1982, Price = 79, PriceForSale = 115},
                //------
                new Disk() {Name = "Ayo Technology", CollectionId = 2,
                AuthorId = 1, Genre = "HipHop", Year = 2007, Price = 17, PriceForSale = 25},
                new Disk() {Name = "Follow My Lead", CollectionId = 2,
                AuthorId = 1, Genre = "HipHop", Year = 2007, Price = 24, PriceForSale = 37},
                new Disk() {Name = "Touch The Sky", CollectionId = 2,
                AuthorId = 1, Genre = "HipHop", Year = 2007, Price = 44, PriceForSale = 69},
                new Disk() {Name = "I'll Still Kill", CollectionId = 2,
                AuthorId = 1, Genre = "HipHop", Year = 2007, Price = 16, PriceForSale = 32},
                new Disk() {Name = "Peep Show", CollectionId = 2,
                AuthorId = 1, Genre = "HipHop", Year = 2007, Price = 33, PriceForSale = 50},
                new Disk() {Name = "Fire", CollectionId = 2,
                AuthorId = 1, Genre = "HipHop", Year = 2007, Price = 15, PriceForSale = 40},
                new Disk() {Name = "All of Me", CollectionId = 2,
                AuthorId = 1, Genre = "HipHop", Year = 2007, Price = 16, PriceForSale = 29},
                new Disk() {Name = "My Gun Go Off", CollectionId = 2,
                AuthorId = 1, Genre = "HipHop", Year = 2007, Price = 24, PriceForSale = 40},
                //----
                new Disk() {Name = "Будь ласкава", CollectionId = 3,
                AuthorId = 2, Genre = "Rap", Year = 2022, Price = 44, PriceForSale = 60},
                new Disk() {Name = "Літо", CollectionId = 3,
                AuthorId = 2, Genre = "Rap", Year = 2022, Price = 50, PriceForSale = 89},
                new Disk() {Name = "Смерть", CollectionId = 3,
                AuthorId = 2, Genre = "Rap", Year = 2022, Price = 33, PriceForSale = 66},
                new Disk() {Name = "Схожі", CollectionId = 3,
                AuthorId = 2, Genre = "Rap", Year = 2022, Price = 45, PriceForSale = 69},
            });

        }
        public DbSet<Author> Authors{ get; set; }
        public DbSet<Collection> Collections{ get; set; }
        public DbSet<Disk> Disks { get; set; }
    }
}
