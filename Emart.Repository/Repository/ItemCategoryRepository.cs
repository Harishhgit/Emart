using Emart.Repository.IRepository;
using System.Collections.Generic;
using Emart.Data;
using System.Linq;

namespace Emart.Repository.Repository
{    
    public class ItemCategoryRepository : IItemCategoryRepository 
    {
        private readonly ApplicationContext _applicationContext;

        public ItemCategoryRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IEnumerable<ItemCategory> GetItemCategoriesd()
        {
            return _applicationContext.ItemCategories.AsEnumerable();
        }

        public ItemCategory GetItemCategorybyIdd(int id)
        {
            return _applicationContext.ItemCategories.Where(s => s.ItemCategoryId == id).FirstOrDefault();
        }

        public void RemoveCategory(ItemCategory itemCategory)
        {
            if (itemCategory != null)
            {
                _applicationContext.ItemCategories.Remove(itemCategory);
                _applicationContext.SaveChanges();
            }
        }

    }

}