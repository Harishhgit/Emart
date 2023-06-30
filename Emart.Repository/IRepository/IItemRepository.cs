using System.Collections.Generic;
using Emart.Data;


namespace Emart.Repository.IRepository
{

    public interface IItemRepository
    {
        public void CreateItem(Item item);
        public IEnumerable<Item> GetAllItems();

        public Item GetItemById(int id);

        public void UpdateItem(Item item);

        public void DeleteItem(Item item);
    }
}
