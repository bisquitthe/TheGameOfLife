using System;
using System.Linq;
using TheGameOfLife.Models.Abstract;
using TheGameOfLife.Models.Interfaces;

namespace TheGameOfLife.Models.Rules
{
    public class EndIfGenerationHasNotChanged : IEndRule
    {
        public EndIfGenerationHasNotChanged(Universe universe)
        {
            IsEnd = () => IsEndImpl(universe);
        }
        public Func<bool> IsEnd { get; }

        private bool IsEndImpl(Universe universe)
        {
            if (universe.GenerationHistory.Count < 2)
                return false;
            var penultGeneration = universe.GenerationHistory.Values.ToList()[universe.GenerationHistory.Count - 2].ToList();
            var lastGeneration = universe.GenerationHistory.Values.Last().ToList();
            if (penultGeneration.Count != lastGeneration.Count)
                return false;
            if (lastGeneration.Any(t => penultGeneration.All(c => c.IsAlive == t.IsAlive && c.Y == t.Y &&
                                                                  c.X == t.X)))
            {
                return true;
            }

            return false;
        }
    }
}