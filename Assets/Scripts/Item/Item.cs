using PotionCraft.Enum;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PotionCraft.ItemScripts
{
    public class Item
    {
        #region Fields
        private int _id;
        private string _title;
        private string _description;
        private Sprite _sprite;
        private ItemType _itemType;
        private int _effectProbability;
        
        private float _love;
		private float _chaos;
		private float _stability;
		private float _amplifier;
        #endregion

        #region Properties
        public int Id { get => _id; private set => _id = value; }
        public string Title { get => _title; private set => _title = value; }
        public string Description { get => _description; private set => _description = value; }
        public Sprite Sprite { get => _sprite; private set => _sprite = value; }
        public float Love { get => _love; private set => _love = value; }
		public float Chaos { get => _chaos; private set => _chaos= value; }
		public float Stability { get => _stability; private set => _stability = value; }
		public float Amplifier { get => _amplifier; private set => _amplifier = value; }
        public ItemType ItemType { get => _itemType; private set => _itemType = value; }
        public int EffectProbability { get => _effectProbability; private set => _effectProbability = value; }
        #endregion

        public Item(int id, string title, string description, ItemType itemType)
        {
            Id = id;
            Title = title;
            Description = description;
            ItemType = itemType;
            Sprite = Resources.Load<Sprite>("Art/Sprites/" + ItemType + "/" + title);
        }

        public Item(int id, string title, string description, ItemType itemType, float love, float chaos, float stability, float amplifier)
        {
            Id = id;
            Title = title;
            Description = description;
            Love = love;
            Chaos = chaos;
            Stability = stability;
            Amplifier = amplifier;
            ItemType = itemType;
            Sprite = Resources.Load<Sprite>("Art/Sprites/" + ItemType + "/" + title);
        }

        public Item(string title, string description, ItemType itemType, float love, float chaos, float stability, float amplifier)
        {
            Title = title;
            Description = description;        
            Love = love;
            Chaos = chaos;
            Stability = stability;
            Amplifier = amplifier;
            ItemType = itemType;
            Sprite = Resources.Load<Sprite>("Art/Sprites/" + ItemType + "/" + title);
        }


        public Item(ItemType itemType, float love, float chaos, float stability, float amplifier)
        {
            ItemType = itemType;
            Love = love;
            Chaos = chaos;
            Stability = stability;
            Amplifier = amplifier;
            int rand = Random.Range(1, 7);
            Sprite = Resources.Load<Sprite>("Art/Sprites/" + ItemType + "/Potion "+rand);
        }

        public Item(int id, string title, ItemType itemType, float love, float chaos, float stability, float amplifier, int effectProbability)
        {
            Id = id;
            Title = title;
            ItemType = itemType;
            Sprite = Resources.Load<Sprite>("Art/Sprites/" + ItemType + "/" + title);
            Love = love;
            Chaos = chaos;
            Stability = stability;
            Amplifier = amplifier;
            EffectProbability = effectProbability;

        }
    }
}