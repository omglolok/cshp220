using System;

namespace InventoryApp.Models
{
    public class ItemModel
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal? ItemQuantity { get; set; }
        public decimal? ItemValue { get; set; }
        public DateTime ItemCreationDate { get; set; }

        public InventoryRepository.ItemModel ToRepositoryModel()
        {
            var repositoryModel = new InventoryRepository.ItemModel
            {
                ItemId = ItemId,
                ItemName = ItemName,
                ItemDescription = ItemDescription,
                ItemPrice = ItemPrice,
                ItemQuantity = ItemQuantity,
                ItemValue = ItemValue,
                ItemCreationDate = ItemCreationDate,
            };

            return repositoryModel;
        }

        public static ItemModel ToModel(InventoryRepository.ItemModel respositoryModel)
        {
            var itemModel = new ItemModel
            {
                ItemId = respositoryModel.ItemId,
                ItemName = respositoryModel.ItemName,
                ItemDescription = respositoryModel.ItemDescription,
                ItemPrice = respositoryModel.ItemPrice,
                ItemQuantity = respositoryModel.ItemQuantity,
                ItemValue = respositoryModel.ItemValue,
                ItemCreationDate = respositoryModel.ItemCreationDate,
            };

            return itemModel;
        }

        internal ItemModel Clone()
        {
            return (ItemModel)MemberwiseClone();
        }
    }
}