﻿using System;
using System.Linq.Expressions;
using PageTurners.DataAccess.Data;
using PageTurners.DataAccess.Repository.IRepository;
using PageTurners.Models;

namespace PageTurners.DataAccess.Repository
{
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
        private readonly ApplicationDbContext _db;

		public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
		}

        public void Update(Category category)
        {
            _db.Categories.Update(category);
        }
    }
}

