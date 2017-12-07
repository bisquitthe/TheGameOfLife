using System.Linq;
using TheGameOfLife.Models.Abstract;
using TheGameOfLife.Models.Interfaces;
using TheGameOfLife.Models.Rules;

namespace TheGameOfLife.BL.Services
{
    public class RuleService : IRuleService
    {
        public IEndRule GetEndIfGenerationHasNotChanged(Universe universe)
        {
            return new EndIfGenerationHasNotChanged(universe);
        }

        public IEndRule GetEndIfNoAliveRule(Universe universe)
        {
            return new EndIfNoOneAliveRule(universe);
        }
    }
}