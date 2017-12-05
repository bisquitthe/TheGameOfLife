using System.Collections.Generic;
using TheGameOfLife.Models;
using TheGameOfLife.Models.Abstract;
using TheGameOfLife.Models.Interfaces;

namespace TheGameOfLife.BL.Services
{
    public class GameService
    {
        public Game CreateGame(Universe universe, IEnumerable<IEndRule> endRules)
        {
            return new Game(universe, endRules);
        }
    }
}