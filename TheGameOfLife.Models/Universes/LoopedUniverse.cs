using TheGameOfLife.Models.Abstract;

namespace TheGameOfLife.Models.Universes
{
    public class LoopedUniverse : Universe
    {
        public LoopedUniverse(int height, int width)
        {
            _height = height;
            _width = width;
        }

        private int _height;
        private int _width;
    }
}