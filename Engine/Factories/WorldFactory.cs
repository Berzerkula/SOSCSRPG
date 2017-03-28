using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    internal class WorldFactory
    {
        internal World CreateWorld()
        {
            World newWorld = new World();

            newWorld.AddLocation(-2, -1, "Farmer's Field",
                "There are rows of corn growing here, with giant rats hiding between them.",
                "/Engine;component/Images/Locations/FarmFields.png");

            newWorld.AddLocation(-1, -1, "Farmer's House",
                "This is the house of your neighbor, Farmer Cornusk.",
                "/Engine;component/Images/Locations/Farmhouse.png");

            newWorld.AddLocation(0, -1, "Home",
                "This is your home. It is full of spider webs.",
                "/Engine;component/Images/Locations/Home.png"); 

            return newWorld;
        }
    }
}
