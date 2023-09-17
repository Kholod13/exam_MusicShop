using exam_ef.Data;
using exam_ef.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_ef.Repositories
{
    public interface IUoW
    {
        IRepository<Author> AuthorRepo { get; }
        IRepository<Collection> CollectionRepo { get; }
        IRepository<Disk> DiskRepo { get; }
        void Save();
    }

    public class UnitOfWork : IUoW, IDisposable
    {
        private static MusicShopDbContext context = new MusicShopDbContext();
        private IRepository<Disk>? diskRepo = null;
        private IRepository<Author>? authorRepo = null;
        private IRepository<Collection>? collectionRepo = null;

        public IRepository<Author> AuthorRepo
        {
            get
            {
                if (this.authorRepo == null)
                {
                    this.authorRepo = new Repository<Author>(context);
                }
                return authorRepo;
            }
        }
        public IRepository<Collection> CollectionRepo
        {
            get
            {
                if (this.collectionRepo == null)
                {
                    this.collectionRepo = new Repository<Collection>(context);
                }
                return collectionRepo;
            }
        }
        public IRepository<Disk> DiskRepo
        {
            get
            {
                if (this.diskRepo == null)
                {
                    this.diskRepo= new Repository<Disk>(context);
                }
                return diskRepo;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
