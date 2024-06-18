using System;
using PageTurners.DataAccess.Data;
using PageTurners.DataAccess.Repository.IRepository;

namespace PageTurners.DataAccess.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
        private ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public IProductImageRepository ProductImage { get; private set; }
        public UnitOfWork(ApplicationDbContext dbContext)
		{
            _db = dbContext;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
            ProductImage = new ProductImageRepository(_db);

        }
          
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

