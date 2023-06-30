using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using Emart.Data;


namespace Emart.Service.IServices
{
    public interface IItemCategoryById
    {
        public ItemCategory GetItemCategorybyId(int id);

    }
}