using InventoryDB;
using System.Collections.Generic;
using System.Linq;

namespace InventoryRepository
{
    public class ItemModel
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal? ItemQuantity { get; set; }
        public decimal? ItemValue { get; set; }
        public System.DateTime ItemCreationDate { get; set; }
    }

    public class InventoryRepository
    {
        public ItemModel Add(ItemModel itemModel)
        {
            var itemDb = ToDbModel(itemModel);

            DatabaseManager.Instance.Items.Add(itemDb);
            DatabaseManager.Instance.SaveChanges();

            itemModel = new ItemModel
            {
                ItemId = itemDb.ItemId,
                ItemName = itemDb.ItemName,
                ItemDescription = itemDb.ItemDescription,
                ItemPrice = itemDb.ItemPrice,
                ItemQuantity = itemDb.ItemQuantity,
                ItemCreationDate = itemDb.ItemCreationDate,
            };
            return itemModel;
        }

        public List<ItemModel> GetAll()
        {
            // Use .Select() to map the database items to InventoryModel
            var items = DatabaseManager.Instance.Items
              .Select(t => new ItemModel
              {
                  ItemId = t.ItemId,
                  ItemName = t.ItemName,
                  ItemDescription = t.ItemDescription,
                  ItemPrice = t.ItemPrice,
                  ItemQuantity = t.ItemQuantity,
                  ItemValue = t.ItemPrice * t.ItemQuantity,
                  ItemCreationDate = t.ItemCreationDate,
              }).ToList();

            return items;
        }

        public bool Update(ItemModel itemModel)
        {
            var original = DatabaseManager.Instance.Items.Find(itemModel.ItemId);

            if (original != null)
            {
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(itemModel));
                DatabaseManager.Instance.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Remove(int itemId)
        {
            var items = DatabaseManager.Instance.Items
                                .Where(t => t.ItemId == itemId);

            if (items.Count() == 0)
            {
                return false;
            }

            DatabaseManager.Instance.Items.Remove(items.First());
            DatabaseManager.Instance.SaveChanges();

            return true;
        }

        private Item ToDbModel(ItemModel itemModel)
        {
            var itemDb = new Item
            {
                ItemId = itemModel.ItemId,
                ItemName = itemModel.ItemName,
                ItemDescription = itemModel.ItemDescription,
                ItemPrice = itemModel.ItemPrice,
                ItemQuantity = itemModel.ItemQuantity,
                ItemCreationDate = itemModel.ItemCreationDate,
            };

            return itemDb;
        }
    }
}