using System.Collections.Generic;
using TheGameOfLife.Models.Interfaces;

namespace TheGameOfLife.Models.Abstract
{
    public abstract class Cell
    {
        public Cell(int x, int y, INeighborCalculator neighborCalculator)
        {
            Coordinates = new Coordinates(x,y);
            _neighborCalculator = neighborCalculator;
        }
        protected INeighborCalculator _neighborCalculator { get; set; }
        public Coordinates Coordinates { get; }
        public bool IsAlive { get; protected set; }
        public abstract void Die();
        public abstract void Animate();
        public int NeighborRank { get; set; }

        public IEnumerable<Coordinates> SupposedNeighbors => _neighborCalculator.GetNeighbors(Coordinates, NeighborRank);
    }
}