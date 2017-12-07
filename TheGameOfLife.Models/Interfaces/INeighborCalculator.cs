using System.Collections.Generic;
using TheGameOfLife.Models.Abstract;

namespace TheGameOfLife.Models.Interfaces
{
    public interface INeighborCalculator
    {
        IEnumerable<Coordinates> GetNeighbors(Coordinates coordinates, int rank);
    }
}