using System;
using PageTurners.DataAccess.Data;
using PageTurners.DataAccess.Repository.IRepository;
using PageTurners.Models;

namespace PageTurners.DataAccess.Repository
{
	public class ShoppingCartRepository : Repository<ShoppingCart> , IShoppingCartRepository
	{
        private ApplicationDbContext _db;
        public ShoppingCartRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public void Update(ShoppingCart obj)
        {
            _db.ShoppingCarts.Update(obj);
        }
    }
}

