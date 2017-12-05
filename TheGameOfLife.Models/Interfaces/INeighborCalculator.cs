using System.Collections.Generic;
using TheGameOfLife.Models.Abstract;

namespace TheGameOfLife.Models.Interfaces
{
    public interface INeighborCalculator
    {
        IEnumerable<Cell> GetCellNeighbors(Cell cell, Universe universe);
    }
}