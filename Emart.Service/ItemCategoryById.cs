using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Collections;
using Emart.Repository;
using Emart.Data;
using Emart.Service.IServices;
using System.Linq;

namespace Emart.Service
{
    public class ItemCategoryById : IItemCategoryById
    {
        private readonly ApplicationContext _applicationContext;
        public ItemCategoryById(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public ItemCategory GetItemCategorybyId(int id)
        {
            return _applicationContext.ItemCategories.Where(s => s.ItemCategoryId == id).FirstOrDefault();
        }
    }

}
