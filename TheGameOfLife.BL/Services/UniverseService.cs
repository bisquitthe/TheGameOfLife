using System.Collections.Generic;
using TheGameOfLife.Models.Abstract;
using TheGameOfLife.Models.Interfaces;

namespace TheGameOfLife.BL.Services
{
    public class UniverseService
    {
        private INeighborCalculator _neighborCalculator;

        public UniverseService(INeighborCalculator neighborCalculator)
        {
            _neighborCalculator = neighborCalculator;
        }

        public IEnumerable<Cell> GetCellNeighbors(Cell cell, Universe universe)
        {
            return _neighborCalculator.GetCellNeighbors(cell, universe);
        }
    }
}