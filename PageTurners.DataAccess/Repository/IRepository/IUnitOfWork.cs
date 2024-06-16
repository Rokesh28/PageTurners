using System;
namespace PageTurners.DataAccess.Repository.IRepository
{
	public interface IUnitOfWork
	{
		ICategoryRepository Category { get; }
		void Save();
	}
}

