using Microsoft.VisualBasic.CompilerServices;
using System.Reflection.Metadata;
using System.Security.Authentication;
using Emart.Repository.IRepository;
using System.Collections.Generic;
using Emart.Data;
using Emart.Repository;
using System.Linq;


namespace Emart.Repository.Repository
{
    public class ItemSubCategoryRepository : IItemSubCategoryRepository
    {
        private readonly ApplicationContext _applicationContext;

        public ItemSubCategoryRepository(ApplicationContext applicationContext)
        {   
            _applicationContext = applicationContext;
        }        
        public IEnumerable<ItemSubCategory> GetItemSubCategoriesd()
        {
            return _applicationContext.ItemSubCategories.AsEnumerable();
        }

        public IEnumerable<ItemSubCategory> GetItemSubCategoryByCategoryId(int id)
        {
            return _applicationContext.ItemSubCategories.Where(s => s.ItemCategoryId == id).AsEnumerable();
        }

         public IEnumerable<Item> GetFinalItems(int categoryId,int subcategoryId)
        {
            return _applicationContext.Items.Where(ci => ci.ItemCategoryId == categoryId && ci.ItemSubCategoryId == subcategoryId).AsEnumerable();
        }


        public ItemSubCategory GetItemSubCategoryById(int id)
        {
            return _applicationContext.ItemSubCategories.Where(rs => rs.ItemSubCategoryId == id).FirstOrDefault();
        }
        public void RemoveSubCategory(ItemSubCategory itemSubCategory)
        {
            if(itemSubCategory != null)
            {
                _applicationContext.ItemSubCategories.Remove(itemSubCategory);
                _applicationContext.SaveChanges();
            }
        }
    }
}


