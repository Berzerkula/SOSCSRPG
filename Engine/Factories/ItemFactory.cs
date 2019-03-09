﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Engine.Actions;
using Engine.Models;

namespace Engine.Factories
{
    public static class ItemFactory
    {
        private const string GAME_DATA_FILENAME = ".\\GameData\\GameItems.xml";

        private static readonly List<GameItem> _standardGameItems = new List<GameItem>();

        static ItemFactory()
        {
            if(File.Exists(GAME_DATA_FILENAME))
            {
                XmlDocument data = new XmlDocument();
                data.LoadXml(File.ReadAllText(GAME_DATA_FILENAME));

                LoadItemsFromNodes(data.SelectNodes("/GameItems/Weapons/Weapon"));
                LoadItemsFromNodes(data.SelectNodes("/GameItems/HealingItems/HealingItem"));
                LoadItemsFromNodes(data.SelectNodes("/GameItems/MiscellaneousItems/MiscellaneousItem"));
            }
            else
            {
                throw new FileNotFoundException($"Missing data file: {GAME_DATA_FILENAME}");
            }

            /* Using XML file as above
            BuildWeapon(1000, "Pointy Stick", 1, 1, 2);
            BuildWeapon(1001, "Rusty Sword", 5, 1, 3);

            BuildWeapon(1500, "Snake fangs", 0, 0, 2);
            BuildWeapon(1501, "Rat claws", 0, 0, 2);
            BuildWeapon(1502, "Spider fangs", 0, 0, 4);

            BuildHealingItem(2000, "Granola bar", 5, 2);

            BuildMiscellaneousItem(3000, "Oats", 1);
            BuildMiscellaneousItem(3001, "Honey", 2);
            BuildMiscellaneousItem(3002, "Raisins", 2);

            BuildMiscellaneousItem(9000, "Snake fang", 1);
            BuildMiscellaneousItem(9001, "Snakeskin", 2);
            BuildMiscellaneousItem(9002, "Rat tail", 1);
            BuildMiscellaneousItem(9003, "Rat fur", 2);
            BuildMiscellaneousItem(9004, "Spider fang", 1);
            BuildMiscellaneousItem(9005, "Spider silk", 2);
            */
        }

        public static GameItem CreateGameItem(int itemTypeID)
        {
            return _standardGameItems.FirstOrDefault(item => item.ItemTypeID == itemTypeID)?.Clone();
        }

        private static void BuildMiscellaneousItem(int id, string name, int price)
        {
            _standardGameItems.Add(new GameItem(GameItem.ItemCategory.Miscellaneous, id, name, price));
        }

        private static void BuildWeapon(int id, string name, int price, 
                                        int minimumDamage, int maximumDamage)
        {
            GameItem weapon = new GameItem(GameItem.ItemCategory.Weapon, id, name, price, true);

            weapon.Action = new AttackWithWeapon(weapon, minimumDamage, maximumDamage);

            _standardGameItems.Add(weapon);
        }

        private static void BuildHealingItem(int id, string name, int price, int hitPointsToHeal)
        {
            GameItem item = new GameItem(GameItem.ItemCategory.Consumable, id, name, price);
            item.Action = new Heal(item, hitPointsToHeal);
            _standardGameItems.Add(item);
        }

        public static string ItemName(int itemTypeID)
        {
            return _standardGameItems.FirstOrDefault(i => i.ItemTypeID == itemTypeID)?.Name ?? "";
        }

        private static void LoadItemsFromNodes(XmlNodeList nodes)
        {
            if(nodes == null)
            {
                return;
            }

            foreach(XmlNode node in nodes)
            {
                GameItem.ItemCategory itemCategory = DetermineItemCategory(node.Name);

                GameItem gameItem =
                    new GameItem(itemCategory,
                                  GetXmlAttributeAsInt(node, "ID"),
                                  GetXmlAttributeAsString(node, "Name"),
                                  GetXmlAttributeAsInt(node, "Price"),
                                  itemCategory == GameItem.ItemCategory.Weapon);

                if(itemCategory == GameItem.ItemCategory.Weapon)
                {
                    gameItem.Action =
                        new AttackWithWeapon(gameItem,
                                             GetXmlAttributeAsInt(node, "MinimumDamage"),
                                             GetXmlAttributeAsInt(node, "MaximumDamage"));
                }
                else if(itemCategory == GameItem.ItemCategory.Consumable)
                {
                    gameItem.Action =
                        new Heal(gameItem,
                                 GetXmlAttributeAsInt(node, "HitPointsToHeal"));
                }

                _standardGameItems.Add(gameItem);
            }
        }

        private static GameItem.ItemCategory DetermineItemCategory(string itemType)
        {
            switch(itemType)
            {
                case "Weapon":
                    return GameItem.ItemCategory.Weapon;
                case "HealingItem":
                    return GameItem.ItemCategory.Consumable;
                default:
                    return GameItem.ItemCategory.Miscellaneous;
            }
        }

        private static int GetXmlAttributeAsInt(XmlNode node, string attributeName)
        {
            return Convert.ToInt32(GetXmlAttribute(node, attributeName));
        }

        private static string GetXmlAttributeAsString(XmlNode node, string attributeName)
        {
            return GetXmlAttribute(node, attributeName);
        }

        private static string GetXmlAttribute(XmlNode node, string attributeName)
        {
            XmlAttribute attribute = node.Attributes?[attributeName];

            if(attribute == null)
            {
                throw new ArgumentException($"The attribute '{attributeName}' does not exist");
            }

            return attribute.Value;
        }
    }
}