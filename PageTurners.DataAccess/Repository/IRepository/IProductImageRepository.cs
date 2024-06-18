using System;
using PageTurners.Models;

namespace PageTurners.DataAccess.Repository.IRepository
{
	public interface IProductImageRepository: IRepository<ProductImage>
    {
        void Update(ProductImage obj);
    }
}

