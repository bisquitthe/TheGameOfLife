using System.Collections.Generic;
using TheGameOfLife.Models.Abstract;

namespace TheGameOfLife.Models.Universes
{
    public class LoopedUniverse : FiniteUniverse
    {
        public LoopedUniverse(int height, int width) : base(height,width)
        {

        }

        public override bool IsFinished()
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<Cell> GetCellNeighbors(Cell cell)
        {
            throw new System.NotImplementedException();
        }
    }
}