using System.Collections.Generic;
using TheGameOfLife.Models.Abstract;

namespace TheGameOfLife.Models.Universes
{
    public class FiniteUniverse : Universe
    {
        public FiniteUniverse(int height, int width)
        {
            Height = height;
            Width = width;
        }

        public int Height { get; }
        public int Width { get; }

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