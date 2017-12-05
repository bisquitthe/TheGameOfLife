using System.Collections.Generic;
using TheGameOfLife.Models.Interfaces;

namespace TheGameOfLife.Models.Abstract
{
    public abstract class UniverseCreator
    {
        public abstract Universe CreateUniverse();
    }
}