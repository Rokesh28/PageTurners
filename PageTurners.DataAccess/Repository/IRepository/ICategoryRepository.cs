using System;
using PageTurners.Models;

namespace PageTurners.DataAccess.Repository.IRepository
{
	public interface ICategoryRepository : IRepository<Category>
	{
		void update(Category category);
	}
}

