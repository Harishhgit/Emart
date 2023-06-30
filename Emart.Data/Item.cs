using System.ComponentModel;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Emart.Data
{
    public class Item
    {
        [KeyAttribute]
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        [Display(Name = "Item Category")]
        public int ItemCategoryId { get;set; }

        [ForeignKey("ItemCategoryId")]
        public ItemCategory ItemCategory { get; set; }

        [Display(Name = "Item Subcategory")]
        public int ItemSubCategoryId { get;set; }

        [ForeignKey("ItemSubCategoryId")]
        public ItemSubCategory ItemSubCategory { get; set; }

    }

}
