using System;
using PageTurners.Models;

namespace PageTurners.DataAccess.Repository.IRepository
{
	public interface ICompanyRepository : IRepository<Company>
    {
        void Update(Company obj);
    }
}

