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

            newWorld.AddLocation(0, -1, "Home",
                "This is your home. It is full of spider webs.",
                "/Engine;component/Images/Locations/Home.png");

            return newWorld;
        }
    }
}
