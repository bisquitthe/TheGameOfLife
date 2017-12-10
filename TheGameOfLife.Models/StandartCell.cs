using TheGameOfLife.Models.Abstract;
using TheGameOfLife.Models.Interfaces;

namespace TheGameOfLife.Models
{
    public class StandartCell : Cell
    {
        public StandartCell(Universe universe, int x, int y, INeighborCalculator neighborCalculator) : base(universe, x, y, neighborCalculator)
        {
        }

        public override void Die()
        {
            IsAlive = false;
        }

        public override void Animate()
        {
            IsAlive = true;
        }
    }
}