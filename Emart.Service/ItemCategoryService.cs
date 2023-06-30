using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Collections;
using Emart.Repository;
using System.Linq;
/* using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; */
using Emart.Data;
using Emart.Service.IServices;

namespace Emart.Service
{
    public class ItemCategoryService : IItemCategoryService
    {
        private readonly ApplicationContext _applicationContext; 

        public ItemCategoryService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IEnumerable<ItemCategory> GetItemCategory()
        {
             return _applicationContext.ItemCategories.AsEnumerable();
           //return _applicationContext.ItemCategories.ToList();
        }

    }

}
