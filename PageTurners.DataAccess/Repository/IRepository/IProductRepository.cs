using System;
using PageTurners.Models;

namespace PageTurners.DataAccess.Repository.IRepository
{
	public interface IProductRepository: IRepository<Product>
	{
        void Update(Product obj);
    }
}

