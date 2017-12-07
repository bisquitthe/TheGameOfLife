using System;
using System.Linq;
using TheGameOfLife.Models.Abstract;
using TheGameOfLife.Models.Interfaces;

namespace TheGameOfLife.Models.Rules
{
    public class EndIfNoOneAliveRule : IEndRule
    {
        public EndIfNoOneAliveRule(Universe universe)
        {
            IsEnd = () => !universe.GenerationHistory.Last().Value.Any(c => c.IsAlive);
        }
        public Func<bool> IsEnd { get; }
    }
}