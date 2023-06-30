using System.Net;
using Emart.Data;
using System.Collections.Generic;
using Emart.Repository;
using System.Linq;
using Emart.Repository.IRepository;

namespace Emart.Repository.Repository
{   
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationContext _applicationContext; 

        public ItemRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IEnumerable<Item> GetAllItems()
        {          
          return _applicationContext.Items.ToList();
        }

        public Item GetItemById(int id)
        { 
           return _applicationContext.Items.Where(s => s.ItemId == id).FirstOrDefault();            
        }

        public void UpdateItem(Item item)
        {
            if(item != null)
            {
                _applicationContext.Items.Update(item);
                _applicationContext.SaveChanges();
            }
        }

        public void DeleteItem(Item item)
        {
            if(item != null)
            {
                _applicationContext.Items.Remove(item);
                _applicationContext.SaveChanges();
            }
        }

        public void CreateItem(Item item)
        {
            if(item != null)
            {
                _applicationContext.Items.Add(item);
                _applicationContext.SaveChanges();
            }
        }

        /*  public Item GetItemByIId(int id)
        { 
           return _applicationContext.Items.Where(s => s.ItemId == id).Include(a => a.ItemCategory).ThenInclude(a.ItemSubCategory).FirstOrDefault();            
        } */

        /* public ItemCategory GetItemCategorybyItemId(int id)
        {
            var itemid = _applicationContext.Items.Where(m => m.ItemId == id);
            var itemcatid = itemid.ItemCategoryId;
            return _applicationContext.ItemCategories.Where(s => s.ItemCategoryId == itemcatid).FirstOrDefault();
        } */



    }

}