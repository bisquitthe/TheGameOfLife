using System.Collections.Generic;

namespace TheGameOfLife.Models.Abstract
{
    public abstract class Universe
    {
        protected Universe()
        {
            _generationHistory = new Dictionary<int, IEnumerable<Cell>>();
        }

        protected Dictionary<int, IEnumerable<Cell>> _generationHistory;

        public abstract bool IsFinished();
        public abstract IEnumerable<Cell> GetCellNeighbors(Cell cell);
        public IReadOnlyDictionary<int, IEnumerable<Cell>> GenerationHistory => _generationHistory;

        public void ClearGenerationHistory()
        {
            _generationHistory.Clear();
        }
    }
}