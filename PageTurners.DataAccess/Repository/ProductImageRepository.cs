using System;
using PageTurners.DataAccess.Data;
using PageTurners.DataAccess.Repository.IRepository;
using PageTurners.Models;

namespace PageTurners.DataAccess.Repository
{
	public class ProductImageRepository: Repository<ProductImage>, IProductImageRepository 
	{
        private ApplicationDbContext _db;
        public ProductImageRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(ProductImage obj)
        {
            _db.ProductImages.Update(obj);
        }
    }
}

