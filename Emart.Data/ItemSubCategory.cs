using System.Data.Common;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Emart.Data
{
    public class ItemSubCategory
    {
        [KeyAttribute]
        public int ItemSubCategoryId { get; set; }
        public string ItemSubCategoryName { get; set; }

        public int ItemCategoryId { get; set; }
        public ItemCategory ItemCategory { get;set; } 
    }

    public class ItemCategory
    {
        [KeyAttribute]
        public int ItemCategoryId { get; set; }
        public string ItemCategoryName { get; set; }

        public ICollection<ItemSubCategory> ItemSubCategories { get; set; }

    }
}