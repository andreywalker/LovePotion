using PotionCraft.Enum;
using System.Collections.Generic;
using UnityEngine;

namespace PotionCraft.ItemScripts
{
    public class ItemDatabase : MonoBehaviour
    {
        #region Fields

        private List<Item> _databaseItemsList;

        #endregion

        #region Methods

        private void Awake()
        {
            BuildItemDatabase();
        }

        public Item GetItemFromDatabase(int id)
        {
            return _databaseItemsList.Find(item => item.Id == id);
        }

        public Item GetItemFromDatabase(string itemTitle)
        {
            return _databaseItemsList.Find(item => item.Title == itemTitle);
        }

        private void AddItemToDatabase(Item item)
        {
            _databaseItemsList.Add(item);
        }

        private void RemoveItemFromDatabase(Item item)
        {
            _databaseItemsList.Remove(item);
        }

        private void BuildItemDatabase()
        {
            _databaseItemsList = new List<Item>()
        {

            new Item(1,
            "Blood",
            ItemType.Ingredient,
            0.8f,
            0.6f,
            0.3f,
            0.7f,
            80),

            new Item(2,
            "Fire",
            ItemType.Ingredient,
            0.2f,
            0.9f,
            0.2f,
            0.9f,
            95),

            new Item(3,
            "Oil",
            ItemType.Ingredient,
            0.2f,
            0.2f,
            0.5f,
            0.5f,
            75),

            new Item(4,
            "Milk",
            ItemType.Ingredient,
            0.9f,
            0.1f,
            0.9f,
            0.1f,
            75),

            new Item(5,
            "Electricity",
            ItemType.Ingredient,
            0.1f,
            0.6f,
            0.4f,
            0.7f,
            90),

            new Item(6,
            "Sulfur",
            ItemType.Ingredient,
            0.2f,
            0.2f,
            0.9f,
            0.3f,
            70),

            new Item(7,
            "Tree",
            ItemType.Ingredient,
            0.7f,
            0.1f,
            0.9f,
            0.4f,
            75),

            new Item(8,
            "Virus",
            ItemType.Ingredient,
            0.6f,
            0.9f,
            0.5f,
            0.5f,
            90),

            new Item(9,
            "Water",
            ItemType.Ingredient,
            0.5f,
            0.5f,
            0.5f,
            0.5f,
            95),

            new Item(10,
            "Ash",
            ItemType.Ingredient,
            0.4f,
            0.3f,
            0.4f,
            0.2f,
            50),
        };
        }

        #endregion
    }
}