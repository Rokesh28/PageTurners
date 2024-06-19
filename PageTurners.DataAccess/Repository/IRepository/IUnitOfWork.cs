using System;
namespace PageTurners.DataAccess.Repository.IRepository
{
	public interface IUnitOfWork
	{
		ICategoryRepository Category { get; }
        IProductRepository Product { get; }
		IProductImageRepository ProductImage { get; }
        ICompanyRepository Company { get; }
        void Save();
	}
}

