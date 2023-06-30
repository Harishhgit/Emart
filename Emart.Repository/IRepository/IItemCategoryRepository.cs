using System.Collections.Generic;
using Emart.Repository;
using Emart.Data;

namespace Emart.Repository.IRepository
{ 
    public interface IItemCategoryRepository
    {
       public IEnumerable<ItemCategory> GetItemCategoriesd();

       public ItemCategory GetItemCategorybyIdd(int id);

       public void RemoveCategory(ItemCategory itemCategory);
 
    }
}