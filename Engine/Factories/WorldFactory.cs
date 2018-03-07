using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    internal static class WorldFactory
    {
        internal static World CreateWorld()
        {
            World newWorld = new World();

            newWorld.AddLocation(-2, -1, "Farmer's Field",
                "There are rows of corn growing here, with giant rats hiding between them.",
                "FarmFields.png");

            newWorld.LocationAt(-2, -1).AddMonster(2, 100);

            newWorld.AddLocation(-1, -1, "Farmer's House",
                "This is the house of your neighbor, Farmer Cornhusk.",
                "Farmhouse.png");
            newWorld.LocationAt(-1, -1).TraderHere =
                TraderFactory.GetTraderByName("Farmer Cornhusk");

            newWorld.LocationAt(-1, -1).QuestsAvailableHere.Add(QuestFactory.GetQuestByID(2));

            newWorld.AddLocation(0, -1, "Home",
                "This is your home. It is full of spider webs.",
                "Home.png");

            newWorld.AddLocation(-1, 0, "Trading Shop",
                "The shop of Ole Ye Beggar.",
                "Trader.png");
            newWorld.LocationAt(-1, 0).TraderHere =
                TraderFactory.GetTraderByName("Susan");

            newWorld.AddLocation(0, 0, "Town square",
                "You see a fountain and some shrubbery.",
                "TownSquare.png");

            newWorld.AddLocation(1, 0, "Town Gate",
                "There is a gate protecting the town from giant arachnids.",
                "TownGate.png");

            newWorld.AddLocation(2, 0, "Spider Forest",
                "The trees in this forest are covered with spider webs.",
                "SpiderForest.png");

            newWorld.LocationAt(2, 0).AddMonster(3, 100);

            newWorld.AddLocation(0, 1, "Herbalist's hut",
                "You see a quaint hut, with vines covering it.",
                "HerbalistsHut.png");
            newWorld.LocationAt(0, 1).TraderHere =
                TraderFactory.GetTraderByName("Pete the Herbalist");

            newWorld.LocationAt(0, 1).QuestsAvailableHere.Add(QuestFactory.GetQuestByID(1));

            newWorld.AddLocation(0, 2, "Herbalist's Garden",
                "Plants provide refuge for the snakes inhabiting the garden.",
                "HerbalistsGarden.png");

            newWorld.LocationAt(0, 2).AddMonster(1, 100);

            return newWorld;
        }
    }
}