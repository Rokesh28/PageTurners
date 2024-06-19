using System;
using PageTurners.DataAccess.Data;
using PageTurners.DataAccess.Repository.IRepository;
using PageTurners.Models;

namespace PageTurners.DataAccess.Repository
{
	public class CompanyRepository : Repository<Company>, ICompanyRepository 
	{
        private ApplicationDbContext _db;
        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public void Update(Company obj)
        {
            _db.Companies.Update(obj);
        }
    }
}

