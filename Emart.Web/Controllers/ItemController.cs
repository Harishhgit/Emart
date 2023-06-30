using System.Net;
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

namespace Emart.Web.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRepository;
        private readonly IItemCategoryRepository _itemCategoryRepository;
        private readonly IItemSubCategoryRepository _itemSubCategoryRepository;

        public ItemController(IItemRepository itemRepository,IItemCategoryRepository itemCategoryRepository,IItemSubCategoryRepository itemSubCategoryRepository)
        {
            _itemRepository = itemRepository;
            _itemCategoryRepository = itemCategoryRepository;
            _itemSubCategoryRepository = itemSubCategoryRepository;
        }
        
        [HttpGet]
        public IActionResult ItemIndex()
        {
          
            var itemcategorylist = _itemCategoryRepository.GetItemCategoriesd();
            ViewBag.Itemcategories = new SelectList(itemcategorylist,"ItemCategoryId","ItemCategoryName");  
            
            var allitems = _itemRepository.GetAllItems();

            return View(allitems);
        }

     /*    [HttpPost]
        public IActionResult ItemIndex()
        {            
            var allitems = _itemRepository.GetAllItems();

            return View(allitems);
        } */




        /* [HttpGet]
        public IActionResult ItemById()
        {
          return View();
        }

        [HttpPost]
        public IActionResult ItemById(int id)
        {
          _itemRepository.GetItemById(id);
          return View();
        } */

        [HttpGet]
        public IActionResult CreateNewItem()
        {
            var itemcategorylist = _itemCategoryRepository.GetItemCategoriesd();
            ViewBag.Itemcategoryd = new SelectList(itemcategorylist,"ItemCategoryId","ItemCategoryName");

            return View();
        }

        [HttpPost]
        public IActionResult CreateNewItem(Item item)
        {
            _itemRepository.CreateItem(item);
             
            return View();
        }

        [HttpGet]
        public IActionResult UpdateItemData(int id)
        {
           var itemcategorylist = _itemCategoryRepository.GetItemCategoriesd();
           ViewBag.Itemcategoryupdate = new SelectList(itemcategorylist,"ItemCategoryId","ItemCategoryName");
           
           var itemdata = _itemRepository.GetItemById(id);

           return View(itemdata);
        }

        [HttpPost]
        public IActionResult UpdateItemData(int id,Item item)
        {
            var itemdata = _itemRepository.GetItemById(id);
            itemdata.ItemId = item.ItemId;
            itemdata.ItemName = item.ItemName;
            itemdata.Price = item.Price;
            itemdata.Description = item.Description;
            itemdata.ImageUrl = item.ImageUrl;
            itemdata.ItemCategory = item.ItemCategory;
            itemdata.ItemSubCategory = item.ItemSubCategory;

           _itemRepository.UpdateItem(item);
           return View();
        }

        [HttpGet]
        public IActionResult DeleteItemData(int id)
        {
            var itemdata = _itemRepository.GetItemById(id);

            return View(itemdata);
        }

        [HttpPost]
        public IActionResult DeleteItemData(int id,Item item)
        {
            var itemdata = _itemRepository.GetItemById(id);

            itemdata.ItemId = item.ItemId;
            itemdata.ItemName = item.ItemName;
            itemdata.Price = item.Price;
            itemdata.Description = item.Description;
            itemdata.ImageUrl = item.ImageUrl;

            _itemRepository.DeleteItem(item);

            return View();
        }

      /*   [HttpGet]
        public IActionResult SubItems(int id)
        {
            return _itemSubCategoryRepository.GetItemsBySubCategoryId(id);
        }
 */
        public JsonResult GetItemSubCategories(int id)
        {
            var Isc = _itemSubCategoryRepository.GetItemSubCategoryByCategoryId(id);
            
            return Json(new SelectList(Isc, "ItemSubCategoryId","ItemSubCategoryName"));
        }

         public JsonResult FinalItems(int catId,int SubId)
        {
            var items = _itemSubCategoryRepository.GetFinalItems(catId,SubId);

            return Json(items);
        } 





    }
}