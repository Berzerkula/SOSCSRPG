using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    public class ItemFactory
    {
        private static List<GameItem> _standardGameItems;

        static ItemFactory()
        {
            _standardGameItems = new List<GameItem>();

            _standardGameItems.Add(new Weapon(1000, "Jagged Rock", 1, 1, 3));
            _standardGameItems.Add(new Weapon(1001, "Pointy Stick", 2, 1, 5));
            _standardGameItems.Add(new Weapon(1002, "Rusty Sword", 5, 1, 10));
        }

        public static GameItem CreateGameItem(int itemTypeID)
        {
            GameItem standardItem = _standardGameItems.FirstOrDefault(item => item.ItemTypeID == itemTypeID);

            if (_standardGameItems != null)
            {
            }
        }
    }
}
