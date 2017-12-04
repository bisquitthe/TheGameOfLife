namespace TheGameOfLife.Models.Abstract
{
    public abstract class Cell
    {
        public int X { get; }
        public int Y { get; }
        public bool IsAlive { get; protected set; }
        public abstract void Die();
        public abstract void Animate();
    }
}