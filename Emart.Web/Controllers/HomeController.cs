using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Emart.Web;
using Emart.Data;
using Emart.Repository;
using Emart.Repository.IRepository;
using Emart.Repository.Repository;
using Emart.Service.IServices;


namespace Emart.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _applicationContext;
        private readonly IItemCategoryService _itemCategoryService;
        private readonly IItemCategoryRepository _itemCategoryRepository;
        private readonly IItemSubCategoryRepository _itemSubCategoryRepository;

        public HomeController(ApplicationContext applicationContext,IItemCategoryService itemCategoryService,IItemCategoryRepository itemCategoryRepository,IItemSubCategoryRepository itemSubCategoryRepository)
        {
            _applicationContext = applicationContext;
            _itemCategoryService = itemCategoryService;
            _itemCategoryRepository = itemCategoryRepository;
            _itemSubCategoryRepository = itemSubCategoryRepository;
        }

        public IActionResult Index()
        {            
            var items = _itemCategoryService.GetItemCategory();

            //var itemsById = _itemCategoryById.GetItemCategorybyId(3);

            return View(items);
        }

        [HttpGet]
        public IActionResult CreateCategory() 
        {
           return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(ItemCategory itemCategory) 
        { 
           _applicationContext.Add(itemCategory);
           _applicationContext.SaveChanges();
           ViewBag.cat = "Item Category Created!!";
           ModelState.Clear();
           return View();
        }

        [HttpGet]
        public IActionResult CreateSubCategory() 
        {
           return View();
        }

        [HttpPost]
        public IActionResult CreateSubCategory(ItemSubCategory itemSubCategory) 
        {
            _applicationContext.Add(itemSubCategory);
            _applicationContext.SaveChanges();
            ViewBag.sub = "Item Subcategory Created!!";
            ModelState.Clear();

            return View();
        }

        [HttpGet]
        public IActionResult CreateProducts()
        {
            var itemcategorylist = _itemCategoryService.GetItemCategory();

            ViewBag.Itemcategory = new SelectList(itemcategorylist,"ItemCategoryId","ItemCategoryName");
            //ViewBag.Itemsubcategory = new SelectList();
            return View();
        }

        [HttpPost]
        public IActionResult CreateProducts(Item items)
        {
            _applicationContext.Add(items);
            _applicationContext.SaveChanges();
            ViewBag.itemcreated = "Product Created!!";
            ModelState.Clear();
            return View();
        }

        
        [HttpGet]
        public ActionResult DeleteCategory(int id)
        {
            var data = _itemCategoryRepository.GetItemCategorybyIdd(id);
            
            return View(data);
        }

        [HttpPost]
        public ActionResult DeleteCategory(ItemCategory itemCategory)
        {

            _itemCategoryRepository.RemoveCategory(itemCategory);

            ViewBag.DeleteCategory = "Item Category deleted";
            ModelState.Clear();
            
            return View();
        } 

        [HttpGet]
        public IActionResult Subcategories()
        {
            var sub = _itemSubCategoryRepository.GetItemSubCategoriesd();

            return View(sub);
        }


        [HttpGet]
        public ActionResult DeleteSubCategory(int id)
        {
            var itemsub = _itemSubCategoryRepository.GetItemSubCategoryById(id);
            
            return View(itemsub);
        }

        [HttpPost]
        public ActionResult DeleteSubCategory(ItemSubCategory itemSubCategory)
        {
            _itemSubCategoryRepository.RemoveSubCategory(itemSubCategory);
            
            ViewBag.Removesub = "Subcategory removed !!"; 
            ModelState.Clear();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
