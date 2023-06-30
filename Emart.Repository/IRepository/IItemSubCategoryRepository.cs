using Emart.Data;
using Emart.Repository;
using System.Collections.Generic;

namespace Emart.Repository.IRepository
{
    public interface IItemSubCategoryRepository
    {
        public IEnumerable<ItemSubCategory> GetItemSubCategoriesd();

        public IEnumerable<ItemSubCategory> GetItemSubCategoryByCategoryId(int id);

        public ItemSubCategory GetItemSubCategoryById(int id);

        public IEnumerable<Item> GetFinalItems(int categoryId,int subcategoryId);

        public void RemoveSubCategory(ItemSubCategory itemSubCategory);

    }
}

