using System.Collections.Generic;
using TheGameOfLife.Models.Abstract;
using TheGameOfLife.Models.Interfaces;

namespace TheGameOfLife.Models
{
    public class Game
    {
        public Game(Universe universe,IEnumerable<IEndRule> endRules)
        {
            EndRules = endRules;
            Universe = universe;
        }
        public Universe Universe { get; }
        public IEnumerable<IEndRule> EndRules { get; }
    }
}