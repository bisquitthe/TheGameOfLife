using System.Collections.Generic;

namespace TheGameOfLife.Models.Abstract
{
    public abstract class Cell
    {
        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; } 
        public int Y { get; }
        public bool IsAlive { get; protected set; }
        public abstract void Die();
        public abstract void Animate();
        public IEnumerable<Cell> Neighbors { get; }
    }
}