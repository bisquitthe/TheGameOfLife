using System.Collections.Generic;
using System.Linq;
using TheGameOfLife.Models.Abstract;

namespace TheGameOfLife.Models.Universes
{
    public class InfiniteUniverse : Universe
    {
        public override bool IsFinished()
        {
            if (_generationHistory.Count < 2)
                return !_generationHistory.Last().Value.Any(c => c.IsAlive);
            var penultGeneration = _generationHistory.Values.ToList()[_generationHistory.Count -2];
            var lastGeneration = _generationHistory.Last();
        }

        public override IEnumerable<Cell> GetCellNeighbors(Cell cell)
        {
            
        }
    }
}