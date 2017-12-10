using System.Collections.Generic;
using TheGameOfLife.Models.Interfaces;

namespace TheGameOfLife.Models.Abstract
{
    public abstract class Cell
    {
        public Cell(Universe universe, int x, int y, INeighborCalculator neighborCalculator)
        {
            Coordinates = new Coordinates(x,y);
            _neighborCalculator = neighborCalculator;
            Universe = universe;
        }
        protected INeighborCalculator _neighborCalculator { get; set; }

        public Universe Universe { get; }
        public Coordinates Coordinates { get; }
        public bool IsAlive { get; protected set; }
        public abstract void Die();
        public abstract void Animate();
        public int NeighborRank { get; set; }

        public IList<Coordinates> Neighborhoods
        {
            get
            {
                var supposedCellsCoordinates = _neighborCalculator.GetNeighbors(Coordinates, NeighborRank);
                return Universe.GetAppropriateCoordinates(supposedCellsCoordinates);
            }
        }
    }
}