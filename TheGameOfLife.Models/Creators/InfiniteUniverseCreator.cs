using TheGameOfLife.Models.Abstract;
using TheGameOfLife.Models.Universes;

namespace TheGameOfLife.Models.Creators
{
    public class InfiniteUniverseCreator : UniverseCreator
    {
        public override Universe CreateUniverse()
        {
            return new InfiniteUniverse();
        }
    }
}