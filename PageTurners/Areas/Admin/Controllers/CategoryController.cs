using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PageTurners.DataAccess.Data;
using PageTurners.DataAccess.Repository.IRepository;
using PageTurners.Models;
using PageTurners.Utility;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PageTurners.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {
        
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Category> categories = _unitOfWork.Category.GetAll().ToList();
            return View(categories);
        }

        public IActionResult CreateOrEdit(int? id=0)
        {
            if (id == 0)
            { return View(new Category()); }
            else
            {
                Category category = _unitOfWork.Category.Get(u => u.Id == id);
                return View(category);
            }
            
        }
        [HttpPost]
        public IActionResult CreateOrEdit(Category obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            //}

            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                { _unitOfWork.Category.Add(obj);
                  _unitOfWork.Save();
                  TempData["success"] = "Category created successfully";
                }
                else
                { _unitOfWork.Category.Update(obj);
                  _unitOfWork.Save();
                  TempData["success"] = "Category Edited successfully";
                }
               
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Remove(int? id)
        {
            Category? obj = _unitOfWork.Category.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}

