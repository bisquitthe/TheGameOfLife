using System.Collections.Generic;
using System.Linq;
using TheGameOfLife.Models.Abstract;
using TheGameOfLife.Models.Interfaces;

namespace TheGameOfLife.Models.Universes
{
    public class FiniteUniverse : Universe
    {
        public FiniteUniverse(int height, int width)
        {
            _height = height;
            _width = width;
        }

        private int _height;
        private int _width;
    }
}