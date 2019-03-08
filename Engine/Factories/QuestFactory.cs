using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    internal static class QuestFactory
    {
        private static readonly List<Quest> _quests = new List<Quest>();

        static QuestFactory()
        {
            // Declare the items needed to complete the quest, and its reward items
            List<ItemQuantity> snakeItemsToComplete = new List<ItemQuantity>();
            List<ItemQuantity> ratItemsToComplete = new List<ItemQuantity>();
            List<ItemQuantity> rewardItems = new List<ItemQuantity>();

            snakeItemsToComplete.Add(new ItemQuantity(9000, 5)); //Snake fang
            ratItemsToComplete.Add(new ItemQuantity(9002, 5)); //Rat tail
            rewardItems.Add(new ItemQuantity(1002, 1));     //Rusty sword reward for both quests

            // Create the quest
            _quests.Add(new Quest(1,
                "Clear the herb garden",
                "Defeat the snakes in the Herbalist's garden",
                snakeItemsToComplete,
                25, 10,
                rewardItems));

            _quests.Add(new Quest(2,
                "Clear the farmer's field",
                "Defeat the rats in the Farmer's field",
                ratItemsToComplete,
                25, 10,
                rewardItems));
        }

        internal static Quest GetQuestByID(int id)
        {
            return _quests.FirstOrDefault(quest => quest.ID == id);
        }
    }
}